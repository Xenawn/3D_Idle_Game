using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DeadState : AIState
{
    public DeadState(AIController ai) : base(ai) { }

    public override void Enter()
    {
        Debug.Log("상태: Dead (사망)");
        ai.NavAgent.isStopped = true;
        ai.gameObject.SetActive(false); // 죽으면 비활성화
    }

    public override void Update() { }

    public override void Exit() { }
}
