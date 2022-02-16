using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveMode : GameModule
{
    public int current_tanks { get; set; }

    public override void Init(LevelManager manager)
    {
        base.Init(manager);
        ui.SetTextCountTanks(current_tanks);
    }

    public override void ActionTanksCount()
    {
        current_tanks++;
        ui.SetTextCountTanks(current_tanks);
    }

    public override void GameOver(GameOverType type)
    {
        base.GameOver(type);

        ui.SetGameOver(GameOverType.Win);
        ui.SetActiveGamePoints(true);
        ui.SetGamePointsText(current_tanks, GetGamePoints(current_tanks, 150));
    }
}
