using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EddyLib.GameSettingsSystem
{

public static class GameSettingsSystemSettingsLocator
{
    const string SETTINGS_ASSETS_RESOURCES_PATH = "EddyLib/EddyLib.GameSettingsSystem";

    public static GameSettingsSystemSettings LocateGameSettingsSystemSettings()
    {
        GameSettingsSystemSettings settings = Resources.Load<GameSettingsSystemSettings>(SETTINGS_ASSETS_RESOURCES_PATH);

        if(settings == null)
            throw new System.Exception("No GameSettingsSystemSettings asset found at path: Asset/Resources/" + SETTINGS_ASSETS_RESOURCES_PATH);

        return settings;
    }

    public static GameSettingsSO LocateDefaultGameSettings()
    {
        GameSettingsSystemSettings settings = LocateGameSettingsSystemSettings();
        GameSettingsSO defaultGameSettings = Resources.Load<GameSettingsSO>(settings.DefaultGameSettingsResourcesPath);

        if(defaultGameSettings == null)
            throw new System.Exception("No GameSettingsSO asset found at path: Asset/Resources/" + settings.DefaultGameSettingsResourcesPath);

        return defaultGameSettings;
    }
    
}

}
