using Cysharp.Threading.Tasks;
using Plugins.AltoCityUIPack.Scripts.Button;
using UnityEngine;
using UnityEngine.Networking;

namespace Experimentation.AssetBundleTest.Scripts
{
    public class AssetBundlesController : MonoBehaviour
    {
        [SerializeField] private UIButtonManagerCustom _downloadButton;
        private string url = "http://195.133.39.243/root";
        private int version = 0;

        public void Awake()
        {
            _downloadButton.OnClick.AddListener(LoadAssetBundleButton);
        }

        public void OnDestroy()
        {
            _downloadButton.OnClick.RemoveListener(LoadAssetBundleButton);
        }

        private void LoadAssetBundleButton()
        {
            LoadAssetBundle(ServerAssetBundlesEnum.Sprites).Forget();
        }
        
        private async UniTask LoadAssetBundle(ServerAssetBundlesEnum serverAssetBundlesEnum)
        {
            using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle($"{url}{serverAssetBundlesEnum.ToString()}"))
            {
                var operation = request.SendWebRequest();
                await operation.ToUniTask();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Error downloading AssetBundle: {request.error}");
                }
                else
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                    Debug.Log("AssetBundle loaded successfully.");
                }
            }
        }
    }
}
