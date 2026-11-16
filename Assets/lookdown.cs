using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class lookdown : MonoBehaviour, IPointerEnterHandler
{
    bool door = false;

    public WindowSealer bruh;
    public stutter huh;
    public sharpturn wuh;
    public lookup guh;
    public GameObject move;
    public Vector3 orig;
    float blue = 0;

    public GameObject mta;
    public GameObject mta2;
    public GameObject draw;
    public GameObject draw2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orig = move.transform.position+new Vector3(0,-10f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (door)
        {
            blue += Time.deltaTime;
            move.transform.position = Vector3.MoveTowards(move.transform.position, orig, easeInOutQuart(blue));
        }
        if ((blue) >= 0.6f)
        {
            draw2.SetActive(true);
            Cursor.visible = false;
            mta.SetActive(false);
            draw.SetActive(true);
            door = false;
            blue = 0;
            enabled = false;
            guh.enabled = true;
            guh.GetComponent<Image>().enabled = true;
            GetComponent<Image>().enabled = false;
        }
    }

    float easeInOutQuart(float x) {
        if (x < 1)
            return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        else
            return 1;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (door == false ) {
        mta2.SetActive(false);
        bruh.enabled = true;
        wuh.enabled = true;
        huh.ranger = 3;
        door = true;
        }
        
    }
}
