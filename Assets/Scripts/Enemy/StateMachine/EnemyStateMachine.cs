using Scripts.Enemy.StateMachine.StateEnemy;
using UnityEngine;

namespace Scripts.Enemy.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _firstState;
        [SerializeField] private State _enemyMove;

        private State _activeState;

        public State Current => _activeState;

        private void OnEnable()
        {
            _activeState = _firstState;
        }

        private void Update()
        {
            if (_activeState == null)
                return;

            if(_firstState.Transition.NeedTransition)
            {
                Enter(_enemyMove);
                Exit(_firstState);
            }

            if (_enemyMove.Transition.NeedTransition)
            {

                Enter(_firstState);
                Exit(_enemyMove);
            }
        }

        private void Enter(State state)
        {
            
            _activeState = state;
            _activeState.ActivateState();
        }

        private void Exit(State state)
        {
            state.DeactivateState();
        }
    }
}
