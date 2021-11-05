using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildManager : MonoBehaviour
{
    private turretBlueprint turretToBuild;
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    public PayerStats ps;
    public event UnityAction<int> OnBuy;



    private void Awake()
    {
        ps.GetComponent<IPlayerStats>();
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager");
            return;
        }
        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
       if (ps.ModifyMoney() < turretToBuild.cost) {
            Debug.Log("Not enough money");
            return;
       }

        OnBuy?.Invoke(ps.ModifyMoney());
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion. identity);
        node.turret = turret;            
        Debug.Log( "turret build, money left: " + ps.ModifyMoney());
        
    }
   

   public void SelectTurretToBuild (turretBlueprint turret)
    {
        turretToBuild = turret;
    }
    public void Buy(int moneyCost) {
        moneyCost -= 100;
    }

    public bool CanBuild { get { return turretToBuild != null; } }


}
