using UnityEditor;
using System.Collections;

public class EditorCore : EditorWindow
{
    private const string AssetPath = "Assets/Resources/";

    [MenuItem("Custom/Asset creation/Create Sound Container")]
    public static void CreateEnemyContainer()
    {
        var asset = CreateInstance<SoundInfoContainer>();
        AssetDatabase.CreateAsset(asset, AssetPath + "SoundInfoContainer.asset");
        AssetDatabase.SaveAssets();
    }
}
