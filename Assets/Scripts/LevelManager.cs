using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;

    public GameObject deathScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScoreText;

    public int score;
    private bool threshhold1 = false;
    private bool threshhold2 = false;

    [SerializeField] private List<EnemySpawner> enemySpawners;

    [SerializeField] private AudioController audioController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        manager = this;
    }

    public void Update ()
    {

        if ( !threshhold1 && score > 100)
        {
            threshhold1 = true;
            PlayerMovement.instance.evolve(1);
            foreach (EnemySpawner spawner in enemySpawners) {
                spawner.evolveEnemySpawns(1);
            }
            HealthBar.instance.setTimeToDrain(0.05f);
            audioController.PlayEvo2();

        }
        if (!threshhold2 && score > 300)
        {
            threshhold2 = true;
            PlayerMovement.instance.evolve(2);
            foreach (EnemySpawner spawner in enemySpawners)
            {
                spawner.evolveEnemySpawns(1);
            }
            HealthBar.instance.setTimeToDrain(0.03f);
            audioController.PlayEvo3();
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        audioController.PlayDeathSound();
        deathScreen.SetActive(true);
        Destroy(scoreText);
        deathScoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        audioController.PlayKillSound();
    }
}
