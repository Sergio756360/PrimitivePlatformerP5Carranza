using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Drag and drop the Text, TextMeshPro, or any UI GameObject (like a Canvas or Panel) in the Inspector
    public GameObject gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure the text starts disabled
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the "Player"
        if (other.CompareTag("Player"))
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Works similarly if you are using physical hard collisions instead of triggers
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
        }
    }
}
