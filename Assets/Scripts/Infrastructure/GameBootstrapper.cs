using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        public StartCountdown StartCountdown;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Curtain, StartCountdown);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}