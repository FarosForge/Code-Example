using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShieldEffect : IBonusEffect
{
    [SerializeField] float shield_time;

    public override void BonusAction(GameObject target)
    {
        target.GetComponent<Stats>().SetUndestroyTime(shield_time);
    }
}
