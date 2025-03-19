using Experimentation.ECS_Project.Scripts.Enemy;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Experimentation.ECS_Project.Scripts
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        #region MonoBehavior

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();
            
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null)
            {
                return;
            }
            
            _systems.Destroy();
            _world.Destroy();
        }

        #endregion

        private void AddSystems()
        {
            _systems.Add(new EnemyMovementSystem());
        }

        private void AddInjections()
        {
            
        }

        private void AddOneFrames()
        {
            
        }
        
    }
}
