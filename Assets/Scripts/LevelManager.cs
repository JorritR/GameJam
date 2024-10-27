using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;

    public GameObject deathScreen;

    public TextMeshProUGUI scoreText;

    public int score;
    private bool threshhold1 = false;
    private bool threshhold2 = false;

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
            EnemySpawner.Instance.evolveEnemySpawns(1);
            HealthBar.instance.setTimeToDrain(0.05f);
            audioController.PlayEvo2();

        }
        if (!threshhold2 && Input.GetButton("Jump"))
        {
            threshhold2 = true;
            PlayerMovement.instance.evolve(2);
            EnemySpawner.Instance.evolveEnemySpawns(2);
            HealthBar.instance.setTimeToDrain(0.01f);
            audioController.PlayEvo3();
        }
    }

    public void GameOver()
    {
        audioController.PlayDeathSound();
        deathScreen.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
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
