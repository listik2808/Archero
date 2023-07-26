using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.State;
using Scripts.Logic;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, StartCountdown startCountdown)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, startCountdown,AllServices.Container);
        }
    }
}