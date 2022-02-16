using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGeneration : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] color_mapping;

    public List<GameObject> list = new List<GameObject>();

    float[] rot = new float[4]
    {
        0,
        90,
        -90,
        180
    };

    public void Generate()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach (var color in color_mapping)
        {
            if(color.color.Equals(pixelColor))
            {
                var obj = Instantiate(color.prefab);
                obj.transform.parent = this.transform;
                obj.transform.localScale = Vector3.one;
                obj.transform.localPosition = new Vector3(x, 0, z);
                obj.transform.localRotation = Quaternion.Euler(0, rot[Random.Range(0, rot.Length)], 0);
            }
        }
    }

    public void Reset()
    {
        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i]);
        }

        list.Clear();
    }
}

[System.Serializable]
public struct ColorToPrefab
{
    public GameObject prefab;
    public Color color;
}