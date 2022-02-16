using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefenceMode : GameModule
{
    public int current_tanks { get; set; }
    private int full_tanks;

    public override void Init(LevelManager manager)
    {
        base.Init(manager);
        current_tanks = spawner.Count;
        full_tanks = spawner.Count;
        ui.SetTextCountTanks(current_tanks);
    }

    public override void ActionTanksCount()
    {
        current_tanks--;

        if (current_tanks <= 0)
        {
            current_tanks = 0;
            GameOver(GameOverType.Win);
        }

        ui.SetTextCountTanks(current_tanks);
    }

    public override void GameOver(GameOverType type)
    {
        base.GameOver(type);

        ui.SetGameOver(type);

        switch (type)
        {
            case GameOverType.Win:
                ui.SetActiveGamePoints(true);
                ui.SetGamePointsText(full_tanks, GetGamePoints(full_tanks, 150));
                break;
            case GameOverType.Fail:
                ui.SetActiveGamePoints(false);
                break;
        }
    }
}


public enum GameOverType
{
    Win,
    Fail
}