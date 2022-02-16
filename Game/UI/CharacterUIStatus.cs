using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIStatus : MonoBehaviour
{
    [SerializeField] private Image hp_progress;
    [SerializeField] private Text character_name;
    [SerializeField] private NamesList list;
    [SerializeField] private string user_name;
    [SerializeField] private Image rank_img;
    [SerializeField] private int rank = -1;

    public void SetProperty()
    {
        if(user_name == "")
        {
            user_name = list.names[Random.Range(0, list.names.Count)];
        }

        if(rank == -1)
        {
            rank = Random.Range(0, list.ranks.Count);
        }

        character_name.text = user_name;
        rank_img.sprite = list.ranks[rank];
    }

    public void UpdateHPProgress(float val, float max)
    {
        hp_progress.fillAmount = val / max;
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
