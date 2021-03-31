using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    public static GameObject tooltip;
    public static GameObject text_obj;
    private static Text Tooltip_Text;

    public static void Show_tooltip(GameObject obj, GameObject tooltip_prefab)
    {

        tooltip = (GameObject)Instantiate(tooltip_prefab, obj.transform.position, Quaternion.identity);
        tooltip.transform.SetParent(GameObject.Find("SelectedUnitUI").transform);
        tooltip.transform.position = obj.transform.position + new Vector3(140, 130, 0);
        tooltip.transform.Find("Text").position = obj.transform.position + new Vector3(140, 130, 0);
        text_obj = tooltip.transform.Find("Text").gameObject;
        Tooltip_Text = text_obj.GetComponent<Text>();
        if (obj.name == "Sell_Button")
            Tooltip_Text.text = "<size=45>Sell</size>\nSell this tower for 50$.";    
        else if (obj.name == "Upgrade_Button")
            Tooltip_Text.text = "<size=45>Upgrade</size>\nUpgrade this tower for 100$.";
    }

    public static void Destroy_tooltip(GameObject T_tip)
    {
        Destroy(T_tip);
    }
}
