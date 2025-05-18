using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindowPresenter : WindowBase<BattleWindowPresenter>
{
    public static BattleWindowPresenter Current;

    private GlobalDataManager GlobalDataManager => GlobalDataManager.Current;

    public List<EnemyDetail> EnemyDetails => enemyRepository.Details;

    [SerializeField]
    private BattleWindowView view;
    [SerializeField]
    private BattleWindowViewModel viewModel;

    private IEnemyRepository enemyRepository;
    private BattleScoreUseCase battleScoreUseCase;

    private void Awake()
    {
        Current = this;
    }

    private void Start()
    {
        enemyRepository = new EnemyRepository();
        battleScoreUseCase = new BattleScoreUseCase();

        battleScoreUseCase.Score.Subscribe(v =>
        {
            view.ScoreText.text = $"{v}";
            GlobalDataManager.PlayerDetail.Gold.Value = v;
        }).AddTo(this);
    }

    public void SetEnemy(EnemyDetail enemy)
    {
        enemy.Name.Subscribe(n => view.EnemyUnitNameText.text = n).AddTo(this);
        enemy.Level.Subscribe(v => view.EnemyUnitLevelText.text = $"Lv.{v}").AddTo(this);
        enemy.MaxHealth.Subscribe(v => view.EnemyHealthBar.maxValue = v).AddTo(this);
        enemy.Health.Subscribe(v => view.EnemyHealthBar.value = v).AddTo(this);
        view.SetEnemy(enemy.IsBoss);
    }

    public void DamageToEnemy(int damage)
    {
        viewModel.SpawnDamageText(damage, new Vector3(-30, 0, 0));
    }

    public void DamageToPlayer(int damage)
    {
        viewModel.SpawnDamageText(damage, new Vector3(-30, -100, 0));
        view.PlayPlayerDamageEffectAsync();
    }

    public void SetScore(int value)
    {
        view.SetScoreText(value);
    }
}
