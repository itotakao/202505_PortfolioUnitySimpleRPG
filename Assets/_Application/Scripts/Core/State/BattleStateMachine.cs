using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStateMachine : StateMachineBase<BattleStateMachine>
{
    private GlobalDataManager GlobalDataManager => GlobalDataManager.Current;
    private BattleWindowPresenter BattleWindowPresenter => BattleWindowPresenter.Current;

    private int enemyCount = 0;
    private InBattleUseCase inBattleUseCase;
    private EnemyDetail spawnEnemy;

    void Start()
    {
        ChangeState(new BattleStateMachine.Initialize(this));
    }

    private class Initialize : StateBase<BattleStateMachine>
    {
        public Initialize(BattleStateMachine _machine) : base(_machine)
        {
            machine.enemyCount = 0;
            machine.GlobalDataManager.PlayerDetail.Health.Value = machine.GlobalDataManager.PlayerDetail.MaxHealth.Value;
            var dungeonId = machine.GlobalDataManager.NextDugeonId;
            machine.inBattleUseCase = new InBattleUseCase(dungeonId);
        }

        public override void OnEnterState()
        {
            base.OnEnterState();

            machine.ChangeState(new BattleStateMachine.Spawn(machine));
        }
    }

    private class Spawn : StateBase<BattleStateMachine>
    {
        public Spawn(BattleStateMachine _machine) : base(_machine)
        {
            var spawnEnemyId = machine.enemyCount;
            machine.spawnEnemy = machine.inBattleUseCase.EnemyRepository.Details[spawnEnemyId];
            machine.BattleWindowPresenter.SetEnemy(machine.spawnEnemy);
        }

        public override void OnEnterState()
        {
            base.OnEnterState();

            machine.ChangeState(new BattleStateMachine.Battle(machine));
        }
    }


    private class Battle : StateBase<BattleStateMachine>
    {
        public Battle(BattleStateMachine _machine) : base(_machine)
        {
            // Do Nothing
        }

        public override IEnumerator OnCoEnterState()
        {
            base.OnCoEnterState();

            // 自分、敵のどちらかが瀕死になるまでループ
            float waitTime = 1.0f;
            while (true)
            {
                yield return new WaitForSeconds(waitTime);

                // プレイヤー攻撃
                var playerAttack = machine.GlobalDataManager.PlayerDetail.Attack.Value;
                var isDyingEnemy = machine.inBattleUseCase.DamageToEnemy(machine.spawnEnemy,playerAttack);
                machine.BattleWindowPresenter.DamageToEnemy(playerAttack);

                if (isDyingEnemy)
                {
                    break;
                }

                yield return new WaitForSeconds(waitTime);

                // 敵攻撃
                var enemyAttack = machine.spawnEnemy.Attack.Value;
                var isDyingPlayer = machine.inBattleUseCase.DamageToPlayer(machine.GlobalDataManager.PlayerDetail,enemyAttack);
                machine.BattleWindowPresenter.DamageToPlayer(enemyAttack);

                if (isDyingPlayer)
                {
                    break;
                }
            }

            machine.ChangeState(new BattleStateMachine.Result(machine));
        }
    }

    private class Result : StateBase<BattleStateMachine>
    {
        public Result(BattleStateMachine _machine) : base(_machine)
        {
            machine.enemyCount++;

            var p = machine.GlobalDataManager.PlayerDetail;
            var e = machine.spawnEnemy;
            var isAlive = (machine.GlobalDataManager.PlayerDetail.Health.Value > 0);
            if (isAlive)
            {
                machine.inBattleUseCase.Result(p, e);
            }
            machine.BattleWindowPresenter.SetScore(p.Gold.Value);
        }

        public override IEnumerator OnCoEnterState()
        {
            base.OnCoEnterState();

            yield return new WaitForSeconds(1);

            var isDeath = (machine.GlobalDataManager.PlayerDetail.Health.Value <= 0);
            var isExplore = machine.inBattleUseCase.ExploreDungeon(machine.enemyCount);

            if (isDeath && isExplore)
            {
                machine.ChangeState(new BattleStateMachine.Initialize(machine));
            }
            else
            {
                machine.ChangeState(new BattleStateMachine.Spawn(machine));
            }
        }
    }

}
