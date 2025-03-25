using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveToEnemyState : AIState
{
    private Transform targetEnemy; // Ÿ�� ��
    public MoveToEnemyState(AIController ai, Transform targetEnemy) : base(ai) {
        this.targetEnemy = targetEnemy;
    }

    public override void Enter()
    {
        Debug.Log("����: MoveToEnemy (�̵�)");
        if (targetEnemy != null)
        {
            ai.NavAgent.SetDestination(targetEnemy.position);
        }
        if (Vector3.Distance(ai.transform.position, ai.Target.position) <= ai.AttackRange)
        {
            // ���� ���� ���� ����
            PerformAttack();

            // ���� �� �ٽ� �̵� ���·� ���ư��� ����
            ai.ChangeState(new MoveToEnemyState(ai, ai.Target));
        }
        else
        {
            // ���� ���� �������� ����� �̵� ���·� ��ȯ
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
        ai.NavAgent.isStopped = true; // �̵� ���߱�
    }
    private void PerformAttack()
    {
        // ���� ���� ���� ����
        Debug.Log("���� �����մϴ�!");

        // ���� ���, ������ �������� �ִ� �ڵ峪 �ִϸ��̼� Ʈ���� ���� �߰��� �� �ֽ��ϴ�.
        if (ai.Target != null)
        {
            // Ÿ�ٿ��� �������� ������ �ڵ� ����
            Enemy enemyHealth = ai.Target.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(ai.AttackDamage);
            }
        }
    }
}
