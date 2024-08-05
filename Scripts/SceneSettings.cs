using NaughtyAttributes;
using UnityEngine;

namespace EddyLib.GameSettingsSystem
{

public class SceneSettings : MonoBehaviour
{
    [Expandable, SerializeField] GameSettingsSO defaultGameplaySettings;

    private void Awake()
    {
        SceneSettings[] sceneSettings = FindObjectsOfType<SceneSettings>();

        if(sceneSettings.Length > 1)
        {
            Debug.LogWarning("Multiple SceneSettings found in scene. Only one should exist.");
            
            for(int i = 1; i < sceneSettings.Length; i++)
                Destroy(sceneSettings[i]);
        }
    }

    public T GetSettings<T>() where T : SettingsCategory
    {
        return defaultGameplaySettings.GetSettings<T>();
    }

    public void SetSettings(GameSettingsSO settings)
    {
        if(settings == null)
            return;
        
        defaultGameplaySettings = settings;
    }
}

}
