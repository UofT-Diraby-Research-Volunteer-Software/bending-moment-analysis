using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeSet : MonoBehaviour {

    public main main;
    private bool bridgeBuilt;

	void Start () {
        bridgeBuilt = false;
	}

    private void Update()
    {
        if (main.isReady && !bridgeBuilt)
        {
            transform.GetChild(0).localScale = new Vector2(main.bridgeLength, 0.5f);
            transform.GetChild(1).localPosition = new Vector2(-main.bridgeLength / 2, -0.75f);
            transform.GetChild(2).localPosition = new Vector2(main.bridgeLength / 2, -0.75f);
            bridgeBuilt = true;
        }
        else if (!main.isReady) {
            bridgeBuilt = false;
        }
    }
}
