using Scripts.Logic;
using System.Diagnostics;

namespace Scripts.Infrastructure
{
    public class LoadingCountdown : IState
    {
        private readonly StartCountdown _startCountdown;
        private GameStateMachine _gameStateMachine;
        public LoadingCountdown(GameStateMachine gameStateMachine, StartCountdown startCountdown)
        {
            _gameStateMachine = gameStateMachine;
            _startCountdown = startCountdown;
        }

        public void Enter()
        {
            _startCountdown.Show();
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }
    }
}