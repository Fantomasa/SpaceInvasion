using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private static int healthPoints = 5;
    [SerializeField] private static int shieldPoints = 5;
    

    private static int currentHealth = 0;
    public static int currentShieldPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthPoints;
        currentShieldPoints = shieldPoints;
    }

    public static bool AddRemoveShieldPoints(int points)
    {
        int newPoints = currentShieldPoints + points;

        if (newPoints > shieldPoints) return false;

        if (newPoints < 0) return false;

        currentShieldPoints = newPoints;
        UpdateShieldPointsInShieldBar();

        return true;
    }

    private static void UpdateShieldPointsInShieldBar()
    {
        ShieldBar.SetShieldPoints(currentShieldPoints);
    }

    public static void AddRemoveHealth(int health)
    {
        int newHealth = currentHealth + health;

        if (newHealth > healthPoints)
        {
            return;
        }

        if (newHealth < 0)
        {
            GameOver();
            return;
        }

        currentHealth = newHealth;
        UpdateHealthInHealthBar();
    }

    public static void UpdateHealthInHealthBar()
    {
        HealthBar.SetHealth(currentHealth);
    }

    public static void GameOver()
    {
        RestartLevel();
    }

    public static void RestartLevel()
    {
        string currentLevelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentLevelName);
    }
}
