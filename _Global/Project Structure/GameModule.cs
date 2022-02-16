using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameModule : MonoBehaviour
{
    public PlayerController player;
    public TankObject tank;
    public LevelManager levelManager;
    public Spawner spawner;
    public BonusSpawner bonusSpawner;
    public bool isOver;
    public PlayerBattleUI ui { get; set; }

    public virtual void GameOver(GameOverType type)
    {
        if (isOver) return;

        isOver = true;
    }

    public virtual void Init(LevelManager manager)
    {
        levelManager = manager;
        player.Init(this, tank);
        ui.restart_button.onClick.AddListener(() => levelManager.ReloadGame());
        ui.toLobbyButton.onClick.AddListener(() => levelManager.ToLobby());


        if (bonusSpawner != null)
        {
            bonusSpawner.Init();
        }
        
    }
    public virtual void Tik()
    {
        if (bonusSpawner != null)
        {
            bonusSpawner.Tik();
        }

        player.Tik();
        spawner.Tik();
    }

    public virtual void ActionTanksCount() { }

    public int GetGamePoints(int val, int point_per_one)
    {
        return val * point_per_one;
    }
}
