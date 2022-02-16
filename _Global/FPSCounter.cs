using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public bool toFPS = true;
    GUIStyle style = new GUIStyle();
    int accumulator = 0;
    int counter = 0;
    float timer = 0f;

    [Range(30, 60)]
    public int fps_count;

    void Start()
    {
        Application.targetFrameRate = fps_count;

        if (!toFPS)
            return;

        style.normal.textColor = Color.cyan;
        style.fontSize = 32;
        style.fontStyle = FontStyle.Bold;
    }

    void OnGUI()
    {
        if (!toFPS)
            return;

        GUI.Label(new Rect(10, 10, 100, 34), "FPS: " + counter, style);
    }

    void Update()
    {
        if (!toFPS)
            return;

        accumulator++;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            counter = accumulator;
            accumulator = 0;
        }
    }

}
