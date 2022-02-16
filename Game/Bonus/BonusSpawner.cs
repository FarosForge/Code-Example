using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawn_points;
    [SerializeField] BonusObject[] objects;
    [SerializeField] float spawn_delay;

    private float timer;

    public void Init()
    {
        timer = spawn_delay;
    }

    public void Tik()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int rand_point = Random.Range(0, spawn_points.Length);
        int rand_bonus = Random.Range(0, objects.Length);

        var bonus = Instantiate(objects[rand_bonus]);
        bonus.transform.position = spawn_points[rand_point].position;
        bonus.Init();

        timer = spawn_delay;
    }
}
