using System.Collections;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPatrolPointIndex = 0;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;
    private float idleTime = 3f;
    private float idleTimer;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        idleTimer = idleTime;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer <= 0f)
            {
                animator.SetTrigger("StartPatrol");
                idleTimer = idleTime;
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Patrol"))
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
                navMeshAgent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
                animator.SetTrigger("StopPatrol");
            }
        }
    }
}