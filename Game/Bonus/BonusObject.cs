using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusObject : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public IBonusEffect effect;
    public float destroy_delay;

    public void Init()
    {
        Destroy(gameObject, destroy_delay);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.TryGetComponent<PlayerController>(out var player))
        {
            triggerEvent?.Invoke();
            effect.BonusAction(player.gameObject);
            Destroy(gameObject);
        }
    }
}
