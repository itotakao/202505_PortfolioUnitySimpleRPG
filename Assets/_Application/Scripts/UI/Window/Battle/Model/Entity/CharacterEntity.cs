using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterEntity
{
    public struct EntityStruct
    {
        public int Id;
        public string CharacterName;
        public int Level;
        public int MaxExperience;
        public int Experience;
        public int Gold;
        public int MaxHealth;
        public int Health;
        public int Attack;
        public int Defence;
        public int Speed;
        public bool IsBoss;
    }

    public int Id = -1;
    public string CharacterName = "CharacterName";
    public int Level = 1;
    public int MaxExperience = 100;
    public int Experience = 0;
    public int Gold = 0;
    public int MaxHealth = 100;
    public int Health = 100;
    public int Attack = 1;
    public int Defence = 0;
    public int Speed = 1;
    public bool IsBoss = false;

    public CharacterEntity(EntityStruct entityStruct)
    {
        Id = entityStruct.Id;
        CharacterName = entityStruct.CharacterName;
        Level = entityStruct.Level;
        Experience = entityStruct.Experience;
        Gold = entityStruct.Gold;
        Health = entityStruct.Health;
        MaxHealth = entityStruct.Health;
        Attack = entityStruct.Attack;
        Defence = entityStruct.Defence;
        Speed = entityStruct.Speed;
        IsBoss = entityStruct.IsBoss;
    }

    public CharacterEntity(int id,string characterName,int level,int experience,int gold,int health,int attack,int defence,int speed,bool isBoss)
    {
        Id = id;
        CharacterName = characterName;
        Level = level;
        Experience = experience;
        Gold = gold;
        Health = health;
        MaxHealth = health;
        Attack = attack;
        Defence = defence;
        Speed = speed;
        IsBoss = isBoss;
    }
}
