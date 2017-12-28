using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class everythingAdjuster : MonoBehaviour {

    public Transform train1;
    public main main;
    private int n;
    private float d;
    private float alpha;
    private float linkLength;
    private int trainValue;
    private Transform body, link;
    private bool trainbuilt;

	void Start () {
        trainbuilt = false;
    }
	
	void Update () {
        if (main.isReady)
        {
            if (!trainbuilt)
            {
                buildTrain();
                trainbuilt = true;
            }
            setAllPositions();
        }
        else
        {
            trainbuilt = false;
        }
	}

    private void setAllPositions() {
        if (trainValue != 1)
        {
            transform.position = new Vector2((trainValue - 1) * (d + linkLength) + train1.position.x, train1.position.y);
        }
    }

    private void buildTrain()
    {
        n = main.n;
        d = main.d;
        alpha = main.alpha;
        linkLength = main.linkLength;
        trainValue = int.Parse(gameObject.name.Substring(5, 2));
        body = transform.GetChild(0);
        if (trainValue != 14) link = transform.GetChild(3);
        if (trainValue > n) gameObject.SetActive(false);
        transform.GetChild(0).localScale = new Vector2(d, body.localScale.y);
        if (trainValue != 14) transform.GetChild(3).localScale = new Vector2(linkLength, link.localScale.y);
        if (trainValue != 14) transform.GetChild(3).localPosition = new Vector2((linkLength + d) / 2, -0.25f);
        transform.GetChild(1).localPosition = new Vector2((alpha - 0.5f) * d, -0.98f);
        transform.GetChild(2).localPosition = new Vector2((0.5f - alpha) * d, -0.98f);
        trainbuilt = true;
    }
}
