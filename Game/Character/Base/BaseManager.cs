using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : Character
{
    [SerializeField] TankObject tank;
    [SerializeField] GameModule mode;

    void Start()
    {
        Init(mode, tank);
    }

    public override void Init(GameModule _mode, TankObject tank)
    {
        mode = _mode;
        base.Init(_mode, tank);
    }

    void Update()
    {
        if(mode.isOver)
        {
            Dispose();
            return;
        }

        if (components.stats.CheckDead())
        {
            Dispose();
            mode.GameOver(GameOverType.Fail);
            return;
        }

        Tik();
    }

    public void Dispose()
    {

        if (status != null)
        {
            components.stats.updateStatus -= status.UpdateHPProgress;
            status.Dispose();
        }

        
    }
}
