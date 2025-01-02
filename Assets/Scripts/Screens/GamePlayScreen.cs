using UnityEngine.UI;
using UnityEngine;

public class GamePlayScreen : MonoBehaviour
{
    public Text scoreText;
    public GameObject pause;
    public Transform player;
    void Update()
    {
        scoreText.text = player.position.y.ToString("0");
    }
    public void OpenPause()
    {
        LeanTween.moveX(pause, 0, 0.4f);
        Invoke("StopGame", 0.4f);
    }
    private void StopGame()
    {
        Time.timeScale = 0;
    }
}
