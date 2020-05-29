using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BizerCurve : MonoBehaviour {

    public Transform tranp0;
    public Transform tranp1;
    public Transform tranp2;

    public Transform tranTarget;

    public float TotalTime = 5;
    
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("FirstJoinAlliance", 1);
        PlayerPrefs.GetInt("FirstJoinAlliance", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartMoveBizer();
            PlayerPrefs.DeleteAll();
        }
	}

    void StartMoveBizer()
    {
        float currTime = 0f;
        DOTween.To(() => { return currTime; },
            x =>
            {
                currTime = x;
                tranTarget.position = tranp0.position * (1 - 2 * currTime / TotalTime + currTime * currTime / TotalTime * TotalTime)
                                                    + tranp1.position * (2 * currTime / TotalTime - 2 * currTime * currTime / TotalTime * TotalTime)
                                                    + tranp2.position * currTime * currTime / TotalTime * TotalTime;
            },
            TotalTime, 5.0f
            );
    }
}
