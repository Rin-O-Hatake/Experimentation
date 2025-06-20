using UnityEditor;

namespace Editor
{
    public class CreateAssetBundles
    {
        [MenuItem("Assets/Create AssetBundles")]
        static void BuildAllAssetBundles()
        {
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
