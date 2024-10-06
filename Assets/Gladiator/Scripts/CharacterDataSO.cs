using UnityEngine;

/*
 Author: Antti Sironen
CharacterDataSO is a ScriptableObject that holds data for characters and enemies.
 */

[CreateAssetMenu(fileName = "newCharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterDataSO : ScriptableObject
{
    public int maxHealth;

    public int dmg;

    public Sprite healthBar;
    public Sprite characterImage;

    // public GameObject characterPrefab;
    // public GameObject healthBarPrefab;

    //public Color characterColor; // different color for each character/enemys
    //public Color healthBarColor;
    //public Color healthTextColor;

    public CharacterDataSO(int health, int dmg)
    {
        this.maxHealth = health;
        this.dmg = dmg;
    }
}
