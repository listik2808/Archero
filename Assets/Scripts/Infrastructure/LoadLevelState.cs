﻿using Scripts.CameraLogic;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string HeroPath = "Hero/hero";
        private const string InitialPointTag = "InitialPoint";
        private const string HudPath = "Hud/Hud";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly StartCountdown _startCountdown;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, StartCountdown startCountdown)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _startCountdown = startCountdown;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, onLoaded);
        }

        public void Exit() =>
          _loadingCurtain.Hide();

        private void onLoaded()
        {
            var initialPoint = GameObject.FindWithTag(InitialPointTag);
            GameObject hero = Instantiate(path: HeroPath, at: initialPoint.transform.position);
            Instantiate(HudPath);

            CameraFollow(hero);
            _startCountdown.SetComponent(hero);
            _stateMachine.Enter<LoadingCountdown>();
        }

        private void CameraFollow(GameObject hero) =>
          Camera.main.GetComponent<CameraFollow>().Follow(hero);

        private static GameObject Instantiate(string path)
        {
            var heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}