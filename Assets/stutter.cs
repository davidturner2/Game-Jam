using UnityEngine;

public class stutter : MonoBehaviour
{
    [SerializeField] private float speed = 433f;
    public float range = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(range*Mathf.Sin(0.005f*Time.deltaTime/speed+Random.Range(2f,4f)),1.1f*Mathf.Tan(0.005f*Time.deltaTime/speed*63.04f+Random.Range(0.002f,0.04f)),-10f);
    }
}
