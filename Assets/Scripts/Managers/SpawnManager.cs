using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> spawnHorizontalPointsBlock = new List<Transform>();
    public List<Transform> randomPointsBlock = new List<Transform>();
    public List<Transform> randomPointsFood = new List<Transform>();
    public GameObject block;
    public GameObject food;
    private float pointToSpawn = 10;
    private float rangeToSpawn = 15;
    private float countObject;
    public int minValueBlock = 1;
    public int maxValuelBlock = 8;

    private float intrvaleMaxValue =15;
    private float intrvaleMinValue =20;
    void FixedUpdate()
    {
        intrvaleMaxValue -= Time.deltaTime;
        intrvaleMinValue -= Time.deltaTime;

        if (intrvaleMaxValue <= 0.0f)
        {
            maxValuelBlock++;
            intrvaleMaxValue = 10;
        }
        if (intrvaleMinValue <= 0.0f)
        {
            minValueBlock++;
            intrvaleMinValue = 20;
        }

        if (transform.position.y >= pointToSpawn)
        {
            SpawnLineBlock();
            pointToSpawn += rangeToSpawn;
        }
    }
    private void SpawnLineBlock()
    {
        for (int i = 0; i < spawnHorizontalPointsBlock.Count; i++)
        {
            Instantiate(block, spawnHorizontalPointsBlock[i].transform.position, Quaternion.identity);
        }
        SpawnRandomBlock();
        SpawnRandomFood();
    }
    private void SpawnRandomBlock()
    {
        countObject = Random.Range(2, randomPointsBlock.Count);

        randomPointsBlock = Shuffle(randomPointsBlock);



        for (int i = 0; i < countObject; i++)
        {
            Instantiate(block, randomPointsBlock[i].transform.position, Quaternion.identity);
        }
    }

    private void SpawnRandomFood()
    {
        countObject = Random.Range(2, randomPointsFood.Count);

        randomPointsFood = Shuffle(randomPointsFood);



        for (int i = 0; i < countObject; i++)
        {
            Instantiate(food, randomPointsFood[i].transform.position, Quaternion.identity);
        }
    }

    private List<Transform> Shuffle(List<Transform> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }
}