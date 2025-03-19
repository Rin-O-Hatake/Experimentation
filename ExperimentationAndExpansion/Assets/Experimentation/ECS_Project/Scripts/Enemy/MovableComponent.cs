using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Experimentation.ECS_Project.Scripts
{
    [Serializable]
    public struct MovableComponent
    {
        // public CharacterController characterController;
        public float speed;
    }
}