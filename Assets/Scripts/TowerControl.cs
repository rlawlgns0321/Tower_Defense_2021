using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour {

    public static List<Node> selected = new List<Node>();
    public static List<GameObject> selected_circle = new List<GameObject>();
    public static GameObject circle_clone;
    //public static GameObject rangecircle_clone;

    public static void add_Node_To_SelectionList(Node nod)
    {
        selected.Add(nod);
        TurretStat.Set_stat(TowerControl.selected[0], TurretStat.Stat_Text);
    }

    public static void DrawCircle(List<Node> nod, GameObject circle)
    {
        for (int i = 0; i < nod.Count; i++)
        {
            circle_clone = (GameObject)Instantiate(circle, nod[i].transform.position, nod[i].transform.rotation);
            selected_circle.Add(circle_clone);
        }
    }

    public static void delete_SelectionList(List<Node> nod, List<GameObject> select_circle)
    {
        for (int i = 0; i < select_circle.Count; i++)
            Destroy(select_circle[i]);          //Erase the existing circle
        nod.Clear();
        select_circle.Clear();
    }
}
