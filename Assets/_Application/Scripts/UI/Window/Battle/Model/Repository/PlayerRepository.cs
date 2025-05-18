using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerRepository
{
    public PlayerDetail Detail { get; }
}

public class PlayerRepository : IPlayerRepository
{
    public PlayerDetail Detail => _entityDetail;

    private PlayerDetail _entityDetail;

    public PlayerRepository()
    {
        var entityStruct = LoadSaveData();
        var entity = new CharacterEntity(entityStruct);
        _entityDetail = new PlayerDetail(entity);
    }

    public CharacterEntity.EntityStruct LoadSaveData()
    {
        var s = new CharacterEntity.EntityStruct();

        // TODO : セーブデータから読み込むようにする
        s.Id = 0;
        s.CharacterName = "勇者俺";
        s.Level = 1;
        s.Experience = 0;
        s.Gold = 100;
        s.MaxHealth = 100;
        s.Health = 100;
        s.Attack = 2;
        s.Defence = 0;
        s.Speed = 5;
        s.IsBoss = false;

        return s;
    }
}
