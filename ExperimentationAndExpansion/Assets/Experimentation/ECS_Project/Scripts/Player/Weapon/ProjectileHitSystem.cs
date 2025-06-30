using Leopotam.Ecs;
using Unity.VisualScripting;

namespace Experimentation.ECS_Project.Scripts.Player.Weapon
{
    public class ProjectileHitSystem : IEcsRunSystem
    {
        private EcsFilter<Projectile, ProjectileHit> filter;
    
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var projectile = ref filter.Get1(i);
            
                projectile.projectileGO.GameObject().SetActive(false);
            }
        }
    
    }
}
