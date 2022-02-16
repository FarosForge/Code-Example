using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestructionMode : GameModule
{
    [SerializeField] EnemyBase[] targets;

    public override void Init(LevelManager manager)
    {
        base.Init(manager);

        foreach (var t in targets)
        {
            t.components.stats.hitAction += UpdateProgress;
        }
    }

    public override void GameOver(GameOverType type)
    {
        base.GameOver(type);

        ui.SetGameOver(type);
        ui.SetActiveGamePoints(false);
    }

    void UpdateProgress()
    {
        if(CheckAllDead())
        {
            GameOver(GameOverType.Win);
        }
    }

    bool CheckAllDead()
    {
        foreach (var t in targets)
        {
            if(!t.components.stats.CheckDead())
            {
                return false;
            }
        }

        return true;
    }
}
