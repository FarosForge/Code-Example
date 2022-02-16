using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats : MonoBehaviour
{
    public Action<float, float> updateStatus;
    public Action hitAction;

    [SerializeField] int HP;
    [SerializeField] int MaxHP;

    float undestroy_time;

    public void Init(int m_hp)
    {
        MaxHP = m_hp;
        HP = MaxHP;
        updateStatus?.Invoke(HP, MaxHP);
    }

    public void GetHit(int val)
    {
        if (undestroy_time > 0) return;
        if (CheckDead()) return;

        HP -= val;

        updateStatus?.Invoke(HP, MaxHP);
        hitAction?.Invoke();

        CheckDead();
    }

    public void Tik()
    {
        if(undestroy_time > 0)
        {
            undestroy_time -= Time.deltaTime;
        }
        else
        {
            undestroy_time = 0;
            return;
        }
    }

    public bool CheckDead()
    {
        if(HP <= 0)
        {
            return true;
        }

        return false;
    }

    public void AddHP(int val)
    {
        if (HP >= MaxHP) return;

        HP += val;

        if(HP >= MaxHP)
        {
            HP = MaxHP;
        }

        updateStatus?.Invoke(HP, MaxHP);
    }

    public void SetUndestroyTime(float time)
    {
        undestroy_time = time;
    }
}
