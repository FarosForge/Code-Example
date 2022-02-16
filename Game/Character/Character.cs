using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Components components;
    
    [HideInInspector]
    public CharacterUIStatus status;
    [HideInInspector]
    public TankObject reference;

    public virtual void Init(GameModule _mode, TankObject tank)
    {
        reference = tank;
        components.stats.Init(tank.GetTankType.HP);
        status = Instantiate(components.status_view_prefab);
        status.transform.parent = FindObjectOfType<PlayerBattleUI>().transform;
        status.transform.localScale = Vector3.one;
        components.stats.updateStatus += status.UpdateHPProgress;
        status.SetProperty();
    }

    public virtual void Tik()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        status.transform.position = pos;

        components.stats.Tik();
    }
}

[System.Serializable]
public struct Components
{
    public Transform modelView;
    public Rigidbody rigidbody;
    public Collider collider;
    public Transform my_transform;
    public Transform shoot_point;
    public LayerMask ray_mask;
    public LayerMask attack_mask;
    public int start_Rotation;
    public PlayerBattleUI battleUI_prefab;
    public Stats stats;
    public CharacterUIStatus status_view_prefab;
    public ParticleSystem shoot_effect;
    public ParticleSystem dead_effect;
}
