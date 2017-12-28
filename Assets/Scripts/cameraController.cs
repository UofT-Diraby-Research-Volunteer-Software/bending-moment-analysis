using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    private bool alreadySet;
    public main main;

    void Start()
    {
        alreadySet = false;
        transform.position = new Vector3(-82.1f, -42.5f, -100);
    }

    void Update()
    {
        if (!main.isReady) alreadySet = false;
        if (main.isReady && !alreadySet) transform.position = new Vector3(0, 0,-15);
    }

    public void returnToDashboard() {
        transform.position = new Vector3(-82.1f, -42.5f, -100);
    }
}
