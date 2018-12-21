using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverallGameManager : MonoBehaviour {

    public Text timerText;

    private bool modeFinished;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        modeFinished = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (!modeFinished)
        {
            float curTime = Time.time - startTime;

            string minutes = ((int)curTime / 60).ToString();
            string seconds = (curTime % 60).ToString("f2");

            timerText.text = "Time : " + minutes + " : " + seconds;
        }
	}

    public void ToggleModeStatus()
    {
        modeFinished = !modeFinished;
    }
}
