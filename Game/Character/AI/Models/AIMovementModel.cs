using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementModel
{
    private Components property;
    private TankObject tank;
    Vector3 current_side;

    float timer = 3;

    bool canMove = true;

    int i = 0;

    private GameModule mode;

    private AIType type = AIType.Agressive;

    public bool isCollision;

    Vector3[] sides = new Vector3[4]
    {
        new Vector3(0,0,-1), //back
        new Vector3(1,0,0), // left
        new Vector3(0,0,1), // forward
        new Vector3(-1,0,0) // right
    };

    float[] y = new float[4]
    {
        180,
        90,
        0,
        -90
    };

    float shoot_rate_timer;

    Transform looker;

    float rTime = 0.5f;

    float no_agressive;

    public AIMovementModel(Components property, TankObject _tank, GameModule module)
    {
        this.property = property;
        tank = _tank;
        current_side = sides[0];
        i = property.start_Rotation;
        mode = module;

        int tt = Random.Range(0, 2);

        looker = new GameObject("looker").transform;
        looker.parent = property.my_transform;
        looker.localPosition = Vector3.zero;
    }

    public void Tik()
    {
        canMove = !CheckAllSidesToAttack();

        if (canMove)
        {
            switch (type)
            {
                case AIType.Passive:
                    FreeMove();

                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                    {
                        timer = 3f;
                        ResetSide();
                    }

                    if(no_agressive > 0)
                    {
                        no_agressive -= Time.deltaTime;
                    }
                    else
                    {
                        no_agressive = 0;
                        type = AIType.Agressive;
                    }

                    break;
                case AIType.Agressive:
                        Pathfinding();
                    break;
            }
        }
        else
        {
            property.rigidbody.velocity = Vector3.zero;
            property.modelView.rotation = Quaternion.LerpUnclamped(property.modelView.rotation, Quaternion.Euler(0, y[i], 0), tank.GetTankType.speedRotation * Time.deltaTime);
        }

        if(shoot_rate_timer <= 0)
        {
            if (CheckObjectToAttack())
            {
                Shoot();
                shoot_rate_timer = tank.GetTankType.shoot_rate;
            }
            else
            {
                Shoot();
                shoot_rate_timer = tank.GetTankType.shoot_rate * 2;
            }
        }
        else
        {
            shoot_rate_timer -= Time.deltaTime;
        }


        if (rTime <= 0)
        {
            if (isCollision)
            {
                ResetSide();
                rTime = 0.5f;
                isCollision = false;
            }
        }
        else
        {
            rTime -= Time.deltaTime;
        }

    }

    void Shoot()
    {
        property.shoot_effect.Play();
        Bullet bullet = Object.Instantiate(tank.GetTankType.bullet);
        bullet.Init(UnitType.Enemy, property.shoot_point);
    }

    Vector3 GetSide()
    {
        i = Random.Range(0, 4);

        return sides[i];
    }

    Vector3 GetOnlySide(Sides s)
    {
        return sides[(int)s];
    }

    bool CheckFreeSide()
    {
        if(Physics.Raycast(property.my_transform.position, current_side, 0.7f))
        {
            return false;
        }

        return true;
    }

    bool CheckPathSide(Vector3 s)
    {
        if (Physics.Raycast(property.my_transform.position, s, 0.7f))
        {
            return false;
        }

        return true;
    }

    bool CheckObjectToAttack()
    {
        RaycastHit hit;

        if (Physics.Raycast(property.my_transform.position, current_side, out hit, 1000))
        {
            if (hit.collider.GetComponent<PlayerController>() || hit.collider.GetComponent<BaseManager>())
            {
                return true;
            }
        }

        return false;
    }

    bool CheckAllSidesToAttack()
    {
        for (int y = 0; y < sides.Length; y++)
        {
            RaycastHit hit;

            if (Physics.Raycast(property.my_transform.position, sides[y], out hit, 1000))
            {
                if (hit.collider.GetComponent<PlayerController>() || hit.collider.GetComponent<BaseManager>())
                {
                    no_agressive = 0;
                    current_side = sides[y];
                    i = y;
                    return true;
                }
            }
        }

        return false;
    }

    public void ResetSide()
    {
        current_side = GetSide();
    }

    bool ISeePlayer()
    {
        return Physics.CheckSphere(property.my_transform.position, 3f, property.attack_mask);
    }

    float GetZPlayer
    {
        get { return mode.player.transform.position.z; }
    }

    void Pathfinding()
    {
        if (ISeePlayer())
        {
            if (GetZPlayer < property.my_transform.position.z)
            {
                SetPath(Sides.Back);
            }
            else if (GetZPlayer > property.my_transform.position.z)
            {
                SetPath(Sides.Forward);
            }
        }

        if (property.rigidbody.velocity.Equals(Vector3.zero))
        {
            if (!CheckObjectToAttack())
            {
                no_agressive = 5f;
                type = AIType.Passive;
            }
        }

        FreeMove();
    }

    private void SetPath(Sides s)
    {
        if (CheckPathSide(GetOnlySide(s)))
        {
            current_side = GetOnlySide(s);
            i = (int)s;
        }  
    }

    void FreeMove()
    {
        if (CheckFreeSide())
        {
            property.rigidbody.velocity = current_side * tank.GetTankType.speed;
            property.modelView.rotation = Quaternion.LerpUnclamped(property.modelView.rotation, Quaternion.Euler(0, y[i], 0), tank.GetTankType.speedRotation * Time.deltaTime);
        }
        else
        {
            ResetSide();
        }
    }


}


public enum Sides
{
    Back = 0,
    Left = 1,
    Forward = 2,
    Right = 3
}

public enum AIType
{
    Passive,
    Agressive
}