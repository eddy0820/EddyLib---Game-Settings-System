using UnityEditor;
using EddyLib.Util.Editor;

namespace EddyLib.GameSettingsSystem.Editor
{

public static class GameSettingsSystemMenuItems
{
    [MenuItem("GameObject/EddyLib/Game Settings System/Scene Settings")]
    private static void CreateSceneSettings()
    {
        var sceneSettings = ObjectFactory.CreateGameObject("Scene Settings", typeof(SceneSettings));

        SceneSettings sceneSettingsComponent = sceneSettings.GetComponent<SceneSettings>();
        sceneSettingsComponent.SetSettings(GameSettingsSystemSettingsLocator.LocateDefaultGameSettings());

        CreateUtil.PlaceObjectInScene(sceneSettings);
    }
}

}
