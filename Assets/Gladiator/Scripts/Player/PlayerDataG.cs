using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerDataG : MonoBehaviour
{

    [SerializeField] CharacterDataSO characterData;

    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text damageText;

    //[SerializeField] int _dmg;

    int currentHealth;
    int maxHealth = 10;



    private void Start()
    {
        maxHealth = characterData.health;
        currentHealth = maxHealth;

        //UpdateHealthText();

    
        CharacterData(characterData);
    }

    public void CharacterData(CharacterDataSO characterData) 
    {
        this.characterData = characterData; //Set struct instance

        healthText.text = "HEALTH: " + characterData.health.ToString();
        damageText.text = "DAMAGE: " + characterData.dmg.ToString();
    }
 

    private void UpdateHealthText()
    {
        throw new NotImplementedException();
    }
}
