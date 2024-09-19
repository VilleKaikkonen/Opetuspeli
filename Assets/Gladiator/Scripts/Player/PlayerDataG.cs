using UnityEngine;
using System;

public class PlayerDataG : MonoBehaviour, IDamageableG
{
    public static PlayerDataG Instance { get; private set; } // Singleton

    //Events
    public static event Action OnHealthChanged; // update health value

    [Header("Player Data/Stats")]
    [SerializeField] CharacterDataSO characterData;

    [SerializeField] GameObject player;

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
                OnHealthChanged?.Invoke(); // update health value
            }
        }
    }

    public int Damage 
    { 
        get => characterData.dmg;

        private set
        {
           if(characterData.dmg != value)
           {
               characterData.dmg = Mathf.Clamp(value, 0 , characterData.dmg);
           }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerDataG found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    private void Start()
    {
        CurrentHealth = characterData.maxHealth;

        //UpdateHealthText();

    
        //CharacterData(characterData); //Set struct instance, get data from CharacterDataSO
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
            Debug.Log("Player took damage");
        }
    }

    //public void CharacterData(CharacterDataSO characterData) 
    //{
    //    this.characterData = characterData; //Set struct instance

    //    healthText.text = "HEALTH: " + characterData.maxHealth.ToString();
    //    damageText.text = "DAMAGE: " + characterData.dmg.ToString();
    //}
 

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        //Update healt ui;

        if(CurrentHealth <= 0)
        {
           CurrentHealth = 0;

           Die();
        }
    }

    private void Die()
    {
        player.SetActive(false); //Disable player
    }
}
