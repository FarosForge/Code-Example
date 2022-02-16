using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GAME/Create Names List")]
public class NamesList : ScriptableObject
{
    public List<string> names;
    public List<Sprite> ranks;
}
