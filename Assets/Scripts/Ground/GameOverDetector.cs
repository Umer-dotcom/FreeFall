using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    [SerializeField] private int maxBouncesAllowed = 3;
    [SerializeField] private int currentBounces;
    [SerializeField] private float timeBeforeReset = 5f;
    public bool gameover = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if (gameover == false)
            {
                StopCoroutine(ResetTimer());
                currentBounces += 1;
                if (currentBounces >= maxBouncesAllowed)
                {
                    // Game lose , check retries
                    currentBounces = 0;
                    Debug.Log("Checking for retries");
                    GameManager.instance.YouShouldRetry();
                    return;
                }
                StartCoroutine(ResetTimer());
            }
        }
    }

    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(timeBeforeReset);
        currentBounces = 0;
    }
}
