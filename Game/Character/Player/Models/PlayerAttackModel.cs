using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackModel
{
    private Components property;
    private PlayerBattleUI ui;
    private TankObject tank;

    float timer;
    float power_time;

    bool inAuto;

    public PlayerAttackModel(Components property, PlayerBattleUI _ui, TankObject _tank)
    {
        this.property = property;
        ui = _ui;
        tank = _tank;
    }

    public void Tik()
    {
        if(power_time > 0)
        {
            power_time -= Time.deltaTime;
        }
        else
        {
            power_time = 0;
        }

        if (timer >= tank.GetTankType.shoot_rate)
        {
            if(inAuto)
            {
                Shoot();
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (inAuto)
            {
                ui.SetAutoAttackSlider(timer, tank.GetTankType.shoot_rate);
            }
            else
            {
                ui.SetAutoAttackSlider(0, tank.GetTankType.shoot_rate);
            }
        }
    }

    public void SetAuto(bool val)
    {
        inAuto = val;
    }

    public void Shoot()
    {
        property.shoot_effect.Play();
        Bullet bullet = Object.Instantiate(tank.GetTankType.bullet);
        bullet.Init(UnitType.Player, property.shoot_point);
        if(power_time > 0)
            bullet.SetPowerDamage();
        timer = 0;
    }

    public void Dispose()
    {
        
    }

    public void SetPowerTime(float time)
    {
        power_time = time;
    }
}
