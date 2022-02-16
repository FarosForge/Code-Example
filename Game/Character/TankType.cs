using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GAME/Create Tank Type")]
public class TankType : ScriptableObject
{
    public float speed;
    public float speedRotation;
    public Bullet bullet;
    public float shoot_rate;

    public int HP;
}
