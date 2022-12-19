using FSM;
using UnityEngine.AI;

namespace AIFSM
{
    public class PatrolAction: FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            var patrolPoints = stateMachine.GetComponent<PatrolPoints>();

            if (patrolPoints.HasReached(patrolPoints))
                navMeshAgent.SetDestination(patrolPoints.GetNext().position);
        }
    }
}