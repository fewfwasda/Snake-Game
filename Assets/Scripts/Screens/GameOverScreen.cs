using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Transform player;
    public CanvasGroup canvasGroup;
    public GameObject gamePlayUI;
    private float score;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        scoreText.text = player.position.y.ToString("0");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        scoreText.text = player.position.y.ToString("0");
    }
    public void StartGameOverScreen()
    {
        canvasGroup.blocksRaycasts = enabled;
        gamePlayUI.SetActive(false);
        Invoke("StopGame", 2f);        

        LeanTween.alphaCanvas(canvasGroup, 1f, 1f);
    }
    private void StopGame()
    {
        Time.timeScale = 0;
    }
}
