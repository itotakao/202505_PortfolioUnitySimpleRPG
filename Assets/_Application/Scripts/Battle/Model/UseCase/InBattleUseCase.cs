using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBattleUseCase
{
    public IEnemyRepository EnemyRepository => enemyRepository;

    private IEnemyRepository enemyRepository;

    public InBattleUseCase(int dungeonId)
    {
        enemyRepository = new EnemyRepository();
        enemyRepository.CreateEnemy(dungeonId);
    }

    /// <summary>
    /// 敵を攻撃した
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="damage"></param>
    /// <returns>死亡しているか</returns>
    public bool DamageToEnemy(EnemyDetail enemy,int damage)
    {
        enemy.Health.Value -= damage;
        var isDeath = (enemy.Health.Value <= 0);
        return isDeath;
    }

    /// <summary>
    /// 敵に攻撃された
    /// </summary>
    /// <param name="player"></param>
    /// <param name="damage"></param>
    /// <returns>死亡しているか</returns>
    public bool DamageToPlayer(PlayerDetail player,int damage)
    {
        player.Health.Value -= damage;
        var isDeath = (player.Health.Value <= 0);
        return isDeath;
    }

    public bool ExploreDungeon(int enemyCount)
    {
        return (enemyCount >= enemyRepository.Details.Count);
    }


    public void Result(PlayerDetail player,EnemyDetail enemy)
    {
        player.Gold.Value += enemy.Gold.Value;
        player.Experience.Value += enemy.Experience.Value;
        if(player.Experience.Value > player.MaxExperience.Value)
        {
            player.Experience.Value = 0;
            player.Level.Value += 1;
        }
    }
}
