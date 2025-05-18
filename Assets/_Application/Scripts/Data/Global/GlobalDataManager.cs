using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GlobalDataManager : MonoBehaviour
{
    public static GlobalDataManager Current { get; private set; }

    public PlayerDetail PlayerDetail => playerRepository.Detail;
    public List<DungeonSettingsTable> DungeonSettingsTables => dungeonSettingsTables;

    // TODO : ベタがきを修正する
    public int NextDugeonId = 0;

    [SerializeField]
    private List<DungeonSettingsTable> dungeonSettingsTables = new();

    private IPlayerRepository playerRepository;

    private void Awake()
    {
        Current = this;

        playerRepository = new PlayerRepository();
    }
}
