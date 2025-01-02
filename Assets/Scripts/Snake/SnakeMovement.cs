using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeMovement : MonoBehaviour
{
    public float forwardSpeed = 5;
    private float sensitivity = 50;

    private Camera mainCamera;
    private Rigidbody2D componentRigidbody;

    private Vector2 touchLastPos;
    private float sidewaysSpeed;

    private void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody2D>();

        LeanTween.value(forwardSpeed, 10, 200).setOnUpdate(UpdateSpeed);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        componentRigidbody.velocity = new Vector2(sidewaysSpeed * 5, forwardSpeed);
        sidewaysSpeed = 0;
    }

    void UpdateSpeed(float value)
    {
        forwardSpeed = (int)value;
    }
}