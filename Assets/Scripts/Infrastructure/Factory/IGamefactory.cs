using Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrastructure.Factory
{
    public interface IGamefactory : IService
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
        GameObject CreatPointSpawnEnemy(GameObject point);
    }
}