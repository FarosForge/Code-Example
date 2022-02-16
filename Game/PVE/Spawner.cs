using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private SpawnType type;
    [SerializeField] private int max_ai_count_on_scene = 3;
    [SerializeField] private int targets_count;
    [SerializeField] private float spawn_delay;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameModule mode;

    private float timer;
    private List<Character> ai_list = new List<Character>();
    public int Count { get { return targets_count; } }

    int sp = 0;

    [SerializeField] TankObject[] tanks;

    public void Tik()
    {
        if(!CheckFullList())
        {
            Spawn();
        }

        for (int i = 0; i < ai_list.Count; i++)
        {
            var bot = ai_list[i];
            bot.Tik();
        }
    }

    void Spawn()
    {
        if (type == SpawnType.Clamp && targets_count <= 0) { return; }

        if (timer <= 0)
        {
            int rand = Random.Range(0, tanks.Length);
            var ai = Instantiate(tanks[rand].GetPrefab);
            ai.transform.position = points[GetPointID()].position;
            ai_list.Add(ai);
            ai.Init(mode, tanks[rand]);
            RemoveTargetsCount();
            timer = spawn_delay;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void RemoveTargetsCount()
    {
        if (targets_count <= 0 || type == SpawnType.Unclamped) { return; }

        targets_count--;

        if(targets_count <= 0)
        {
            targets_count = 0;
        }
    }

    bool CheckFullList()
    {
        if(ai_list.Count >= max_ai_count_on_scene)
        {
            return true;
        }

        return false;
    }

    public void AddAIToList(AIController bot)
    {
        ai_list.Add(bot);
    }

    public void RemoveAIFromList(AIController bot)
    {
        ai_list.Remove(bot);

        mode.ActionTanksCount();
    }

    private int GetPointID()
    {
        int i = sp;

        sp++;

        if(sp >= points.Length)
        {
            sp = 0;
        }

        return i;
    }

    public void DestroyAllEnemy()
    {
        foreach (var bot in ai_list)
        {
            bot.components.stats.GetHit(1000);
        }
    }
}

public enum SpawnType
{
    Clamp,
    Unclamped
}
