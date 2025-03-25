using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent NavAgent;
    public float AttackRange = 2f;
    public float AttackSpeed = 1f;

    private AIState currentState;
    public AIState CurrentState => currentState;
    public Transform Target { get; private set; }

    private void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        ChangeState(new IdleState(this));
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(AIState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            Target = null;
            return;
        }

        Target = enemies.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).First().transform;
    }

    public void Die()
    {
        ChangeState(new DeadState(this));
    }
}
