using System;
using UnityEngine;
public class Timer{

    private bool b_Tricking;

    private float f_CurTime;

    private float f_TriggerTime;

    public delegate void EventHandler();

    public event EventHandler tick;
    public event EventHandler endCallback;

    private float b_interval_time;

    public Timer(float second,float interval_time = 1)
    {
        f_CurTime = 0.0f;
        f_TriggerTime = second;
        b_interval_time = interval_time;
    }
    
	public void Start()
    {
        b_Tricking = true;
    }

    private float startTime;
    private int time=0;

    public void Update(float deltaTime)
    {
        if (b_Tricking)
        {
            startTime += deltaTime;
            if (startTime >= b_interval_time)
            {
                startTime = 0f;
                tick();
            }

            if (f_CurTime >= f_TriggerTime)
            {
                Stop();
            }

        }
    }
	

    public void Stop()
    {
        b_Tricking = false;
    }

    public void Continue()
    {
        b_Tricking = true;
    }

    public void Restart()
    {
        b_Tricking = true;
        f_CurTime = 0.0f;
    }

    public void ResetTriggerTime(float second)
    {
        f_TriggerTime = second;
    }
}
