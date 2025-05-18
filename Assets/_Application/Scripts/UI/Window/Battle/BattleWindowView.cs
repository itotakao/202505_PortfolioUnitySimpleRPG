using Cysharp.Threading.Tasks;
using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleWindowView : MonoBehaviour
{
    public Text EnemyUnitNameText => enemyUnitNameText;
    public Text EnemyUnitLevelText => enemyUnitLevelText;
    public Slider EnemyHealthBar => enemyHealthBar;

    public Text ScoreText => scoreText;


    [SerializeField]
    private Text enemyUnitNameText;
    [SerializeField]
    private Text enemyUnitLevelText;
    [SerializeField]
    private Slider enemyHealthBar;

    [SerializeField]
    private Image enemyImage;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image damageEffectImage;

    public void SetEnemy(bool isBoss)
    {
        enemyImage.rectTransform.localScale = (isBoss ? new Vector2(1.5f, 1.5f): new Vector2(1, 1));
    }

    public void SetScoreText(int value)
    {
        scoreText.text = value.ToString();
    }

    public async void PlayPlayerDamageEffectAsync()
    {
        for (int i = 0; i < 1; i++)
        {
            damageEffectImage.enabled = true;
            await UniTask.Delay(100);
            damageEffectImage.enabled = false;
            await UniTask.Delay(100);
        }
    }
}
