using System;
using UnityEngine;

namespace Experimentation.ECS_Project.Scripts.Enemy
{
    [Serializable]
    public struct EnemyDirectionComponent
    {
        public Transform targetTransform;
    }
}