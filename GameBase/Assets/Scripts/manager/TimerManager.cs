using UnityEngine;
using System.Collections;
using System;

public class TimerManager
{
    private static TimerManager _instance;

    public static TimerManager Instance
    {
        get { if (_instance == null) { _instance = new TimerManager(); } return TimerManager._instance; }
    }

    public string FormatTime(int duration)
    {
        int hour = duration / (60 * 60);
        string str_hour;
        if(hour<1)
        {
            str_hour = "00";
            hour = 0;
        }else if(hour>=1 && hour<10)
        {
            str_hour = "0"+hour;
        }
        else
        {
            str_hour = Convert.ToString(hour);
        }

        int minute = duration%(60*60)/60;
        string str_min;
        if(minute<1)
        {
            str_min = "00";
        }
        else if (minute>=1 && minute<10)
        {
            str_min = "0" + minute;
        }else
        {
            str_min = Convert.ToString(minute);
        }

        int second = duration % (60);
        string str_sec;
        if(second<1)
        {
            str_sec = "00";
        }
        else if (second >=1 && second <10)
        {
            str_sec = "0"+second;
        }
        else
        {
            str_sec = second.ToString();
        }
        return str_hour + ":"+str_min+":"+str_sec;
    }
	
}
