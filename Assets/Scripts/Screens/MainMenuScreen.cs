using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject setting;
    void Start()
    {
        AnimationButton();
    }
    private void AnimationButton()
    {
        foreach (var item in buttons)
        {
            LeanTween.moveX(item, 2.3f, 0.5f);
        }
    }
    public void Setting()
    {
        LeanTween.moveY(setting, 0, 0.4f);
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
