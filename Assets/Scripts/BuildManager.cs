﻿using UnityEngine;

public class BuildManager : MonoBehaviour {

    //Singleton Pattern
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject laserBeamerPrefab;

    public GameObject buildEffect;

    public TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } } //property
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (CanBuild)
        {
            if (PlayerStats.Money < turretToBuild.cost)
            {
                Debug.Log("Not enough money to build that!");
                return;
            }

            PlayerStats.Money -= turretToBuild.cost;

            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
            turret.name = turretToBuild.prefab.name;

            GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            Debug.Log("Turret build! Money left: " + PlayerStats.Money);
        }
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void UnselectTurretToBuild()
    {
        turretToBuild = null;
    }
}
