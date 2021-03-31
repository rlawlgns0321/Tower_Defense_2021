using UnityEngine;

public class SelectedUnitButton : MonoBehaviour {

    public GameObject sellEffect;

    public GameObject Upgraded_Standard;
    public GameObject Upgraded_Missile;
    public GameObject Upgraded_Laser;

    public void SellButton()
    {

        GameObject effect = (GameObject)Instantiate(sellEffect, TowerControl.selected[0].GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(TowerControl.selected[0].turret);
        TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle);
        SelectedUnitImage.update_image(null);
        SelectedUnitStat.update_stat(null);
        PlayerStats.Money += 50;      
    }

    public void UpgradeButton()
    {
        if (PlayerStats.Money >= 100)
        {
            GameObject effect = (GameObject)Instantiate(sellEffect, TowerControl.selected[0].GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            if (TowerControl.selected[0].turret.name == "StandardTurret")
            {
                Instantiate(Upgraded_Standard, TowerControl.selected[0].GetBuildPosition(), Quaternion.identity);
                Destroy(TowerControl.selected[0].turret);
                TowerControl.selected[0].turret = Upgraded_Standard;
            }
            else if (TowerControl.selected[0].turret.name == "Missile Launcher")
            {
                Instantiate(Upgraded_Missile, TowerControl.selected[0].GetBuildPosition(), Quaternion.identity);
                Destroy(TowerControl.selected[0].turret);
                TowerControl.selected[0].turret = Upgraded_Missile;
            }


            TowerControl.delete_SelectionList(TowerControl.selected, TowerControl.selected_circle);
            SelectedUnitImage.update_image(null);
            SelectedUnitStat.update_stat(null);
            PlayerStats.Money -= 100;
        }
    }
}
