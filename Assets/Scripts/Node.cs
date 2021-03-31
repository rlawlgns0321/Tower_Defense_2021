using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positiononOffset;
    //public GameObject nod;

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    public GameObject select_circle;
    public GameObject range_circle;
    private GameObject circle;
    public bool is_selecting = false;

    private Turret turretStat;
    //List<Node> selected = new List<Node>();
   // private GameObject Range_Indicator;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        //TowerControl.selected.Add(this);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positiononOffset;
    }

    private void OnMouseDown()
    {
        //prevent clicking overgameObject
        if (EventSystem.current.IsPointerOverGameObject())
            return;
     /*   if (!buildManager.CanBuild)
            return;*/
        if (turret != null || this.tag != "Node")
        {
            Debug.Log("Can't build there! - TODO: Display on Screen");
            if (turret != null)
            {
                // < circle = (GameObject)Instantiate(select_circle, transform.position, transform.rotation); >
                if(TowerControl.selected.Count != 0)
                    TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle);
                TowerControl.add_Node_To_SelectionList(this); // add selected node to list
               // < TowerControl.selected.Add(this); >
                TowerControl.DrawCircle(TowerControl.selected, select_circle); //draw circle on selected nodes

                turretStat = this.turret.GetComponent<Turret>();

                TurretRangeCircle.Delete_Range_Circle();
                TurretRangeCircle.Draw_Range_Circle(range_circle, this, turretStat.range);                
                is_selecting = true;
                SelectedUnitImage.update_image(this);
                SelectedUnitStat.update_stat(this);
                //GeneralUIButton.PressCancelButton();
                TowerControl.selected.TrimExcess();
                TowerControl.selected_circle.TrimExcess(); //TrimExcess() for optimizing capacity in condition that has only one selected
                                                           //model. May need to modify later if the list can hold more data.
                buildManager.UnselectTurretToBuild();
            }
            
            //draw circle to notify user select this turret.
 /*           else
                Debug.Log(TowerControl.selected.Count);*/
            return;
        }

        if (turret == null && TowerControl.selected.Count != 0)
        {
            TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle); //delete existing circle on clicking
                                                                                                    //empty node
            TurretRangeCircle.Delete_Range_Circle();
            SelectedUnitImage.update_image(this);
            SelectedUnitStat.update_stat(this);
        }

        //Build a turret
        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        //prevent clicking overgameObject
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (this.tag != "Node")
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;

            Turret tmp;
            if (buildManager.turretToBuild.prefab != null)
            {
                tmp = buildManager.turretToBuild.prefab.GetComponent<Turret>();
                TurretRangeCircle.Draw_Range_Circle(range_circle, this, tmp.range);
            }
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        if(TowerControl.selected.Count == 0)
            TurretRangeCircle.Delete_Range_Circle();
        rend.material.color = startColor; 
    }
}
