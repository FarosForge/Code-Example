using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static string GAME_TAG { get { return "NAMEGAME_"; } }
    public static void Save(string name, int val)
    {
        PlayerPrefs.SetInt(GAME_TAG + name, val);
    }
    public static void Save(string name, float val)
    {
        PlayerPrefs.SetFloat(GAME_TAG + name, val);
    }
    public static void Save(string name, string val)
    {
        PlayerPrefs.SetString(GAME_TAG + name, val);
    }
    public static int LoadInt(string name)
    {
        return PlayerPrefs.GetInt(GAME_TAG + name);
    }
    public static float LoadFloat(string name)
    {
        return PlayerPrefs.GetFloat(GAME_TAG + name);
    }
    public static string LoadString(string name)
    {
        return PlayerPrefs.GetString(GAME_TAG + name);
    }
    public static bool HasKey(string name)
    {
        return PlayerPrefs.HasKey(GAME_TAG + name);
    }
}