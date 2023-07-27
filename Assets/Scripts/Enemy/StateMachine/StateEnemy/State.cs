using UnityEngine;

namespace Scripts.Enemy.StateMachine.StateEnemy
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private Transition _transition;

        public Transition Transition => _transition;

        protected Transform Target { get; set; }
        public bool IsActive { get; private set; }

        public void ActivateState()
        {
            IsActive = true;
        }

        public void DeactivateState()
        {
            IsActive = false;
            Transition.DiactivateTransition();
        }

        private void TransitionState()
        {
            _transition.SetNextState();
        }
    }
    public class EnemyMoveState : State
    {
        private void Update()
        {
            if(IsActive)
            {

            }
        }
    }
}
