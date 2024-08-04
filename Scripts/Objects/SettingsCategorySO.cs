using UnityEngine;

namespace EddyLib.GameSettingsSystem
{

public abstract class SettingsCategorySO<T> : SettingsCategorySO where T : SettingsCategory
{
    [SerializeField] T settings;
    public T Settings => settings;
}

public abstract class SettingsCategorySO : ScriptableObject {}

}
