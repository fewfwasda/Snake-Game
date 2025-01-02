using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();


    [HideInInspector] public int Length = 1;
    public TextMeshPro PointsText;

    public ParticleSystem removeCircleParticles;
    
    private void Awake()
    {
        positions.Add(SnakeHead.position);
    }
    private void Update()
    {
        float distance = ((Vector2)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // Ќаправление от старого положени€ головы, к новому
            Vector2 direction = ((Vector2)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Length++;
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        PointsText.SetText(Length.ToString());
    }
    public void RemoveCircle()
    {
        Length--;
        if (Length <= 0) FindFirstObjectByType<GameOverScreen>().StartGameOverScreen();
        Destroy(snakeCircles[0].gameObject);
        SpawnRemoveCircleParticles();
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(0);
        PointsText.SetText(Length.ToString());
    }

    private void SpawnRemoveCircleParticles()
    {
        Instantiate(removeCircleParticles, transform.position, Quaternion.identity);
    }
}