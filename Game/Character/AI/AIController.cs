using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Character
{
    private AIMovementModel movementModel;
    private GameModule mode;

    bool isDisposed;

    public override void Init(GameModule _mode, TankObject tank)
    {
        movementModel = new AIMovementModel(components, tank, _mode);
        mode = _mode;

        base.Init(mode, tank);
    }

    public override void Tik()
    {
        if(mode.isOver)
        {
            if (status != null)
            {
                status.Dispose();
            }

            return;
        }

        if (!components.stats.CheckDead())
        {
            base.Tik();
            movementModel.Tik();
        }
        else
            Dispose();
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.collider.CompareTag("CanCollision"))
        {
            movementModel.isCollision = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        movementModel.isCollision = false;
    }

    public void Dispose()
    {
        if (isDisposed) return;

        if (components.stats.CheckDead())
        {
            components.dead_effect.Play();
        }

        components.rigidbody.isKinematic = true;
        components.collider.enabled = false;
        isDisposed = true;

        mode.spawner.RemoveAIFromList(this);
        components.stats.updateStatus -= status.UpdateHPProgress;
        status.Dispose();
        Destroy(gameObject, 2f);  
    }
}
