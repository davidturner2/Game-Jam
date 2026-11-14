using UnityEngine;
using TMPro;

public class train : MonoBehaviour
{
    float timer;
    int number = 1;
    public TextMeshProUGUI stop;
    public TextMeshProUGUI numberstop;
    public TextMeshProUGUI button;
    bool no=true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stop.text="The next stop is "+(number+1);
        numberstop.text=""+number;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer+=Time.deltaTime;
        if (timer > 3 && timer<=7)
        {
            if(no){
            number++;
            no=false;
            }
            numberstop.text=""+number;
            stop.text="This stop is "+(number);
        }else if (timer > 7)
        {   
            stop.text="The next stop is "+(number+1);
            timer=0;
            no=true;
        }
    }
}
