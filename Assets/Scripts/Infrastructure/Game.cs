using Scripts.Logic;
using Scripts.Services.Input;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, StartCountdown startCountdown)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, startCountdown);
        }
    }
}