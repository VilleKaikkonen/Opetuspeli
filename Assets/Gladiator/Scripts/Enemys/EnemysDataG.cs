using System;
using TMPro;
using UnityEngine;

public class EnemysDataG : MonoBehaviour, IDamageableG
{
    public static EnemysDataG Instance { get; private set; } // Singleton

    //Events
    public static event Action OnEnemyHealthChanged; // update health value

    [Header("Enemy Data/Stats")]
    [SerializeField] CharacterDataSO characterData;

    [Header("Enemy Prefab")]
    [SerializeField] GameObject enemy;


    //Health
    public int currentHealth { get; set; }
    public int maxHealth { get; set; }

    public int CurrentHealth
    {
        get => currentHealth;

        private set
        {
            if (currentHealth != value)
            {
                currentHealth = Mathf.Clamp(value, 0, characterData.maxHealth);
                OnEnemyHealthChanged?.Invoke(); // update health value
            }
        }
    }

    public int Damage //later we can use this to set the damage of the enemy
    {
        get => characterData.dmg;

        private set
        {
            if (characterData.dmg != value)
            {
                characterData.dmg = Mathf.Clamp(value, 0, characterData.dmg);
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of EnemysDataG found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        CurrentHealth = characterData.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        //Update healt ui;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;

            Die();
        }
    }

    private void Die()
    {
        enemy.SetActive(false); //Disable enemy
    }
}
