using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

namespace EddyLib.GameSettingsSystem.Editor
{

internal class GameSettingsSystemSettingsProvider : SettingsProvider
{
    SerializedObject gameSettingsSystemSettings;

    public GameSettingsSystemSettingsProvider(string path, SettingsScope scope = SettingsScope.Project) : base(path, scope) {}

    public override void OnActivate(string searchContext, VisualElement rootElement)
    {
        gameSettingsSystemSettings = GameSettingsSystemSettingsHelper.GetSerializedSettings();
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
