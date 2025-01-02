using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    GameObject Сamera;
    float imageHeight = 19f;
    float startPosition;
    [SerializeField]
    float parallaxEffect = 0.3f;

    void Start()
    {
        startPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        // Используется для повторения заднего фона
        float temp = (Сamera.transform.position.y * (1 - parallaxEffect));

        // Рассчитайте расстояние, умножив положение камеры по оси Y на переменную эффекта параллакса.
        float distance = (Сamera.transform.position.y * parallaxEffect);

        // Изменить положение по оси Y текущего фонового игрового объекта (маленький, средний, большой)
        transform.position = new Vector3(transform.position.x, startPosition + distance, transform.position.z);

        // Для повторений заднего фона
        if (temp > startPosition + imageHeight)
        {
            startPosition += imageHeight;
        }
        else if (temp < startPosition - imageHeight)
        {
            startPosition -= imageHeight;
        }
    }
}
