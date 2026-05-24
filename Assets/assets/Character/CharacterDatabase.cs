using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{

    public CharacterSO[] characters;

    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }

    public CharacterSO GetCharacter(int index)
    {
        return characters[index];
    }
    
}
