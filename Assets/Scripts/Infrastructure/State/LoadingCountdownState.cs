using Scripts.Logic;

namespace Scripts.Infrastructure.State
{
    public class LoadingCountdownState : IState
    {
        private readonly StartCountdown _startCountdown;
        private GameStateMachine _gameStateMachine;
        public LoadingCountdownState(GameStateMachine gameStateMachine, StartCountdown startCountdown)
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