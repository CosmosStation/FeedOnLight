using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject enemyTarget;
    private NavMeshAgent NMAgent;

    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NMAgent.SetDestination(enemyTarget.transform.position);
    }
}
