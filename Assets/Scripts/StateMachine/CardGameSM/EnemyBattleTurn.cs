using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBattleTurn : CardGameState
{
    [SerializeField] float _pauseDuration = 1.5f;

    public static event Action EnemyBattleTurnStart;
    public static event Action EnemyBattleTurnEnd;

    public override void Enter()
    {
        Debug.Log("Enemy Battle Turn... Entering");
        EnemyBattleTurnStart?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    /*
    public override void Tick()
    {
        
    }
    */

    public override void Exit()
    {
        Debug.Log("Enemy Battle Turn Exiting...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        EnemyBattleTurnEnd?.Invoke();
        //turn over. go back to player
        StateMachine.ChangeState<PlayerBattleTurn>();
    }
}
