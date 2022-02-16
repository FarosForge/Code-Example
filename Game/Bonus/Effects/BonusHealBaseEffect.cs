using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealBaseEffect : IBonusEffect
{
    [SerializeField] int heal_points;
    public override void BonusAction(GameObject target)
    {
        var base_obj = FindObjectOfType<BaseManager>();

        base_obj.components.stats.AddHP(heal_points);
    }
}
