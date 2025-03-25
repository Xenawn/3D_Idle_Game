using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{
    public AttackState(AIController ai) : base(ai) { }

    public override void Enter()
    {
        Debug.Log("상태: Attack (공격)");
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

            Debug.Log($"공격! {ai.Target.name}");
            // 여기에 적 체력 감소 로직 추가 가능
            yield return new WaitForSeconds(ai.AttackSpeed);
        }
    }
}
