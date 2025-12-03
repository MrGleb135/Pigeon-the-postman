using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetPoint : MonoBehaviour
{
    public LettersManager lettersManager;
    public LettersCount lettersCount;

    [Header("Цели")]
    public GameObject devecote;
    public GameObject pigeon;
    public GameObject target;
    public GameObject task1, task2;
    public List<LettersData> selectedHouses;

    [Header("Всё остальное")]
    public GameObject marker;
    public float left, right, bottom, top;

    void Start()
    {
        
    }

    void Update()
    {
        // Обновляем список выбранных домов из менеджера писем
        selectedHouses = lettersManager.selectedHouses;

        // Вычисляем границы видимой области камеры
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        left = bottomLeft.x;
        right = topRight.x;
        bottom = bottomLeft.y;
        top = topRight.y;

        if(lettersCount.letters <= 0)
        {
            task1.SetActive(false);
            task2.SetActive(true);

            // Проверяем, видна ли голубятня на экране
            Vector2 devecotePosition = devecote.transform.position;
            if (devecotePosition.x > left && devecotePosition.x < right && devecotePosition.y < top && devecotePosition.y > bottom)
            {
                marker.SetActive(false);
            }
            else
            {
                marker.SetActive(true);
                PlaceMarker(devecote);
            }
        }
        else
        {
            task1.SetActive(true);
            task2.SetActive(false);

            FindNearestHouse();
            // Если целей нет, скрываем маркер
            if (target == null)
            {
                marker.SetActive(false);
                return;
            }

            // Проверяем, видна ли текущая цель на экране
            Vector2 targetPosition = target.transform.position;
            if (targetPosition.x > left && targetPosition.x < right && targetPosition.y < top && targetPosition.y > bottom)
            {
                marker.SetActive(false);
            }
            else
            {
                marker.SetActive(true);
                PlaceMarker(target);
            }
        }
    }

    // Нахождение ближайшего дома к игроку
    void FindNearestHouse()
    {
        float minDistance = float.MaxValue; // Начальная "бесконечно большая" дистанция
        LettersData nearestHouse = null;

        Vector2 playerPosition = pigeon.transform.position;

        for (int i = 0; i < selectedHouses.Count; i++)
        {
            LettersData houseData = selectedHouses[i];

            // Вычисляем дистанцию от игрока до дома
            float dist = Vector2.Distance(playerPosition, houseData.house.transform.position);

            // Если расстояние меньше текущего минимума, обновляем ближайший дом
            if (dist < minDistance)
            {
                minDistance = dist;
                nearestHouse = houseData;
            }
        }

        // Устанавливаем цель на ближайший дом
        if (nearestHouse != null)
        {
            target = nearestHouse.house;
        }
        else
        {
            target = null;
        }
    }

    // Размещение маркера на экране, указывающего на цель
    void PlaceMarker(GameObject targetObject)
    {
        Camera cam = Camera.main;
        Vector2 targetPos = targetObject.transform.position;
        Vector2 playerPosition = pigeon.transform.position;

        Vector3 viewportPos = cam.WorldToViewportPoint(targetPos);

        float padding = 0.05f;
        viewportPos.x = Mathf.Clamp(viewportPos.x, padding, 1 - padding);
        viewportPos.y = Mathf.Clamp(viewportPos.y, padding, 1 - padding);
        viewportPos.z = 0f;

        Vector3 worldPos = cam.ViewportToWorldPoint(viewportPos);
        worldPos.z = 0f;

        // Устанавливаем позицию маркера
        marker.transform.position = worldPos;

        // Вычисляем направление от игрока к цели для поворота маркера
        Vector2 direction = targetPos - playerPosition;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90f;
        marker.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
