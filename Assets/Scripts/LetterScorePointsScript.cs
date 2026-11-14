using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

public class LetterScorePointsScript : MonoBehaviour
{
    public Transform[] WindowPoints;
    private List<Transform> unsealedPoints;
    [Header("Scoring Parameters")]
    //how far the mouose is from the sealing points before it starts to lose accuracy
    public float LowErrorMargin;
    //how fast you lose points at at the low end
    public float LowPenaltyRate;
    //how far the mouse is from the sealing points before it starts to lose even more accuracy
    public float HighErrorMargin;
    //how fast you lose points at the high end
    public float HighPenaltyRate;
    [Header("Speed Settings")]
    private Vector3 lastMousePosition;
    private float currentMouseSpeed;
    [Header("Score")]
    public float finalPercentage;
    public float finalTierPoints;
    public float pointsPerSeal;
    public float CurrentScore = 0f;
    public float maxPossibleScore = 100f;
    public float FinalScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI accuracyText;
    [Header("Score Saving")]
    public string scoreKey;
    private float timer = 0f;
    public static LetterScorePointsScript instance;
    public TextMeshProUGUI finalscore;


    float distanceToPoint;
    Vector3 worldMousePos;
    void Start()
    {
        unsealedPoints = new List<Transform>(WindowPoints);
        instance = this;

        CurrentScore = 0f;
        maxPossibleScore = WindowPoints.Length * pointsPerSeal;

    }

    void Update()
    {
        CalculateMouseSpeed();
        if (WindowSealer.instance != null && WindowSealer.instance.isDrawing == true)
        {
            //starts the functions of the game once you click anywhere on the screen
            CheckAccuracy();
        }
        
        if (currentScoreText != null)
        {
            float livePercentage = 0f;

            if (maxPossibleScore > 0f)
            {
                livePercentage = (CurrentScore / maxPossibleScore) * 100f;
                livePercentage = Mathf.Clamp(livePercentage, 0f, 100f);
            }
            currentScoreText.text = "Score: " + livePercentage.ToString("F2") + "%";
        }


        lastMousePosition = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
        Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z)));

       
    }
    public void CheckAccuracy()
    {
        //mouse stuff
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z);
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //checks the distance from the mouse to any point of th ewindow and stores it.  
        distanceToPoint = float.MaxValue;
        foreach (var point in WindowPoints)
        {
            float d = Vector3.Distance(worldMousePos, point.position);
            if (d < distanceToPoint)
            {
                distanceToPoint = d;
            }
        }

        float minDistanceToGoal = float.MaxValue;
        Transform closestPoint = null;
        //checks the distance from the mouse to any unsealed point and stores it
        foreach (var point in unsealedPoints)
        {
            float distance = Vector3.Distance(worldMousePos, point.position);
            if (distance < minDistanceToGoal)
            {
                minDistanceToGoal = distance;
                closestPoint = point;
            }
        }

        LosePointsForAccuracy();

        //gives x points per seal and removes the point from list
        if (minDistanceToGoal < 0.2f && closestPoint != null)
        {
            unsealedPoints.Remove(closestPoint);
            CurrentScore += pointsPerSeal;
        }
    }

    public bool losingPoints = false;
    public void LosePointsForAccuracy()
    {
        //loses points if you really far from a seal
        if (distanceToPoint > HighErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * HighPenaltyRate;
            Debug.Log("<color=red>LOSING EVEN MORE POINTS!</color>");
            //WindowScript.instance.timer -= Time.deltaTime * speedPointsLoss;
        }
        //loses points if you are somewhat far from a seal
        else if (distanceToPoint > LowErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * LowPenaltyRate;
            Debug.Log("<color=red>LOSIKNG POINTS!</color>");
            //WindowScript.instance.timer -= Time.deltaTime * speedPointsLoss;

        }
        //turns off the losing points variable if you are touching a seal
        else
        {
            losingPoints = false;
            timer = 0f;
        }
        //loses even more points you are losing points for too long
        if (losingPoints)
        {
            if (losingPoints)
            {
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    Debug.Log("<color=red>LOSING POINTS FOR TOO LONG!</color>");
                    CurrentScore -= Time.deltaTime * HighPenaltyRate * 1.5f;
                }
            }
        }
    }
    void CalculateMouseSpeed()
    {
        //tracks where the mouse is relative to the world 
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y,
        Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z)));
        //calculates the speed of the mouse by checking how far it has moved since the last frame and dividing by time
        currentMouseSpeed = Vector3.Distance(currentMousePos, lastMousePosition) / Time.deltaTime;
    }
    public float GetFinalScore()
    {
        //returns 0 if there is no score at all, otherwise returns the current score
        float roundedScore = (float)(Math.Round(CurrentScore * 100f) / 100f);
        return Mathf.Max(0, roundedScore);
    }
}
