using UnityEngine;
using UnityEngine.UI;

public class TurretStat : MonoBehaviour {

    public static Text Stat_Text;
    public static Turret A;
    public static int Turret_Damage;
    public static float Turret_ASpeed;

    private void Start()
    {
        Stat_Text = GetComponent<Text>();

        Stat_Text.text = "DAMAGE : ";
        Stat_Text.text += "\n\nA.SPEED : ";
    }

    public static void Set_stat(Node nod, Text T)
    {
        A = nod.turret.GetComponent<Turret>();
        if (!A.useLaser)
        {
            Turret_Damage = A.bulletPrefab.GetComponent<Bullet>().damage;
            Turret_ASpeed = A.fireRate;
            T.text = "DAMAGE : " + Turret_Damage;
            T.text += "\n\nA.SPEED : " + Turret_ASpeed;
        }
        else
        {
            T.text = "DPS : 160";
        }
    }
}
