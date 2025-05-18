using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IEnemyRepository
{
    public List<EnemyDetail> Details { get; }
    CharacterEntity GetById(int id);
    void CreateEnemy(int dungeonId);
}

public class EnemyRepository : IEnemyRepository
{
    private GlobalDataManager GlobalDataManager => GlobalDataManager.Current;

    public List <EnemyDetail> Details => _details;
    private List<EnemyDetail> _details;
    private List<CharacterEntity> _entities;

    public EnemyRepository()
    {
        _entities = new List<CharacterEntity>();
        _details = new List<EnemyDetail>();
    }

    public void CreateEnemy(int dungeonId)
    {
        // ScriptableObjectを読み込む
        var enemys = GlobalDataManager.DungeonSettingsTables[dungeonId].EnemyDataList;
        // ScriptableObjectを元にEntityを生成
        foreach (var e in enemys)
        {
            var entity = new CharacterEntity(e.Id, e.CharacterName, e.Level, e.Experience, e.Gold, e.Health, e.Attack, e.Defence, e.Speed, e.IsBoss);
            AddCharacter(entity);
        }

        void AddCharacter(CharacterEntity newCharacter)
        {
            _entities.Add(newCharacter);
            _details.Add(new EnemyDetail(newCharacter));
        }
    }

    public CharacterEntity GetById(int id)
    {
        return _entities.FirstOrDefault(c => c.Id == id);
    }
}
