using UnityEditor;

namespace EddyLib.GameSettingsSystem.Editor
{

internal static class GameSettingsSystemSettingsHelper
{
    const string SETTINGS_ASSETS_PATH = "Assets/Resources/EddyLib/EddyLib.GameSettingsSystem.asset";
    const string DEFAULT_GAME_SETTINGS_PATH = "DefaultGameSettings";

    private static GameSettingsSystemSettings GetOrCreateSettings()
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

            settings = GameSettingsSystemSettings.CreateSettingsInstance(DEFAULT_GAME_SETTINGS_PATH);
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
