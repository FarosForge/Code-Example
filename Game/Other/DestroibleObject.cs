using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroibleObject : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private GameObject[] mesh_variants;
    [SerializeField] private Collider collider;

    int i = 0;

    void Start()
    {
        i = mesh_variants.Length - 1;
        stats.Init(40);
        stats.hitAction += UpdateView;
    }

    void UpdateView()
    {
        if (i <= 0)
        {
            return;
        }

        foreach (var item in mesh_variants)
        {
            item.SetActive(false);
        }

        i--;

        if (i <= 0)
        {
            collider.enabled = false;
            stats.hitAction -= UpdateView;
            i = 0;
        }

        mesh_variants[i].SetActive(true);
    }
}
