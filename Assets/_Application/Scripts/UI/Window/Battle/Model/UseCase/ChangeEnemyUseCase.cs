using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyUseCase
{
    private IEnemyRepository enemyRepository;

    public ChangeEnemyUseCase(IEnemyRepository _enemyRepository)
    {
        enemyRepository = _enemyRepository;
    }
    
    public void Run(int characterId)
    {
        var entity = enemyRepository.GetById(characterId);
    }
}
