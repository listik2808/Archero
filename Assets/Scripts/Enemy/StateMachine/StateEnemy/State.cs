using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy.StateMachine.StateEnemy
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private Transition _transition;
        [SerializeField] protected Enemy _enemy;
        protected NavMeshAgent _agent;
        protected float _timeStop;
        public Transition Transition => _transition;

        protected Transform Target { get; set; }
        public bool IsActive { get; private set; }

        private void Start()
        {
            _agent= GetComponent<NavMeshAgent>();
            _agent.speed = _enemy.SpeedMovement;
        }

        public void ActivateState()
        {
            IsActive = true;
        }

        public void DeactivateState()
        {
            IsActive = false;
            Transition.DiactivateTransition();
        }

        public void SetTarget()
        {
            Target = _enemy.Target.transform;
        }

        private void TransitionState()
        {
            _transition.SetNextState();
        }
    }
}
