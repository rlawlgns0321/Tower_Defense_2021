using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitImage : MonoBehaviour
{
    
    public static Image selected_unit_window;
    public static GameObject A;
    public static GameObject B;
    public static GameObject C;

    private void Start()
    {
        selected_unit_window = GetComponent<Image>();
        selected_unit_window.enabled = false;
        A = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/Shop/StandardTurretItem");
        B = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/Shop/MissileLauncherItem");
        C = GameObject.Find("OverlayCanvas/OverlayBottomCanvas/Shop/LaserBeamerItem");
    }

    public static void update_image(Node nod)
    {
        selected_unit_window.enabled = true;
        // Debug.Log(nod.turret.name);
        // Debug.Log(selected_unit_window.name);
        if (nod == null || nod.turret == null)
            selected_unit_window.enabled = false;
        else
        {
            if (nod.turret.name == "StandardTurret")
                selected_unit_window.sprite = Resources.Load<Sprite>("Icons/StandardTurretIcon");
            else if (nod.turret.name == "Laser Beamer")
                selected_unit_window.sprite = Resources.Load<Sprite>("Icons/LaserBeamerIcon");
            else if (nod.turret.name == "Missile Launcher")
                selected_unit_window.sprite = Resources.Load<Sprite>("Icons/MissileLauncherIcon");
            A.SetActive(false);
            B.SetActive(false);
            C.SetActive(false);
        }
    }
}