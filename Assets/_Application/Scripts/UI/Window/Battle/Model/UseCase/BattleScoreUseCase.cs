using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScoreUseCase
{
    public ReactiveProperty<int> Score;

    public BattleScoreUseCase()
    {
        Score = new ReactiveProperty<int>(0);
    }

    public void AddScore(int score)
    {
        Score.Value += score;
    }
}
