using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetail
{
    public int Id => _entity.Id;
    public bool IsBoss => _entity.IsBoss;
    public ReactiveProperty<string> Name;
    public ReactiveProperty<int> Level;
    public ReactiveProperty<int> Experience;
    public ReactiveProperty<int> Gold;
    public ReactiveProperty<int> MaxHealth;
    public ReactiveProperty<int> Health;
    public ReactiveProperty<int> Attack;
    public ReactiveProperty<int> Defence;
    public ReactiveProperty<int> Speed;

    private CharacterEntity _entity;

    public EnemyDetail(CharacterEntity entity)
    {
        _entity = entity;
        Name = new ReactiveProperty<string>(entity.CharacterName);
        Level = new ReactiveProperty<int>(entity.Level);
        Experience = new ReactiveProperty<int>(entity.Experience);
        Gold = new ReactiveProperty<int>(entity.Gold);
        MaxHealth = new ReactiveProperty<int>(entity.MaxHealth);
        Health = new ReactiveProperty<int>(entity.Health);
        Attack = new ReactiveProperty<int>(entity.Attack);
        Defence = new ReactiveProperty<int>(entity.Defence);
        Speed = new ReactiveProperty<int>(entity.Speed);
    }
}
