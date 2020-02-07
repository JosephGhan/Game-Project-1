using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Edit in Unity")]
    public Text time;
    public float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = Convert.ToInt32(timer % 60);
        time.text = ("Time: " + seconds.ToString());
        
    }
}
