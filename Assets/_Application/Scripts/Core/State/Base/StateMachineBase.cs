using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBase<T> : MonoBehaviour where T : StateMachineBase<T>
{
    private StateBase<T> currentState;
    private StateBase<T> nextState;

    public bool ChangeState(StateBase<T> _nextState)
    {
        bool isRet = nextState == null;
        nextState = _nextState;
        return isRet;
    }

    private void Update()
    {
        if (nextState != null && currentState != null)
        {
            currentState.OnExitState();
        }

        if (nextState != null)
        {
            // OnEnterState実行中にChangeStateが呼びされたかを確認するための変数
            var tempNextState = nextState;

            currentState = nextState;
            currentState.OnEnterState();

            // 前行のOnEnterState呼び出し中にChangeState関数を実行すると変更後にあたるStateのOnEnterStateが呼び出されなくなる現象があるためIf文を追加している
            if (tempNextState == nextState)
            {
                StartCoroutine(currentState.OnCoEnterState());
                nextState = null;
            }
        }

        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }
}