using Scripts.Infrastructure.Factory;
using Scripts.CameraLogic;
using Scripts.Logic;
using UnityEngine;
using Scripts.Hero;

namespace Scripts.Infrastructure.State
{
    public class LoadLevelState : IPayloadedState<string>
    {

        private const string InitialPointTag = "InitialPoint";
        private const string PointSpawn = "PointSpawn";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly StartCountdown _startCountdown;
        private readonly IGamefactory _gamefactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, StartCountdown startCountdown, IGamefactory gamefactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _startCountdown = startCountdown;
            _gamefactory = gamefactory;
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
            GameObject hero = _gamefactory.CreateHero(GameObject.FindWithTag(InitialPointTag));
            GameObject spaw = _gamefactory.CreatPointSpawnEnemy(GameObject.FindWithTag(PointSpawn));
            Player player = hero.GetComponent<Player>();
            spaw.GetComponent<Spawn>().SetTarget(player);
            _gamefactory.CreateHud();
            CameraFollow(hero);

            _startCountdown.SetComponent(hero);
            _stateMachine.Enter<LoadingCountdownState>();
        }

        private void CameraFollow(GameObject hero) =>
          Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}