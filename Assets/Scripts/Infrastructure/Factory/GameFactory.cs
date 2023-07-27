using Scripts.Infrastructure.AssetManagement;
using Scripts.Infrastructure.Factory.AssetManagement;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public class GameFactory : IGamefactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) =>
            _assets.Instantiate(AssetPath.HeroPath, at.transform.position);

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

        public GameObject CreatPointSpawnEnemy(GameObject point) => 
            _assets.Instantiate(AssetPath.SpawnEnemy,point.transform.position);
    }
}