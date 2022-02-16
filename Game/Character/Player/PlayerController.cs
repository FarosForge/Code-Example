using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private GameModule mode;

    private PlayerMovementModel movement;
    private PlayerAttackModel attackModel;
    private PlayerBattleUI battleUI;

    bool isDisposed;

    public override void Init(GameModule _mode, TankObject tank)
    {
        mode = _mode;
        battleUI = Instantiate(components.battleUI_prefab);
        movement = new PlayerMovementModel(components, battleUI.GetMovementJoystick, tank);
        attackModel = new PlayerAttackModel(components, battleUI, tank);
        battleUI.GetAttackButton.OnDown.AddListener(() => attackModel.Shoot());
        battleUI.GetAttackButton.OnHower.AddListener(() => attackModel.SetAuto(true));
        battleUI.GetAttackButton.OnUp.AddListener(() => attackModel.SetAuto(false));
        mode.ui = battleUI;

        base.Init(mode, tank);
    }

    public override void Tik()
    {
        if (!components.stats.CheckDead())
        {
            movement.Tik();
            attackModel.Tik();
            if(!mode.isOver)
                base.Tik();
        }
        else
        {
            Dispose();

            mode.GameOver(GameOverType.Fail);
        }

        if(mode.isOver)
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        if (isDisposed) return;

        if (components.stats.CheckDead())
        {
            components.dead_effect.Play();
        }

        components.stats.updateStatus -= status.UpdateHPProgress;
        
        if (status != null)
        {
            status.Dispose();
        }
        
        attackModel.Dispose();
    }

    public void SetPowerUp(float time)
    {
        attackModel.SetPowerTime(time);
    }
}



