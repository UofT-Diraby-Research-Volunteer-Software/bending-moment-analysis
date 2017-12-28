using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{ 
    public int n;
    public float d, alpha, linkLength, bridgeLength, weight, speed;
    private float weightOnEachWheel, reactionA, reactionB;
    public Transform[] leftWheelSelector;
    public Transform[] rightWheelSelector;
    public float[] leftWheelPositions, rightWheelPositions;
    public Transform leftSupport, rightSupport;
    private int leftCounter, rightCounter, totalNumberOfWheels;
    private float totalMomentByWheels;
    private Vector2[] shearForceValues;
    private float bendingMomentCurrent, bendingMomentMax;
    private float bendingMomentMaxPosition;
    private bool addRightWheel;
    public InputField nInput, dInput, lInput, wInput, speedInput, linkInput, alphaInput;
    public InputField currentMoment, currentMomentPosition, maxMoment, maxMomentPosition;
    private bool exception;
    public bool isReady;
    private int i, j;
    public Text warning;
    public GameObject[] trains;

    public void sanitiseParameters()
    {
        if (int.TryParse(nInput.text, out n)) {
            if (!(n > 0 && n <= 14)) {
                exception = true;
            }
        }
        else {
            exception = true;
        }
        if (float.TryParse(dInput.text, out d)) {
            if (!(d >= 3 && d <= 6)) {
                exception = true;
            }
        }
        else {
            exception = true;
        }
        if (!float.TryParse(linkInput.text, out linkLength)) exception = true;
        if (float.TryParse(wInput.text, out weight))
        {
            if (!(weight >= 200 && d <= 900))
            {
                exception = true;
            }
        }
        else
        {
            exception = true;
        }
        if (float.TryParse(alphaInput.text, out alpha))
        {
            if (!(alpha >= 18 && alpha <= 26))
            {
                exception = true;
            }
            else
            {
                alpha /= 100;
            }
        }
        else
        {
            exception = true;
        }
        if (float.TryParse(lInput.text, out bridgeLength))
        {
            if (!(bridgeLength >= 35 && bridgeLength <= 52))
            {
                exception = true;
            }
        }
        else
        {
            exception = true;
        }

        if (float.TryParse(speedInput.text, out speed))
        {
            if (!(speed >= 0 && speed <= 5))
            {
                exception = true;
            }
        }
        else
        {
            exception = true;
        }

        if (!exception)
        {
            setAllParameters();
            warning.text = "";
        }
        else
        {
            warning.text = "One of your variables is out of bounds!";
            exception = false;
        }
    }

    public void setAllParameters()
    {
        weightOnEachWheel = weight / 2;
        leftWheelPositions = new float[n];
        rightWheelPositions = new float[n];
        for (int k =0; k <n; k++)
        {
            trains[k].SetActive(true);
        }
        isReady = true;
    }

    void Start()
    {
        exception = false;
        isReady = false;
        bendingMomentMax = 0;
    }

    void Update()
    {
        if (isReady) {

            getPositions();
            bendingMomentCurrent = 0;
            shearForceValues = new Vector2[totalNumberOfWheels + 2];
            shearForceValues[0] = new Vector2(0, reactionA);
            shearForceValues[totalNumberOfWheels + 1] = new Vector2(bridgeLength, 0);
            if (rightWheelPositions[0] < leftWheelPositions[0] && rightWheelPositions[0] != -10 && leftWheelPositions[0] !=-10)
            {
                addRightWheel = true;
            }
            else
            {
                addRightWheel = false;
            }
            if (leftWheelPositions[0] == -10)
            {
                addRightWheel = true;
            }

            leftCounter = 0;
            rightCounter = 0;

            for (j = 1; j <= totalNumberOfWheels; j++)
            {
                if (!addRightWheel)
                {
                    shearForceValues[j].x = leftWheelPositions[leftCounter];
                    leftCounter += 1;
                    addRightWheel = true;
                }
                else if (addRightWheel)
                {
                    shearForceValues[j].x = rightWheelPositions[rightCounter];
                    rightCounter += 1;
                    addRightWheel = false;
                }

                shearForceValues[j].y = reactionA - j * weightOnEachWheel;
            }

            j = 0;
            while (shearForceValues[j].y > 0)
            {
                bendingMomentCurrent += shearForceValues[j].y * (shearForceValues[j + 1].x - shearForceValues[j].x);
                j += 1;
            }
            if (bendingMomentCurrent > bendingMomentMax)
            {
                bendingMomentMax = bendingMomentCurrent;
                bendingMomentMaxPosition = shearForceValues[j].x;
            }
            currentMoment.text = bendingMomentCurrent.ToString();
            currentMomentPosition.text = shearForceValues[j].x.ToString();
            maxMoment.text = bendingMomentMax.ToString();
            maxMomentPosition.text = bendingMomentMaxPosition.ToString();
        }
    }

    private void getPositions()
    {
        totalMomentByWheels = rightCounter = leftCounter = 0;
        for (i = 0; i < n; i++)
        {
            leftWheelPositions[i] = -10; // some unachievable value
            rightWheelPositions[i] = -10;
        }

        for (i = 0; i < n; i++)
        {
            if (leftWheelSelector[i].position.x >= leftSupport.position.x && leftWheelSelector[i].position.x <= rightSupport.position.x)
            {
                leftWheelPositions[leftCounter] = leftWheelSelector[i].position.x - leftSupport.position.x;
                totalMomentByWheels += weightOnEachWheel * leftWheelPositions[leftCounter];
                leftCounter += 1;
            }
            if (rightWheelSelector[i].position.x >= leftSupport.position.x && rightWheelSelector[i].position.x <= rightSupport.position.x)
            {
                rightWheelPositions[rightCounter] = rightWheelSelector[i].position.x - leftSupport.position.x;
                totalMomentByWheels += weightOnEachWheel * rightWheelPositions[rightCounter];
                rightCounter += 1;
            }
        }
        totalNumberOfWheels = leftCounter + rightCounter;
        reactionB = totalMomentByWheels / bridgeLength;
        reactionA = totalNumberOfWheels * weightOnEachWheel - reactionB;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void returnToDashboard() {
        isReady = false;
        bendingMomentMax = 0;
        bendingMomentMaxPosition = 0;
        maxMoment.text = "0";
        maxMomentPosition.text = "0";
    }
}

//for (j = 0; j<shearForceValues.Length; j++)
  //      {
    //        Debug.Log(string.Concat(shearForceValues[j].x, "     ", shearForceValues[j].y));
      //  }
//Debug.Log(string.Concat("left wheel ", i.ToString(), ":    ", leftWheelPositions[i].ToString()));
// Debug.Log(string.Concat("right wheel ", i.ToString(), ":    ", rightWheelPositions[i].ToString()));
