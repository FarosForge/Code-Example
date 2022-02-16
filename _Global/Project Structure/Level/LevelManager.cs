using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    private LevelList list;
    private GameModule module;
    private LevelGenerator levelGenerator;
    
    public Wallet wallet { get; private set; }

    private int current_level;
    private bool isOver;

    public LevelManager(LevelList list)
    {
        this.list = list;
    }
    public void Init()
    {
        Load();
        wallet = new Wallet();
        wallet.Init();
        levelGenerator = new LevelGenerator(list);
        module = levelGenerator.GenerateLevel(current_level);
        module.Init(this);
    }
    public void Tik()
    {
        if(!isOver)
        {
            module.Tik();
        }
    }
    private void Load()
    {
        //load current level
        if(SaveSystem.HasKey("CURRENTLEVEL"))
            current_level = SaveSystem.LoadInt("CURRENTLEVEL");
    }
    private void Save()
    {
        //Save current level
        SaveSystem.Save("CURRENTLEVEL", current_level);
    }
    private int CheckLevelID()
    {
        int c = current_level;
        c++;

        if (c >= list.list.Length)
        {
            c = 0;
        }

        return c;
    }
    public void NextLevel()
    {
        current_level = CheckLevelID();
        Save();
    }
    public void LevelIsOver()
    {
        if (isOver) return;

        isOver = true;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
