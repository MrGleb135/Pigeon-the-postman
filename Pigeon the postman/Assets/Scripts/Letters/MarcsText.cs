using UnityEngine;
using UnityEngine.UI;

public class MarcsText : MonoBehaviour
{
    public Text marcsText;
    public Marcs marcs;

    void Update()
    {
        marcsText.text = marcs.marcs.ToString();
    }   
}
