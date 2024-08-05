using UnityEngine;
using NaughtyAttributes;

namespace EddyLib.GameSettingsSystem
{

public class GameSettingsSystemSettings : ScriptableObject
{
    [ReadOnly, SerializeField] string defaultGameSettingsResourcesPath;
    public string DefaultGameSettingsResourcesPath => defaultGameSettingsResourcesPath;

    public static GameSettingsSystemSettings CreateSettingsInstance(string _defaultGameSettingsResourcesPath)
    {
        var settings = CreateInstance<GameSettingsSystemSettings>();
        settings.defaultGameSettingsResourcesPath = _defaultGameSettingsResourcesPath;
        return settings;
    }
}

}
