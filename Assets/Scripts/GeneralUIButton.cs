using UnityEngine;
using UnityEngine.UI;

public class GeneralUIButton : MonoBehaviour {

    private GameObject A;
    private GameObject B;
    private GameObject C;
    private GameObject sell_button;
    private GameObject upgrade_button;
    public GameObject selected_unit_ui;
    public GameObject selected_unit_name_obj;
    public GameObject selected_unit_stat_obj;
    public Image selected_unit_image;
    public Text selected_unit_stat;
    public Text selected_unit_name;
    private string selected_ui;

    private void Start()
    {
        A = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/Shop/StandardTurretItem");
        B = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/Shop/MissileLauncherItem");
        C = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/Shop/LaserBeamerItem");
        selected_ui = "OverlayCanvas/OverlayBottomCanvas/SelectedUnitUI/";
        //selected_unit_ui = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/SelectedUnitUI/selected_unit_window");
        selected_unit_ui = GameObject.Find(selected_ui + "selected_unit_window");
        selected_unit_image = selected_unit_ui.GetComponent<Image>();
        selected_unit_name_obj = GameObject.Find(selected_ui + "name");
        selected_unit_stat_obj = GameObject.Find(selected_ui + "stat");
        selected_unit_name = selected_unit_name_obj.GetComponent<Text>();
        selected_unit_stat = selected_unit_stat_obj.GetComponent<Text>();
        sell_button = GameObject.Find(selected_ui + "Sell_Button");
        upgrade_button = GameObject.Find(selected_ui + "Upgrade_Button");
    }

    private void PressBuildButton()
    {
        A.SetActive(true);
        B.SetActive(true);
        C.SetActive(true);
        sell_button.SetActive(false);
        upgrade_button.SetActive(false);
        selected_unit_image.enabled = false;
        selected_unit_name.enabled = false;
        selected_unit_stat.enabled = false;
        TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle);
        TurretRangeCircle.Delete_Range_Circle();
    }

    private void PressCancelButton()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        sell_button.SetActive(false);
        upgrade_button.SetActive(false);
        selected_unit_image.enabled = false;
        selected_unit_name.enabled = false;
        selected_unit_stat.enabled = false;
        TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle);
        TurretRangeCircle.Delete_Range_Circle();
        if (Tooltip.tooltip)
            Tooltip.Destroy_tooltip(Tooltip.tooltip);
    }
}
