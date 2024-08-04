using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

namespace EddyLib.GameSettingsSystem.Editor
{

public class GameSettingsSystemSettingsProvider : SettingsProvider
{
    SerializedObject gameSettingsSystemSettings;

    const string SETTINGS_ASSETS_PATH = "Assets/Resources/EddyLib/EddyLib.GameSettingsSystem.asset";

    public GameSettingsSystemSettingsProvider(string path, SettingsScope scope = SettingsScope.Project) : base(path, scope) {}

    public static bool IsSettingsAvailable()
    {
        return File.Exists(SETTINGS_ASSETS_PATH);
    }

    public override void OnActivate(string searchContext, VisualElement rootElement)
    {
        gameSettingsSystemSettings = GameSettingsSystemSettings.GetSerializedSettings();
    }

    public override void OnGUI(string searchContext)
    {
        EditorGUILayout.PropertyField(gameSettingsSystemSettings.FindProperty("defaultGameSettingsResourcesPath"));
        gameSettingsSystemSettings.ApplyModifiedPropertiesWithoutUndo();
    }

    [SettingsProvider]
    public static SettingsProvider CreateGameSettingsSystemSettingsProvider()
    {
        var provider = new GameSettingsSystemSettingsProvider("Project/EddyLib/Game Settings System", SettingsScope.Project);
        return provider;
    }
}

}
