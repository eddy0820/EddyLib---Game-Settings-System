using EddyLib.GameSettingsSystem.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EddyLib.GameSettingsSystem
{

public static class GameSettings
{
    static GameSettingsSO defaultGameSettings;
    static GameSettingsSO DefaultGameSettings
    {
        get
        {
            if(defaultGameSettings == null)
            {
                GameSettingsSystemSettings settings = Resources.Load<GameSettingsSystemSettings>(GameSettingsSystemSettings.SETTINGS_ASSETS_PATH);

                if(settings != null)
                    defaultGameSettings = Resources.Load<GameSettingsSO>(settings.DefaultGameSettingsResourcesPath);
                else
                    throw new System.Exception("No GameSettingsSystemSettings asset found.");
            }
            
            return defaultGameSettings;
        }
    }

    static int currentSceneIndex = -1;
    static SceneSettings currentSceneSettings;

    private static bool TryFindSceneSettings(out SceneSettings sceneSettings)
    {
        sceneSettings = currentSceneSettings;

        if(SceneManager.GetActiveScene().buildIndex != currentSceneIndex)
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneSettings = Object.FindObjectOfType<SceneSettings>(true);
            currentSceneSettings = sceneSettings;
        }

        if(currentSceneSettings == null)
            return false;

        return true;
    }

    public static T GetSettings<T>() where T : SettingsCategory
    {
        if(TryFindSceneSettings(out SceneSettings sceneSettings) && sceneSettings.GetSettings<T>() != null)
            return sceneSettings.GetSettings<T>();
        
        if(DefaultGameSettings.GetSettings<T>() != null)
            return DefaultGameSettings.GetSettings<T>();

        throw new System.Exception($"No settings of type {typeof(T)} found in scene or default settings");
    }
}

}
