using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameOverDetector GOD;

    [SerializeField] private GameObject ConfettiPS;
    [SerializeField] private GameObject FireworksPS;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector2 ballStartPos;

    [SerializeField] private GameObject keyObjPrefab;
    [SerializeField] private Vector2 keyStartPos;

    [SerializeField] private int total_retries = 3;
    [SerializeField] private int retries_left;

    [SerializeField] private int score;

    [SerializeField] private bool itIsGoal;
    [SerializeField] private bool gameEnded;

    [SerializeField] private float timeBeforeRetry = 3f;
    [SerializeField] private float timeBeforePopUp = 3f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        retries_left = 0;
    }

    private void Start()
    {
        if(ballPrefab)
            ballStartPos = ballPrefab.transform.position;
        if (keyObjPrefab)
            keyStartPos = keyObjPrefab.transform.position;
    }

    private void Update()
    {
        
    }

    public void IncrementScore()
    {
        score += 1;
        UIManager.instance.UpdateCounts();
    }

    public void GoalIsMade()
    {
        itIsGoal = true;
        Debug.Log("Goal is made");
        YouWon();
    }

    private void YouWon()
    {
        if(itIsGoal)
        {
            if(gameEnded == false)
            {
                gameEnded = true;
                Debug.Log("YOU WON!");
                AudioManager.instance.Play("Goal");
                GOD.gameover = true;
                // Camera shake
                Instantiate(ConfettiPS);
                Instantiate(FireworksPS);
                // You won screen
                StartCoroutine(DelayBeforeWinScreenShowUp());
                // Stop all nonsense scripts
            }
        }
    }

    public void YouLose()
    {
        if (gameEnded == false && itIsGoal == false)
        {
            gameEnded = true;
            AudioManager.instance.Play("Lose");
            Debug.Log("YOU LOSE");
            StartCoroutine(DelayBeforeLoseScreenShowUp());
            // Play sad sound
            // Lose Screen
            // Stop all nonesense scripts
        }
    }

    public void YouShouldRetry()
    {
        retries_left += 1;
        GOD.gameover = true;
        if (retries_left >= total_retries)
        {
            YouLose();
        }
        else
        {
            Debug.Log("Starting Coroutine");
            StartCoroutine(Delay());
            UIManager.instance.UpdateCounts();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetRetriesLeft()
    {
        return total_retries - retries_left;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(timeBeforeRetry);
        ballPrefab.transform.position = ballStartPos;
        GOD.gameover = false;
        itIsGoal = false;
        keyObjPrefab.transform.position = keyStartPos;
    }

    IEnumerator DelayBeforeWinScreenShowUp()
    {
        yield return new WaitForSeconds(timeBeforePopUp);
        UIManager.instance.ShowTheWinScreen();
    }

    IEnumerator DelayBeforeLoseScreenShowUp()
    {
        yield return new WaitForSeconds(timeBeforePopUp);
        UIManager.instance.ShowLoseScreen();
    }
}
