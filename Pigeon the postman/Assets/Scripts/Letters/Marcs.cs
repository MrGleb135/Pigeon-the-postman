using UnityEngine;

public class Marcs : MonoBehaviour
{
    public int marcs = 0;
    public int marcsSumInARound = 0;
    
    void Start()
    {
        marcsSumInARound = 0;

        if (PlayerPrefs.HasKey("MarcsCount"))
        {
            marcs = PlayerPrefs.GetInt("MarcsCount");
        }
    }
}
