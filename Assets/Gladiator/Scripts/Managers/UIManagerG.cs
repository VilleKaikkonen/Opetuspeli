using UnityEngine;
using System;
using TMPro;

/*
 Author: Antti Sironen
Handles UI elements in the game
 */

public class UIManagerG : MonoBehaviour
{
    public static UIManagerG Instance { get; private set; }


    //Enemy Data
    [Header("Enemy Data/Stats")]
    [SerializeField] CharacterDataSO enemyData;

    [Header("Enemy UI Elements")]
    [SerializeField] TMP_Text enemyHealthText;
    [SerializeField] TMP_Text enemyDamageText;
    [Space]
    [Space]

    //Player Data
    [Header("Player Data/Stats")]
    [SerializeField] CharacterDataSO playerData;

    [Header("Player UI Elements")]
    [SerializeField] TMP_Text playerHealthText;
    [SerializeField] TMP_Text playerDamageText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of UIManagerG found!" + Instance + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        CharacterData(playerData);
    }

    private void OnEnable()
    {
        PlayerDataG.OnHealthChanged += UpdateHealthText;
    }

    public void CharacterData(CharacterDataSO characterData)
    {
        this.playerData = characterData; //Set struct instance

        playerHealthText.text = "HEALTH: " + characterData.maxHealth.ToString();
        playerDamageText.text = "DAMAGE: " + characterData.dmg.ToString();
    }


    public void UpdateHealthText()
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = "HEALTH: " + PlayerDataG.Instance.CurrentHealth.ToString();
        }
    }
}
