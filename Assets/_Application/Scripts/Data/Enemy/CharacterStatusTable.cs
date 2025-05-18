using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterStatus", menuName = "CreateCharacterStatusTable")]
public class CharacterStatusTable : ScriptableObject
{
    public bool IsBoss = false;
    public int Id = -1;
    public string CharacterName = "CharacterName";
    public int Level = 1;
    public int Experience = 0;
    public int Gold = 0;
    public int Health = 100;
    public int Attack = 1;
    public int Defence = 0;
    public int Speed = 1;
}