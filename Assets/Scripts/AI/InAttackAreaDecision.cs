using FSM;
using PatrolEnemy;
using Unity.VisualScripting;
using UnityEngine;
namespace PatrolFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/In Attack Area Decision")]
    public class InAttackAreaDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var attackSightSensor = stateMachine.GetComponent<AttackSightSensor>();
            return attackSightSensor.Ping();
        }
    }
}