using UnityEngine;
using System.Collections.Generic;
using System.Collections;


[CreateAssetMenu(fileName = "Character", menuName = "Characters/Character")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    
    public GameObject characterRigged;
    
}
