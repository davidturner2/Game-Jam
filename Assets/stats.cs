using TMPro;
using UnityEngine;

public class stats : MonoBehaviour
{
    public TextMeshProUGUI hmm;
    public int stop = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    public void win(float a, float b, float c, int d)
    {
        float scorelate = (a + b + c - 10f)/3f;
        float score = (a + b + c ) / 3f;
        print(scorelate);
        print(score);
        string f = scorelate>90f ? "<color=blue>A" : scorelate > 80f ? "<color=orange>B" : scorelate > 65f ? "<color=blue>C" : scorelate > 55f ? "<color=orange>D" : scorelate > -200f ? "<color=orange>F" : "<color=orange>F";
       
        string f2 = score > 90f ? "<color=blue>A" : score > 80f ? "<color=orange>B" : score > 65f ? "<color=blue>C" : score > 55f ? "<color=orange>D" : score > -200f ? "<color=orange>F" : "<color=orange>F";
        if (d != 10)
        {
            
            hmm.text = "\"Oops that's not the right stop. That's gonna cost me time.\"\r\nHomework average: "+a+"% " + b+"% "+ c+"% <color=red>-10%*Lateness</color>\r\n\r\nFinal Score: "+f+"</color>";
        }
        else
        {
            hmm.text = "\"Right on time.\"\r\nHomework average: " + a + "% " + b + "% " + c + "%\r\n\r\nFinal Score: " + f2 + "</color>";
        }
    }
}
