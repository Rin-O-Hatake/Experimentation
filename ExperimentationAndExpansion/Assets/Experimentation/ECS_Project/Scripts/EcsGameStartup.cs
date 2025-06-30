using Experimentation.ECS_Project.Scripts.AllData.RunTimeData;
using Experimentation.ECS_Project.Scripts.AllData.SceneData;
using Experimentation.ECS_Project.Scripts.AllData.StaticData;
using Experimentation.ECS_Project.Scripts.Enemy;
using Experimentation.ECS_Project.Scripts.Player.Camera;
using Experimentation.ECS_Project.Scripts.Player.PlayerAnimation;
using Experimentation.ECS_Project.Scripts.Player.PlayerInit;
using Experimentation.ECS_Project.Scripts.Player.PlayerInput;
using Experimentation.ECS_Project.Scripts.Player.PlayerMove;
using Experimentation.ECS_Project.Scripts.Player.Weapon;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Experimentation.ECS_Project.Scripts
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        [SerializeField] private StaticData configuration;
        [SerializeField] private SceneData sceneData;
        
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedUpdateSystems;

        #region MonoBehavior

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            RuntimeData runtimeData = new RuntimeData();

            _systems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerRotationSystem())
                .Add(new PlayerAnimationSystem())
                .Add(new CameraFollowSystem())
                .Add(new WeaponShootSystem())
                .Add(new SpawnProjectileSystem())
                .Add(new ProjectileMoveSystem())
                .Add(new ProjectileHitSystem())
                .Add(new ReloadingSystem())
                .Inject(configuration)
                .Inject(sceneData)
                .Inject(runtimeData);
            
            _fixedUpdateSystems
                .Add(new PlayerMoveSystem());
            
            _systems.Init();
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null)
            {
                return;
            }
            
            _systems?.Destroy();
            _systems = null;
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
            _world?.Destroy();
            _world = null;
        }

        #endregion
        
    }
}
