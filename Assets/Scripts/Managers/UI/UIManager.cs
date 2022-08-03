using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject MenuPanel;

    private GameObject pauseMenu;
    private GameObject winScreen;
    private GameObject loseScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        if(MenuPanel != null)
        {
            pauseMenu = MenuPanel.transform.Find("PauseMenu").gameObject;
            winScreen = MenuPanel.transform.Find("WinScreen").gameObject;
            loseScreen = MenuPanel.transform.Find("LoseScreen").gameObject;
        }
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        MenuPanel.SetActive(true);
        pauseMenu.SetActive(true);
    }

    public void ResumeTheGame()
    {
        pauseMenu.SetActive(false);
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowTheWinScreen()
    {
        MenuPanel.SetActive(true);
        winScreen.SetActive(true);
        ShowStars();
    }

    public void ShowStars()
    {
        int score = GameManager.instance.GetScore();

        if (score < 1)
            return;

        GameObject stars = null;
        if (score == 3)
        {
            stars = winScreen.transform.Find("Background").Find("ThreeStar").gameObject;
        }
        else if(score == 2)
        {
            stars = winScreen.transform.Find("Background").Find("TwoStar").gameObject;
        }
        else if(score == 1)
        {
            stars = winScreen.transform.Find("Background").Find("OneStar").gameObject;
        }

        if(stars)
            stars.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        MenuPanel.SetActive(true);
        loseScreen.SetActive(true);
    }

}
