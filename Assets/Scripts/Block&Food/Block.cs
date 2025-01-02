using System.Collections;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int valueBlock;
    private SnakeTail snakeTail;
    public TextMeshPro PointsText;
    public ParticleSystem particle;
    private SpriteRenderer spriteRenderer;
    private Colors colors;
    private Color col;
    private bool isSnake;

    private SpawnManager spawnManager;

    private AudioSource removeEffect;

    void Start()
    {

        removeEffect = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        Glow();

        snakeTail = GameObject.FindWithTag("Snake").GetComponent<SnakeTail>();

        spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();

        valueBlock = Random.Range(spawnManager.minValueBlock, spawnManager.maxValuelBlock);
        PointsText.SetText(valueBlock.ToString());
        Destroy(gameObject, 9f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            isSnake = true;
            RemoveValueBlock();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            isSnake = false;
        }
    }

    private void RemoveValueBlock()
    {
        if (isSnake)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        while (isSnake)
        {
            removeEffect.Play();
            valueBlock--;
            PointsText.SetText(valueBlock.ToString());
            snakeTail.RemoveCircle();


            if (valueBlock == 0)
            {
                Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.1f);

            if (isSnake == false) break;
        }
    }
    private void Glow()
    {
        spriteRenderer.color = Colors.colors[Random.Range(0, Colors.colors.Count)];
    }
}