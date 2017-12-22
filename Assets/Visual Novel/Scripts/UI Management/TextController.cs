using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    bool hasTextToUpdate = false;
    string currentText = "";
    string flowingText = "";
    float mySpeedRatio = .005f;
    float currentSpeedVal = 0;
    public void SetTextBoxText(string text, float speedRatio)
    {
        currentText = text;
        flowingText = "";
        mySpeedRatio = speedRatio;
        hasTextToUpdate = true;
    }
    public void SetNameBoxText()
    {

    }
    private void Update()
    {
        if (hasTextToUpdate)
        {
            if (currentSpeedVal <= 0)
            {
                flowingText += currentText.Substring(flowingText.Length, 1);
                currentSpeedVal = mySpeedRatio;
            }
            else
                currentSpeedVal -= Time.deltaTime;
            GameObject.FindGameObjectWithTag("TextBox").GetComponent<Text>().text = flowingText;
            if (flowingText.Length == currentText.Length)
                hasTextToUpdate = false;
        }
    }
}
