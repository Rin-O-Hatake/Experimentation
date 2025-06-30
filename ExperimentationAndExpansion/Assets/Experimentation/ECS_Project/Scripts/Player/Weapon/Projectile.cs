
using UnityEngine;

namespace Experimentation.ECS_Project.Scripts.Player.Weapon
{
    public struct Projectile
    {
        public float damage;
        public Vector3 direction;
        public float radius;
        public float speed;
        public Vector3 previousPos;
        public Object projectileGO;
    }
}
