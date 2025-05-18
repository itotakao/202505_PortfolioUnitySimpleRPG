using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDungeonSettingsTable", menuName = "CreateDungeonSettingsTable")]
public class DungeonSettingsTable : ScriptableObject
{
    public string DungeonName;
    public CharacterStatusTable[] EnemyDataList;
}