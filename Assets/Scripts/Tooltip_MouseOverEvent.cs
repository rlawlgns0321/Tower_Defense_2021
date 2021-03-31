using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip_MouseOverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler{

    public GameObject tooltip_prefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
         Debug.Log("OnMouseOver Event called!");
         Tooltip.Show_tooltip(this.gameObject, tooltip_prefab);
         return;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       Tooltip.Destroy_tooltip(Tooltip.tooltip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Tooltip.Destroy_tooltip(Tooltip.tooltip);
    }
}
