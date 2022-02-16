using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnDown, OnHower, OnUp;

    bool isDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown?.Invoke();
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp?.Invoke();
        isDown = false;
    }

    void LateUpdate()
    {
        if(isDown)
        {
            OnHower?.Invoke();
        }    
    }
}
