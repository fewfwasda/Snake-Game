using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pause;
    public void ClosePause()
    {
        Time.timeScale = 1;
        LeanTween.moveY(pause, -16, 0.4f).setOnComplete(StartPositionPause);
    }
    private void StartPositionPause()
    {
        pause.transform.localPosition = new Vector3(-8, 0, 5.5f);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
