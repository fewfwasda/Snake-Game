using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    private SnakeTail componentSnakeTail;
    public TextMeshPro text;
    private int minValue;
    private int maxValue;
    private int value;

    private void Start()
    {
        componentSnakeTail = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeTail>();
        minValue = 1;
        maxValue = 4;


        value = Random.Range(maxValue, minValue);
        text.SetText(value.ToString());

        Destroy(gameObject, 9f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            for (int i = value; i > 0; i--)
            {
                componentSnakeTail.AddCircle();
            }

            Destroy(gameObject);
        }
    }

}