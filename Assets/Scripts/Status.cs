using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimer : MonoBehaviour
{
    private bool startupStatus;
    private bool activeFramesStatus;
    private bool recoveryStatus;
    public int startup;
    public int activeFrames;
    public int recovery;
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
            activeFramesStatus = false;
            recoveryStatus = true;
            recovery -= 1;
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
