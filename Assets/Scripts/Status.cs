using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private bool startupStatus;
    private bool activeFramesStatus;
    private bool recoveryStatus;
    
    private int startup;
    private int activeFrames;
    private int recovery;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startup > 0)
        {
            startupStatus = true;
            startup -= 1;
        }
        else if (activeFrames > 0)
        {
            startupStatus = false;
            activeFramesStatus = true;
            activeFrames -= 1;
        }
        else if (recovery > 0)
        {
            startupStatus = false;
            activeFramesStatus = false;
            recoveryStatus = true;
            recovery -= 1;
        }
        else
        {
            startupStatus = false;
            activeFramesStatus = false;
            recoveryStatus = false;
        }
    }

    public void FramesUpdate(List<int> frames)
    {
        if (frames.Count == 3)
        {
            startup += frames[0];
            activeFrames += frames[1];
            recovery += frames[2];
        }
        else
        {
            Debug.LogError("ОШИБКА В УКАЗАНИИ КАДРОВ! Получаемые значения:  " + string.Join(",", frames.ToArray()));
        }
    }

    public String GetFrameStatus()
    {
        if (startupStatus)
        {
            return "startup";
        }
        else if (activeFramesStatus)
        {
            return "activeFrames";
        }
        else if (recoveryStatus)
        {
            return "recovery";
        }
        else
        {
            return "neutral";
        }
    }
}
