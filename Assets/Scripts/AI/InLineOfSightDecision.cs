using FSM;
using PatrolEnemy;
using Unity.VisualScripting;
using UnityEngine;
namespace PatrolFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/In Line Of Sight")]
    public class InLineOfSightDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var patrolSightSensor = stateMachine.GetComponent<PatrolSightSensor>();
            return patrolSightSensor.Ping();
        }
    }
}