using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitStat : MonoBehaviour {

    private GameObject Name_Obj;
    private GameObject Stat_Obj;
    public static GameObject Upgrade_Button_Obj;
    public static GameObject Sell_Button_Obj;
    public static Text Name;
    public static Text Stat;

    private void Start()
    {
        Name_Obj = GameObject.Find("name");
        Name = Name_Obj.GetComponent<Text>();
        Stat_Obj = GameObject.Find("stat");
        Stat = Stat_Obj.GetComponent<Text>();
        Upgrade_Button_Obj = GameObject.Find("Upgrade_Button");
        Sell_Button_Obj = GameObject.Find("Sell_Button");
        

        Name.enabled = false;
        Stat.enabled = false;
        Upgrade_Button_Obj.SetActive(false);
        Sell_Button_Obj.SetActive(false);
        //Name.text = TowerControl.selected[0].name;
    }

    public static void update_stat(Node nod)
    {
        if (nod != null && nod.turret != null)
        {
            Name.enabled = true;
            Name.text = nod.turret.name;
            Stat.enabled = true;
            if(nod.turret.name == "StandardTurret" || nod.turret.name == "Missile Launcher")
                Upgrade_Button_Obj.SetActive(true);
            Sell_Button_Obj.SetActive(true);
        }
        else
        {
            Name.enabled = false;
            Stat.enabled = false;
            Upgrade_Button_Obj.SetActive(false);
            Sell_Button_Obj.SetActive(false);
        }
    }
}
