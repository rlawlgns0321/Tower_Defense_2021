using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Mainmenu : MonoBehaviour {

    public string levelToLoad = "LevelManage";
    public string level_manage_play = "MainScene";
    public string to_tutorial = "Tutorial";

    public void Play()
    {
        StartCoroutine(loadScene(levelToLoad));
        Time.timeScale = 1f;
    }

    public void To_Tutorial()
    {
        StartCoroutine(loadScene(to_tutorial));
        Time.timeScale = 1f;
    }

    public void Level_Manage_Play()
    {
        StageLevelModifier.Modify_With_Level();
        if (LevelSelectionToggle.toggle_group.AnyTogglesOn())
            StartCoroutine(loadScene(level_manage_play));
        Time.timeScale = 1f;        
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator loadScene(string sceneName)
    {
        AsyncOperation OP = SceneManager.LoadSceneAsync(sceneName);
        while(!OP.isDone)
        {
            yield return null;
            Debug.Log(OP.progress);
        }
        OP.allowSceneActivation = true;
    }
}
