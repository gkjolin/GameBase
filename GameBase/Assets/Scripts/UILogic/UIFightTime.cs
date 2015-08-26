using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIFightTime : MonoBehaviour {

    private Text lbl_time;
    private Timer timer;
    private int duration_time = 0;
	void Start () {
        Init();	
	}

    private void Init()
    {
        lbl_time = transform.GetComponent<Text>();
        timer =new Timer(1);
        timer.tick += OnTimer;
        timer.endCallback += OnTimerEnd;
        timer.Start();

    }

    private void OnTimerEnd()
    {

    }

    private void OnTimer()
    {
        duration_time++;
        lbl_time.text = TimerManager.Instance.FormatTime(duration_time);
    }
	void Update () {
        timer.Update(Time.deltaTime);
	}
}
