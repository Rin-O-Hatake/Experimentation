using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts
{
    [DefaultExecutionOrder(-1000), DisallowMultipleComponent]
    public class DontDestroyObject : MonoBehaviour
    {
        #region Fields

        [Title("Properties")] 
        [SerializeField] private bool _active = true;

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            if (_active)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
    }
}