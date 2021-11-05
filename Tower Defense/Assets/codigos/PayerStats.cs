using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerStats : MonoBehaviour, IPlayerStats
{
    [SerializeField] int modifierM, modifierL;
    public int ModifyMoney() {
        return modifierM;
    }
    public int ModifyLives() {
        return modifierL;
    }
}
