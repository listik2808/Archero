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
        [SerializeField] private Enemy _enemy;

        private State _activeState;
        private Player _player;

        private void OnEnable()
        {
            _activeState = _firstState;
            _activeState.ActivateState();
        }

        void Start()
        {
            _firstState.SetPointTarget(_enemy.Target.transform);
            _enemyMove.SetPointTarget(_enemy.Target.transform);
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
