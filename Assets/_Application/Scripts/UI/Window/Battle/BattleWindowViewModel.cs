using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindowViewModel : MonoBehaviour 
{
    [Header("Effect")]
    [SerializeField]
    private DamageEffect damageTextPrefab;

    public void SpawnDamageText(int damage, Vector2 spawnPoint)
    {
        var damageText = Instantiate(damageTextPrefab.gameObject).GetComponent<DamageEffect>();
        damageText.Initialize(damage, spawnPoint);
    }
}
