using FSM;
using PatrolEnemy;
using UnityEngine;
using UnityEngine.AI;

namespace PatrolFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Chase")]
    public class ChaseAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var patrolSightSensor = stateMachine.GetComponent<PatrolSightSensor>();

            navMeshAgent.SetDestination(patrolSightSensor.Player.position);
        }
    }
}