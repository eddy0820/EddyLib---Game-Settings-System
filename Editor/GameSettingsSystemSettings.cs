using UnityEditor;
using UnityEngine;

namespace EddyLib.GameSettingsSystem.Editor
{

public class GameSettingsSystemSettings : ScriptableObject
{
    public const string SETTINGS_ASSETS_PATH = "Assets/Resources/EddyLib/EddyLib.GameSettingsSystem.asset";

    const string DEFAULT_GAME_SETTINGS_PATH = "Assets/Resources/DefaultGameSettings";

    [SerializeField] string defaultGameSettingsPath;
    public string DefaultGameSettingsPath => defaultGameSettingsPath;

    internal static GameSettingsSystemSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<GameSettingsSystemSettings>(SETTINGS_ASSETS_PATH);
        
        if(settings == null)
        {
            settings = CreateInstance<GameSettingsSystemSettings>();
            settings.defaultGameSettingsPath = DEFAULT_GAME_SETTINGS_PATH;
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
