using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveToEnemyState : AIState
{
    private Transform targetEnemy; // 타겟 적
    public MoveToEnemyState(AIController ai, Transform targetEnemy) : base(ai) {
        this.targetEnemy = targetEnemy;
    }

    public override void Enter()
    {
        Debug.Log("상태: MoveToEnemy (이동)");
        if (targetEnemy != null)
        {
            ai.NavAgent.SetDestination(targetEnemy.position);
        }
        
    }

    public override void Update()
    {
        if (ai.Target == null)
        {
            ai.ChangeState(new IdleState(ai));
            return;
        }

        if (Vector3.Distance(ai.transform.position, ai.Target.position) <= ai.AttackRange)
        {
            ai.ChangeState(new AttackState(ai));
        }
    }

    public override void Exit()
    {
        ai.NavAgent.ResetPath();
        ai.NavAgent.isStopped = true; // 이동 멈추기
    }
}
