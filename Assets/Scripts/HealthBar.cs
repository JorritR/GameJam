using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    private float timeToDrain = 0.1f;
    private float healthDrainTimer = -3f;
    private GameObject player;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        healthDrainTimer += Time.deltaTime;

        if (healthDrainTimer >= timeToDrain)
        {
            takeDamage(0.1f);
            healthDrainTimer = 0f;
        }

        if (player == null)
        {
            health = 0;
        }

        if (player != null && health <= 0)
        {
            LevelManager.manager.GameOver();
            Destroy(player);
            PlayerMovement.instance.playerAlive = false;
        }

    }

    public void setTimeToDrain(float newTimeToDrain)
    {
        timeToDrain = newTimeToDrain;
    }

    public void restoreHealth(float restored)
    {
        health += restored;
    }
    public void takeDamage(float damage)
    {
        health -= damage;   
    }
}
