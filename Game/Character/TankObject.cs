using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GAME/Create Tank Object")]
public class TankObject : ScriptableObject
{
    [SerializeField] private TankType type;
    [SerializeField] private Character tank_prefab;

    public TankType GetTankType { get { return type; } }
    public Character GetPrefab { get { return tank_prefab; } }
}
