using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

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

        SceneView lastView = SceneView.lastActiveSceneView;
        sceneSettings.transform.position = lastView ? lastView.pivot : Vector3.zero;
        
        StageUtility.PlaceGameObjectInCurrentStage(sceneSettings);
        GameObjectUtility.EnsureUniqueNameForSibling(sceneSettings);

        Undo.RegisterCreatedObjectUndo(sceneSettings, $"Create Object: {sceneSettings.name}");  
        Selection.activeGameObject = sceneSettings;

        EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
    }
}

}
