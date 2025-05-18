using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;

public class MainMenuView : MonoBehaviour
{
    public Text LevelValueText => levelValueText;
    public Slider ExperienceValueSlider => experienceValueSlider;
    public Text GoldValueText => goldValueText;
    public Text HealthValueText => healthValueText;
    public Text MeleeAttackValueText => meleeAttackValueText;
    public Text LongRangeAttackValueText => longRangeAttackValueText;
    public Text MagicAttackValueText => magicAttackValueText;
    public Text DefenceValueText => defenceValueText;
    public Text SpeedValueText => speedValueText;

    public Observable<Unit> GoBattleButton;
    public Observable<Unit> GoTimeSettingButton;
    public Observable<Unit> GoAchievementButton;
    public Observable<Unit> GoStatisticButton;
    public Observable<Unit> GoOptionButton;
    public Observable<Unit> GoHelpButton;
    public Observable<Unit> GoShopButton;
    public Observable<Unit> GoCreditButton;

    [Header("Header")]
    [SerializeField]
    private Text levelValueText;
    [SerializeField]
    private Slider experienceValueSlider;
    [SerializeField]
    private Text goldValueText;
    [SerializeField]
    private Text healthValueText;
    [SerializeField]
    private Text meleeAttackValueText;
    [SerializeField]
    private Text longRangeAttackValueText;
    [SerializeField]
    private Text magicAttackValueText;
    [SerializeField]
    private Text defenceValueText;
    [SerializeField]
    private Text speedValueText;


    [Header("Side")]
    [SerializeField]
    private Button goBattleButton;
    [SerializeField]
    private Button goTimeSettingButton;
    [SerializeField]
    private Button goAchievementButton;
    [SerializeField]
    private Button goStatisticButton;
    [SerializeField]
    private Button goOptionButton;
    [SerializeField]
    private Button goHelpButton;
    [SerializeField]
    private Button goShopButton;
    [SerializeField]
    private Button goCreditButton;

    private void Awake()
    {
        GoBattleButton = goBattleButton.OnClickAsObservable();
        GoTimeSettingButton = goTimeSettingButton.OnClickAsObservable();
        GoAchievementButton = goAchievementButton.OnClickAsObservable();
        GoStatisticButton = goStatisticButton.OnClickAsObservable();
        GoOptionButton = goOptionButton.OnClickAsObservable();
        GoHelpButton = goHelpButton.OnClickAsObservable();
        GoShopButton = goShopButton.OnClickAsObservable();
        GoCreditButton = goCreditButton.OnClickAsObservable();
    }
}
