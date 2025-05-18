using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPresenter : MonoBehaviour
{
    public GlobalDataManager GlobalDataManager => GlobalDataManager.Current;
    public WindowManager WindowManager => WindowManager.Current;

    [SerializeField]
    private MainMenuView mainMenuView;

    private void Start()
    {
        GlobalDataManager.PlayerDetail.Level.Subscribe(v => mainMenuView.LevelValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.MaxExperience.Subscribe(v => UpdateExperienceValueSlider()).AddTo(this);
        GlobalDataManager.PlayerDetail.Experience.Subscribe(v => UpdateExperienceValueSlider()).AddTo(this);
        GlobalDataManager.PlayerDetail.Gold.Subscribe(v => mainMenuView.GoldValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.Health.Subscribe(v => mainMenuView.HealthValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.Attack.Subscribe(v => mainMenuView.MeleeAttackValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.Attack.Subscribe(v => mainMenuView.MeleeAttackValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.Attack.Subscribe(v => mainMenuView.MeleeAttackValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.Defence.Subscribe(v => mainMenuView.DefenceValueText.text = $"{v}").AddTo(this);
        GlobalDataManager.PlayerDetail.Speed.Subscribe(v => mainMenuView.SpeedValueText.text = $"{v}").AddTo(this);

        mainMenuView.GoBattleButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Battle)).AddTo(this);
        mainMenuView.GoTimeSettingButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Time)).AddTo(this);
        mainMenuView.GoAchievementButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Achievement)).AddTo(this);
        mainMenuView.GoStatisticButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Statistic)).AddTo(this);
        mainMenuView.GoOptionButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Option)).AddTo(this);
        mainMenuView.GoHelpButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Help)).AddTo(this);
        mainMenuView.GoShopButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Shop)).AddTo(this);
        mainMenuView.GoCreditButton.Subscribe(_ => WindowManager.ShowWindow(EWindowType.Credit)).AddTo(this);

        void UpdateExperienceValueSlider()
        {
            mainMenuView.ExperienceValueSlider.maxValue = GlobalDataManager.PlayerDetail.MaxExperience.Value;
            mainMenuView.ExperienceValueSlider.value = GlobalDataManager.PlayerDetail.Experience.Value;
        }
    }
}
