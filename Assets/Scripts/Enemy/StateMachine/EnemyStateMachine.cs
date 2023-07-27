using Scripts.Enemy.StateMachine.StateEnemy;
using Scripts.Hero;
using UnityEngine;

namespace Scripts.Enemy.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _firstState;
        [SerializeField] private State _enemyMove;

        private State _activeState;
        private Player _player;

        private void OnEnable()
        {
            _activeState = _firstState;
            _activeState.ActivateState();
        }

        void Start()
        {
            _firstState.SetTarget();
            _enemyMove.SetTarget();
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

        public void SetTarget(Player player)
        {
            _player = player;
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
