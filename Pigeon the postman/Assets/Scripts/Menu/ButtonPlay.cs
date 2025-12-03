using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void ButtonPlayActive()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ButtonMenuActive()
    {
        SceneManager.LoadScene(0);
    }
}
