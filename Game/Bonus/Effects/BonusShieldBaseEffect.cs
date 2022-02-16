using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShieldBaseEffect : IBonusEffect
{
    [SerializeField] float shield_time;

    public override void BonusAction(GameObject target)
    {
        var base_obj = FindObjectOfType<BaseManager>();
        base_obj.components.stats.SetUndestroyTime(shield_time);
    }
}
