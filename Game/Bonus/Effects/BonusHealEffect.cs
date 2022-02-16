using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealEffect : IBonusEffect
{
    [SerializeField] int healing_points;
    public override void BonusAction(GameObject target)
    {
        target.GetComponent<Stats>().AddHP(healing_points);
    } 
}
