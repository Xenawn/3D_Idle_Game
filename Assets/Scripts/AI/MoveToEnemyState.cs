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
        if (Vector3.Distance(ai.transform.position, ai.Target.position) <= ai.AttackRange)
        {
            // 실제 공격 로직 구현
            PerformAttack();

            // 공격 후 다시 이동 상태로 돌아갈지 결정
            ai.ChangeState(new MoveToEnemyState(ai, ai.Target));
        }
        else
        {
            // 적이 공격 범위에서 벗어나면 이동 상태로 전환
            ai.ChangeState(new MoveToEnemyState(ai, ai.Target));
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
    private void PerformAttack()
    {
        // 실제 공격 로직 구현
        Debug.Log("적을 공격합니다!");

        // 예를 들어, 적에게 데미지를 주는 코드나 애니메이션 트리거 등을 추가할 수 있습니다.
        if (ai.Target != null)
        {
            // 타겟에게 데미지를 입히는 코드 예시
            Enemy enemyHealth = ai.Target.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(ai.AttackDamage);
            }
        }
    }
}
