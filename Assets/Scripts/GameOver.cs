using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void GotoMainMenu()
    {
      //  GameManager.GameIsOver = false;
        
        SceneManager.LoadScene("MainMenu");
        
    }

    public void GoToLevelManage()
    {
        SceneManager.LoadScene("LevelManage");
    }
}
