using UnityEngine;
using System;

public class sharpturn : MonoBehaviour
{
    float stepper;
    bool sweet;
    
       public float range = 1f;

    bool sweet2 = false;
bool stopreached;
    float blue = 0;    
    float random2 = 9;
    int just=0;
        float g=0;
    public Transform move;
    Vector3 orig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orig=transform.position;
        g=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopreached){
        stepper+=Time.deltaTime;
        blue+=Time.deltaTime;
        just=Mathf.RoundToInt(stepper);
        if (just % 33 == 0) {
        random2 = UnityEngine.Random.Range(0,40);
        }
        stepper+=Time.deltaTime;
        if(random2 > 30)
            {
            random2=0;
            sweet2 = !sweet2;
            blue=0;
        }
        if(sweet2){
        transform.position = new Vector3(transform.position.x,g+3*Mathf.Sin(5*stepper),-10);
            if (blue >= 0.1f)
            {
                sweet2=false;
                blue=0;
            }
        }
        else
        {
        if(blue<=1){
        transform.position = Vector3.Lerp(transform.position,orig,blue);
        }
        }
                }
    }
}
