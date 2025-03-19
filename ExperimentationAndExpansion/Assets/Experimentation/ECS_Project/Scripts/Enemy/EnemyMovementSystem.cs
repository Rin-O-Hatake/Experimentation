using Leopotam.Ecs;
using UnityEngine;

namespace Experimentation.ECS_Project.Scripts.Enemy
{
    public class EnemyMovementSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<MovableComponent, EnemyDirectionComponent, EnemyModelComponent> _movableFilter;


        public void Run()
        {
            foreach (var filter in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(filter);
                ref var directionComponent = ref _movableFilter.Get2(filter);
                ref var modelComponent = ref _movableFilter.Get3(filter);

                ref var enemyTransform = ref modelComponent.enemyTransform;
                ref var playerTransform = ref directionComponent.targetTransform;
                ref var speed = ref movableComponent.speed; 
                
                enemyTransform.position = Vector3.MoveTowards(enemyTransform.position,
                    new Vector3(playerTransform.position.x, enemyTransform.position.y, playerTransform.position.z), speed);
                enemyTransform.LookAt(playerTransform);
            }
        }
    }
}
