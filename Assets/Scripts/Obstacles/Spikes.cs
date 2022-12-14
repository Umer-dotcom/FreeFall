using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float rotSpeed;

    private float x;

    void Update()
    {
        x += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(0, 0, x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            GameManager.instance.YouShouldRetry();
            collision.gameObject.SetActive(false);
            Debug.Log("Ball Destroyed!");
        }
    }
}
