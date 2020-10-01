using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private turretBlueprint turretToBuild;
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
 
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager");
            return;
        }
        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
       if (PayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion. identity);
        node.turret = turret;

        Debug.Log("turret build, money left: " + PayerStats.Money);
    }
   

   public void SelectTurretToBuild (turretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public bool CanBuild { get { return turretToBuild != null; } }


}
