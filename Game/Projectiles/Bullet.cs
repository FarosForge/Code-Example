using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private UnitType type;

    public void Init(UnitType unit, Transform position)
    {
        type = unit;
        transform.position = position.position;
        transform.rotation = position.rotation;
    }

    void Update()
    {
        transform.Translate(-transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.TryGetComponent<Stats>(out var stats))
        {
            stats.GetHit(damage);
        }

        //switch (type)
        //{
        //    case UnitType.Player:

        //        if(col.GetComponent<AIController>())
        //        {
                    
        //        }

        //        break;
        //    case UnitType.Enemy:

        //        if (col.GetComponent<PlayerController>())
        //        {
        //            if (col.TryGetComponent<Stats>(out var stats))
        //            {
        //                stats.GetHit(damage);
        //            }
        //        }

        //        break;
        //    case UnitType.Ally:
        //        break;
        //}

        Destroy(gameObject);
    }
    public void SetPowerDamage()
    {
        damage *= 2;
    }
}
