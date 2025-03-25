using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DeadState : AIState
{
    public DeadState(AIController ai) : base(ai) { }

    public override void Enter()
    {
        Debug.Log("����: Dead (���)");
        ai.NavAgent.isStopped = true;
        ai.gameObject.SetActive(false); // ������ ��Ȱ��ȭ
    }

    public override void Update() { }

    public override void Exit() { }
}
