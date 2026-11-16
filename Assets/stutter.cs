using UnityEngine;

public class stutter : MonoBehaviour
{
    [SerializeField] private float speed = 433f;
    public float ranger = 3f;
    float stepper=0;
    float stepper2=0;

    bool sweet = false;
    bool sweet2 = false;

    bool stop = false;
    bool stopreached= false;
    float random = 0;    

    int just = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopreached){
        stepper+=Time.deltaTime;
        just=Mathf.RoundToInt(stepper);
        //print(just);
        if(stepper<0)
        sweet = false;
        else if(stepper>1)
        sweet=true;
        if(stepper2<0)
        sweet2 = false;
        else if(stepper2>1)
        sweet2 =true;
        if(sweet){
        stepper-=Time.deltaTime*1.2f;
        }else{
        stepper+=Time.deltaTime;
        }
        if(sweet2){
        stepper2-=Time.deltaTime*1.5f;
        }else{
        stepper2+=Time.deltaTime*1.5f;
        }
        if(random>2){
        random=0;
        stop = !stop;
        }
        if (just % 3 == 0) {
        random = Random.Range(0,7);
        }
        if(!stop){
        transform.position = new Vector3(Mathf.Lerp(0, ranger, easeInOutBounce(stepper)),transform.position.y,-10f);
        }
        }
    }


    float easeInOutBounce(float x) {
return x < 0.5f ? (1 - easeOutBounce(1 - 2 * x)) / 2
  : (1 + easeOutBounce(2 * x - 1)) / 2;
}


float easeOutBounce(float x){
float n1 = 7.5625f;
float d1 = 2.75f;

if (x < 1 / d1) {
    return n1 * x * x;
} else if (x < 2f / d1) {
    return n1 * (x -= 1.5f / d1) * x + 0.75f;
} else if (x < 2.5f / d1) {
    return n1 * (x -= 2.25f / d1) * x + 0.9375f;
} else {
    return n1 * (x -= 2.625f / d1) * x + 0.984375f;
}
}
}
