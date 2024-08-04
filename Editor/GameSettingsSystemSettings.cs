using UnityEditor;
using UnityEngine;

namespace EddyLib.GameSettingsSystem.Editor
{

public class GameSettingsSystemSettings : ScriptableObject
{
    const string SETTINGS_ASSETS_PATH = "Assets/Resources/" + SETTINGS_ASSETS_RESOURCES_PATH;
    public const string SETTINGS_ASSETS_RESOURCES_PATH = "EddyLib/EddyLib.GameSettingsSystem.asset";

    const string DEFAULT_GAME_SETTINGS_PATH = "DefaultGameSettings";

    [SerializeField] string defaultGameSettingsResourcesPath;
    public string DefaultGameSettingsResourcesPath => defaultGameSettingsResourcesPath;

    internal static GameSettingsSystemSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<GameSettingsSystemSettings>(SETTINGS_ASSETS_PATH);
        
        if(settings == null)
        {
            if(!AssetDatabase.IsValidFolder("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }

            if(!AssetDatabase.IsValidFolder("Assets/Resources/EddyLib"))
            {
                AssetDatabase.CreateFolder("Assets/Resources", "EddyLib");
            }

            settings = CreateInstance<GameSettingsSystemSettings>();
            settings.defaultGameSettingsResourcesPath = DEFAULT_GAME_SETTINGS_PATH;
            AssetDatabase.CreateAsset(settings, SETTINGS_ASSETS_PATH);
            AssetDatabase.SaveAssets();
        }

        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}

}
