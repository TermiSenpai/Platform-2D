using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int healthPoints;

    private PlayerMovement movement;

    #region Unity Methods

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        healthPoints = maxHealth;
    }

    #endregion    

    #region Public Methods

    #region Getters
    public int GetHealth()
    {
        return healthPoints;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    #endregion

    public void loseHealth(int damage)
    {
        if (!movement.isGameOver())
        {
            healthPoints -= damage;
            Debug.Log("loseHP: " + healthPoints);
            DeadCheck();

        }
    }

    public void recoverHealt(int recover)
    {
        healthPoints += recover;

        if (healthPoints > maxHealth)
            SetHpToMax();
    }

    #endregion

    #region Private Methods
    private void SetHpToMax()
    {
        healthPoints = maxHealth;
    }

    private void DeadCheck()
    {
        if(healthPoints <= 0)
        {
            healthPoints = 0;
            Debug.Log("Player is dead");

            movement.SetGameOver();
        }
    }
    #endregion
}
