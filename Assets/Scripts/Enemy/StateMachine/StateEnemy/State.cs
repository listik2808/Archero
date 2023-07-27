using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy.StateMachine.StateEnemy
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private Transition _transition;
        protected NavMeshAgent _agent;
        public Transition Transition => _transition;

        protected Transform Target { get; set; }
        public bool IsActive { get; private set; }

        private void Start()
        {
            _agent= GetComponent<NavMeshAgent>();
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

        public void SetPointTarget(Transform target)
        {
            Target = target;
        }

        private void TransitionState()
        {
            _transition.SetNextState();
        }
    }
}
