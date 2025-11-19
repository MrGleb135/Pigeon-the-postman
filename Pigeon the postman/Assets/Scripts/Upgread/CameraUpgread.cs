using UnityEngine;

public class CameraUpgread : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(-2.05f, -2.65f, -10f);
    public float orthographicSize = 1.6f;
    public bool upgreadMenu;
    public GameObject updateMenu;
    public GameObject energyScale;
    public Marcs marcs;

    void Start()
    {
        updateMenu.SetActive(true);
        energyScale.SetActive(false);
        Camera.main.orthographicSize = orthographicSize;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        Camera.main.transform.position = transform.position;
        upgreadMenu = true;
    }

    public void ButtonStartGame()
    {
        upgreadMenu = false;
        updateMenu.SetActive(false);
        energyScale.SetActive(true);
    }
}
