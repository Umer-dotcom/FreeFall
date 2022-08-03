using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [SerializeField] private int totalScenes;
    [SerializeField] private int playerLeftAtLevel;

    private void Awake()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("FreeFall_Data"))
        {
            playerLeftAtLevel = PlayerPrefs.GetInt("FreeFall_Data");
        }
        else
        {
            playerLeftAtLevel = 1;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartCurrentScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToNextScene()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;

        if(currScene + 1 > totalScenes)
        {
            GoToMainMenu();
        }
        else
        {
            SceneManager.LoadSceneAsync(currScene + 1);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ResumeGameWhereLeftOff()
    {
        if (playerLeftAtLevel > totalScenes)
            GoToMainMenu();
        else
        {
            SceneManager.LoadSceneAsync(playerLeftAtLevel);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SavePlayerLevelData()
    {
        playerLeftAtLevel += 1;
        PlayerPrefs.SetInt("FreeFall_Data", playerLeftAtLevel);
    }

}