using UnityEngine;
using TMPro;

public class MarcsInMenu : MonoBehaviour
{
    public Marcs marcs;
    public TextMeshProUGUI  earnedMarcs;
    
    void Update()
    {
        earnedMarcs.text = marcs.marcsSumInARound.ToString();
    }
}
