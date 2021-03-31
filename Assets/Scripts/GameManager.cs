using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameoverUI;

    public GameObject PauseMenuUI;
    public GameObject Abandon_Message;

    public GameObject CompleteUI;
    public GameObject[] remain_enemies;

    bool is_CompleteUI_Active = false;

    private void Start()
    {
        GameIsOver = false;
        remain_enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update () {
        remain_enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (GameIsOver)         //Conditions when Game Over
            return;
		if(PlayerStats.Lives <= 0) //Game Over when lives drop to zero.
        {
            EndGame();
            Debug.Log("life below 0");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //Pause when press esc.
            Press_Menu();
        if(!is_CompleteUI_Active && PlayerStats.Rounds >= StageLevelModifier.modified_waveNumber && remain_enemies.Length == 0)
        {
            Time.timeScale = 0f;
            CompleteUI.SetActive(true);
            is_CompleteUI_Active = true;
            return;
        }
	}

    public void Press_Menu()
    {
        PauseMenuUI.SetActive(true);
        if(PauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Press_Continue_OnPause()
    {
        PauseMenuUI.SetActive(false);
        if (!PauseMenuUI.activeSelf)
            Time.timeScale = 1f;
    }

    public void Press_Abandon_OnPause()
    {
        Abandon_Message.SetActive(true);
    }

    public void Abandon_Message_Yes()
    {
        Abandon_Message.SetActive(false);
        PauseMenuUI.SetActive(false);
        gameoverUI.SetActive(true);
        TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle);
    }

    public void Abandon_Message_No()
    {
        Abandon_Message.SetActive(false);
    }

    void EndGame()
    {
        GameIsOver = true;
        gameoverUI.SetActive(true);
    }
}
