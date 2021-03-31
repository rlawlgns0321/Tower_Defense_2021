using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StageLevelModifier : MonoBehaviour {


    public static float modified_enemyHealth;
    public static int modified_waveNumber;
    public static float modified_enemySpeed;
    public static int modified_lives;

    private void Start()
    {
        DontDestroyOnLoad(this);
        //Modify_With_Level();
    }

    public static void Modify_With_Level() { 
        Toggle ActiveToggle = LevelSelectionToggle.toggle_group.ActiveToggles().FirstOrDefault();
        Debug.Log(ActiveToggle.name);
        if(ActiveToggle.name == "Level_1")
        {
            modified_enemyHealth = 100f;
            modified_waveNumber = 5;
            modified_enemySpeed = 6f;
            modified_lives = 20;
        }

        else if (ActiveToggle.name == "Level_2")
        {
            modified_enemyHealth = 125f;
            modified_waveNumber = 10;
            modified_enemySpeed = 8f;
            modified_lives = 20;
        }

        else if (ActiveToggle.name == "Level_3")
        {
            modified_enemyHealth = 150f;
            modified_waveNumber = 15;
            modified_enemySpeed = 10f;
            modified_lives = 20;
        }

        else if (ActiveToggle.name == "Level_4")
        {
            modified_enemyHealth = 200f;
            modified_waveNumber = 20;
            modified_enemySpeed = 12f;
            modified_lives = 10;
        }
    }
}
