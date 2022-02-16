using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private LevelList levelList;
    public LevelGenerator(LevelList levelList)
    {
        this.levelList = levelList;
    }
    public GameModule GenerateLevel(int id)
    {
        return Object.Instantiate(levelList.list[id].prefab);
    }
}
