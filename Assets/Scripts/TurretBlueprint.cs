using UnityEngine;

[System.Serializable]   //Unity will go ahead and save & load the values inside
                        //of this class by making them visible in Inspector view.

public class TurretBlueprint {

    public GameObject prefab;
    public int cost;

}
