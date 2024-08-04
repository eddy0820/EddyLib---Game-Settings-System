using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace EddyLib.GameSettingsSystem
{

[CreateAssetMenu(fileName = "New Game Settings", menuName = "EddyLib/Game Settings System/Game Settings")]
public class GameSettingsSO : ScriptableObject
{
    [Expandable, SerializeField] List<SettingsCategorySO> settingsCategories;

    public T GetSettings<T>() where T : SettingsCategory
    {
        foreach(var settingsCategory in settingsCategories)
        {
            if(settingsCategory is SettingsCategorySO<T> typedSettingsCategory)
                return typedSettingsCategory.Settings;
        }

        return null;
    }
}

}
