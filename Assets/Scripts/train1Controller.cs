using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train1Controller : MonoBehaviour {

    public main main;
    private float speedLocal;
    private bool speedUpdated;

    private void Start()
    {
        speedUpdated = false;
    }

    void Update() {
        if (main.isReady) {
            transform.Translate(main.speed * Vector2.left * Time.deltaTime);
            if (!speedUpdated) {
                speedLocal = main.speed;
                speedUpdated = true;
                transform.position = new Vector2(3.6f + (main.bridgeLength + main.d) / 2, transform.position.y);
            }
        }
        else
        {
            speedUpdated = false;
        }
    }

    public void pause() {
        main.speed = 0;
    }

    public void forward() {
        main.speed = speedLocal;
    }

    public void backward() {
        main.speed = -speedLocal;
    }

    public void returnToStart() {
        transform.position = new Vector2(3.6f + (main.bridgeLength + main.d) / 2, transform.position.y);
    }
}
