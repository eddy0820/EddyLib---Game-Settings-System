using NaughtyAttributes;
using UnityEngine;

namespace EddyLib.GameSettingsSystem
{

public class SceneSettings : MonoBehaviour
{
    [Expandable, SerializeField] GameSettingsSO defaultGameplaySettings;

    public T GetSettings<T>() where T : SettingsCategory
    {
        return defaultGameplaySettings.GetSettings<T>();
    }
}

}
