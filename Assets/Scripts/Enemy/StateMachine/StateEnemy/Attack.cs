namespace Scripts.Enemy.StateMachine.StateEnemy
{
    public class Attack : State
    {
        private void Update()
        {
            if (IsActive && Target!= null)
            {
                _agent.destination = Target.position;
            }
        }
    }
}
