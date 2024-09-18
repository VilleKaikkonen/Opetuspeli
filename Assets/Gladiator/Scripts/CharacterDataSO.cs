using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newCharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterDataSO : ScriptableObject
{
    public int health;
    public int dmg;

    public Sprite healthBar;
    public Sprite characterImage;

    public CharacterDataSO(int health, int dmg)
    {
        this.health = health;
        this.dmg = dmg;
    }
}
