using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionToggle : MonoBehaviour {


    public static ToggleGroup toggle_group;

    public static Toggle Lvl_1;
    public static Toggle Lvl_2;
    public static Toggle Lvl_3;
    public static Toggle Lvl_4;

    public Text Modifier_Text;
	// Use this for initialization
	void Start () {
        toggle_group = GetComponent<ToggleGroup>();
        Lvl_1 = GameObject.Find("Level_1").GetComponent<Toggle>();
        Lvl_2 = GameObject.Find("Level_2").GetComponent<Toggle>();
        Lvl_3 = GameObject.Find("Level_3").GetComponent<Toggle>();
        Lvl_4 = GameObject.Find("Level_4").GetComponent<Toggle>();
        Modifier_Text = GameObject.Find("Modifier_Text").GetComponent<Text>();

        toggle_group.RegisterToggle(Lvl_1);
        toggle_group.RegisterToggle(Lvl_2);
        toggle_group.RegisterToggle(Lvl_3);
        toggle_group.RegisterToggle(Lvl_4);

        Lvl_1.onValueChanged.AddListener(
            (bool A)=>{
                if(A)
                {
                    Modifier_Text.text = "Level 1 Selected!\n";
                    Modifier_Text.text += "Player Lives : 20\n";
                    Modifier_Text.text += "Wave Number : 5\n";
                    Modifier_Text.text += "Enemy Health : 100\n";
                    Modifier_Text.text += "Enemy Speed : Slow\n";
                }
            }
        );

        Lvl_2.onValueChanged.AddListener(
            (bool A) => {
                if (A)
                {
                    Modifier_Text.text = "Level 2 Selected!\n";
                    Modifier_Text.text += "Player Lives : 20\n";
                    Modifier_Text.text += "Wave Number : 10\n";
                    Modifier_Text.text += "Enemy Health : 125\n";
                    Modifier_Text.text += "Enemy Speed : Medium\n";
                }
            }
        );

        Lvl_3.onValueChanged.AddListener(
            (bool A) => {
                if (A)
                {
                    Modifier_Text.text = "Level 3 Selected!\n";
                    Modifier_Text.text += "Player Lives : 20\n";
                    Modifier_Text.text += "Wave Number : 15\n";
                    Modifier_Text.text += "Enemy Health : 150\n";
                    Modifier_Text.text += "Enemy Speed : Fast\n";
                }
            }
        );

        Lvl_4.onValueChanged.AddListener(
            (bool A) => {
                if (A)
                {
                    Modifier_Text.text = "Level 4 Selected!\n";
                    Modifier_Text.text += "Player Lives : 10\n";
                    Modifier_Text.text += "Wave Number : 20\n";
                    Modifier_Text.text += "Enemy Health : 200\n";
                    Modifier_Text.text += "Enemy Speed : Faster!\n";
                }
            }
        );

    }

    
}
