using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    public AttackState(AIController ai) : base(ai) { }

    public override void Enter()
    {
        Debug.Log("����: Attack (����)");
        ai.StartCoroutine(AttackRoutine());
    }

    public override void Update() { }

    public override void Exit() { }

    private IEnumerator AttackRoutine()
    {
        while (ai.CurrentState is AttackState)
        {
            if (ai.Target == null)
            {
                ai.ChangeState(new IdleState(ai));
                yield break;
            }

            Debug.Log($"����! {ai.Target.name}");
            // ���⿡ �� ü�� ���� ���� �߰� ����
            yield return new WaitForSeconds(ai.AttackSpeed);
        }
    }
}
