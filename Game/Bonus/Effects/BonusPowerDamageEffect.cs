using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPowerDamageEffect : IBonusEffect
{
    [SerializeField] float power_time;
    public override void BonusAction(GameObject target)
    {
        target.GetComponent<PlayerController>().SetPowerUp(power_time);
    }
}
