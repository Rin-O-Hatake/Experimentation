using System;
using MVVM;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace SampleGame
{
    public sealed class MonoViewBinder : MonoBehaviour
    {
        private enum BindingMode
        {
            FromInstance = 0,
            FromResolve = 1,
            FromResolveId = 2
        }

        [SerializeField]
        private BindingMode viewBinding;

        [ShowIf(nameof(viewBinding), BindingMode.FromInstance)]
        [SerializeField]
        private Object view;

        [ShowIf("@this.viewBinding == BindingMode.FromResolve || this.viewBinding == BindingMode.FromResolveId")]
        [SerializeField]
        private MonoScript viewType;

        [ShowIf(nameof(viewBinding), BindingMode.FromResolveId)]
        [SerializeField]
        private string viewId;

        [Space(8)]
        [SerializeField]
        private BindingMode viewModelBinding;

        [ShowIf(nameof(viewModelBinding), BindingMode.FromInstance)]
        [SerializeField]
        private Object viewModel;

        [ShowIf("@this.viewModelBinding == BindingMode.FromResolve || this.viewModelBinding == BindingMode.FromResolveId")]
        [SerializeField]
        private MonoScript viewModelType;

        [ShowIf(nameof(viewModelBinding), BindingMode.FromResolveId)]
        [SerializeField]
        private string viewModelId;
        
        [Inject]
        private DiContainer diContainer;

        private IBinder _binder;

        private void Awake()
        {
            _binder = this.CreateBinder();
        }

        private void OnEnable()
        {
            _binder.Bind();
        }

        private void OnDisable()
        {
            _binder.Unbind();
        }

        private IBinder CreateBinder()
        {
            object view = viewBinding switch
            {
                BindingMode.FromInstance => this.view,
                BindingMode.FromResolve => diContainer.Resolve(viewType.GetClass()),
                BindingMode.FromResolveId => diContainer.ResolveId(viewType.GetClass(), viewId),
                _ => throw new Exception($"Binding type of view {viewBinding} is not found!")
            };

            object model = viewModelBinding switch
            {
                BindingMode.FromInstance => viewModel,
                BindingMode.FromResolve => diContainer.Resolve(viewModelType.GetClass()),
                BindingMode.FromResolveId => diContainer.ResolveId(viewModelType.GetClass(), viewModelId),
                _ => throw new Exception($"Binding type of view {viewBinding} is not found!")
            };

            return BinderFactory.CreateComposite(view, model);
        }
    }
}