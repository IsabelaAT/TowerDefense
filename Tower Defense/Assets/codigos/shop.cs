﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManager;
    public turretBlueprint standartTurret;
    public turretBlueprint anotherTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("standard turret selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectAnotherTurret()
    {
        Debug.Log("another turret selected");
        buildManager.SelectTurretToBuild(anotherTurret);
    }

}
