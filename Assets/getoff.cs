using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;// Required when using Event data.


public class getoff : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
private Button b;
bool door = false;
bool f = false;
public train j;
public GameObject k;
float jk=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        b=GetComponent<Button>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (j.no == true)
        {
            b.interactable = false;
        }
        else
        {
            b.interactable = true;
        }

        if (Input.GetMouseButton(0) && door && j.no==false)
        {
            jk+=Time.deltaTime;
            if (j.no)
            {
                jk=0;
            }
        }
        else
        {
            jk=0;
        }
        k.GetComponent<Image>().color = Color.Lerp(Color.clear,Color.black,jk);
        if (f)
        {
            if (Input.GetMouseButtonUp(0))
            {
                f=false;
                        door = false;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        print("door false");
        if(!Input.GetMouseButton(0)){
        door = false;
        }
        else
        {
            f=true; 
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (j.no == false)
        {
        print("door true");
        door = true;
        }
    }

}
