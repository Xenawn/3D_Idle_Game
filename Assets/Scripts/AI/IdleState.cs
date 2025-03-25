using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIState
{
    protected AIController ai;

    public AIState(AIController ai)
    {
        this.ai = ai;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
public class IdleState : AIState
{
    private float searchRadius = 5f; // 탐색 범위 증가
    private float moveRadius = 3f;    // 랜덤 이동 반경
    private Transform player;
    private LayerMask enemyLayer;

    public IdleState(AIController ai) : base(ai)
    {
        this.player = ai.transform;
        this.enemyLayer = LayerMask.GetMask("Enemy"); // 적 레이어 ("Enemy" 태그 설정 필수)
    }

    public override void Enter()
    {
        Debug.Log("상태: Idle (대기)");
        ai.StartCoroutine(SearchForEnemy());
    }

    public override void Update() { }

    public override void Exit() { }

    private IEnumerator SearchForEnemy()
    {
        while (true)
        {
            Collider[] enemies = Physics.OverlapSphere(player.position, searchRadius, enemyLayer);

            if (enemies.Length > 0)
            {
                Transform closestEnemy = FindClosestEnemy(enemies);
                if (closestEnemy != null)
                {
                    ai.ChangeState(new MoveToEnemyState(ai, closestEnemy));
                    yield break;
                }
            }

            // **랜덤으로 이동하면서 탐색**
            Vector3 randomPoint = GetRandomPointNear(player.position, moveRadius);
            ai.NavAgent.SetDestination(randomPoint);

            yield return new WaitForSeconds(2f); // 2초마다 탐색
        }
    }

    private Transform FindClosestEnemy(Collider[] enemies)
    {
        Transform closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider enemy in enemies)
        {
            float distance = Vector3.Distance(player.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }

    private Vector3 GetRandomPointNear(Vector3 origin, float radius)
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        Vector3 randomPoint = new Vector3(origin.x + randomCircle.x, origin.y, origin.z + randomCircle.y);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return origin;
    }
}