﻿using CodeBase.Logic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}