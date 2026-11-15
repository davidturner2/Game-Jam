using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public GameObject Word1;
    public GameObject Word2;
    public Transform[] WindowPoints2;
    public GameObject Word3;
    public Transform[] WindowPoints3;
    public LetterScorePointsScript DrawLogicScript;

    public void NextPage()
    {
        if (Word1.activeSelf)
        {
            Word1.SetActive(false);
            GameObject[] Drawing = GameObject.FindGameObjectsWithTag("Drawing");
            foreach (GameObject drawing in Drawing)
            {
                Destroy(drawing);
            }
            DrawLogicScript.CurrentScore = 0f;
            Transform[] WindowPoints = DrawLogicScript.WindowPoints;
            WindowPoints = WindowPoints2;
            DrawLogicScript.WindowPoints = WindowPoints;

            DrawLogicScript.unsealedPoints = new List<Transform>(WindowPoints2);
            Word2.SetActive(true);
        }
        else if (Word2.activeSelf)
        {
            Word2.SetActive(false);
            GameObject[] Drawing = GameObject.FindGameObjectsWithTag("Drawing");
            foreach (GameObject drawing in Drawing)
            {
                Destroy(drawing);
            }
            DrawLogicScript.CurrentScore = 0f;
            Transform[] WindowPoints = DrawLogicScript.WindowPoints;
            WindowPoints = WindowPoints3;
            DrawLogicScript.WindowPoints = WindowPoints;
            DrawLogicScript.unsealedPoints = new List<Transform>(WindowPoints3);

            Word3.SetActive(true);
        }
    }

}
