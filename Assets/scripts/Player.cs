using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public Text healthText;

    void Start()
    {
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthText();
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
