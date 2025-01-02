using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    GameObject �amera;
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
        // ������������ ��� ���������� ������� ����
        float temp = (�amera.transform.position.y * (1 - parallaxEffect));

        // ����������� ����������, ������� ��������� ������ �� ��� Y �� ���������� ������� ����������.
        float distance = (�amera.transform.position.y * parallaxEffect);

        // �������� ��������� �� ��� Y �������� �������� �������� ������� (���������, �������, �������)
        transform.position = new Vector3(transform.position.x, startPosition + distance, transform.position.z);

        // ��� ���������� ������� ����
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
