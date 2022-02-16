using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementModel
{
    private Components property;
    private TankObject tank;
    private Vector2 Input_Direction;
    private Vector3 moveDirection;

    private Joystick joystick;

    float y;

    public PlayerMovementModel(Components _property, Joystick _joy, TankObject _tank)
    {
        property = _property;
        joystick = _joy;
        tank = _tank;
    }

    public void Tik()
    {
        Input_Direction.x = joystick.Horizontal;
        Input_Direction.y = joystick.Vertical;

        Move();

        property.modelView.rotation = Quaternion.LerpUnclamped(property.modelView.rotation, Quaternion.Euler(0, y, 0), tank.GetTankType.speedRotation * Time.deltaTime);

        property.rigidbody.velocity = moveDirection;
    }

    void Move()
    {
        if(Input_Direction.x != 0 && Input_Direction.y != 0)
        {
            if(Input_Direction.x > 0 && Input_Direction.y > 0)
            {
                moveDirection = new Vector3(1 * tank.GetTankType.speed, 0, 0);
                y = 90; 
            }

            if (Input_Direction.x < 0 && Input_Direction.y < 0)
            {
                moveDirection = new Vector3(-1 * tank.GetTankType.speed, 0, 0);
                y = -90;
            }

            if (Input_Direction.x > 0 && Input_Direction.y < 0)
            {
                moveDirection = new Vector3(0, 0, -1 * tank.GetTankType.speed);
                y = 180;
            }

            if (Input_Direction.x < 0 && Input_Direction.y > 0)
            {
                moveDirection = new Vector3(0, 0, 1 * tank.GetTankType.speed);
                y = 0;
            }
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }
}
