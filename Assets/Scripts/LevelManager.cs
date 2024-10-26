using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;

    public GameObject deathScreen;

    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        manager = this;
    }

    public void GameOver()
    {
        deathScreen.SetActive(true);
    }

    // Update is called once per frame
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
