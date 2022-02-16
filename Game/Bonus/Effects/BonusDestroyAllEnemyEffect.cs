using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDestroyAllEnemyEffect : IBonusEffect
{
    public override void BonusAction(GameObject target)
    {
        FindObjectOfType<GameModule>().spawner.DestroyAllEnemy();
    }
}
