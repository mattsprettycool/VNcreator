using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    bool hasTextToUpdate = false;
    string currentText = "";
    string flowingText = "";
    float mySpeedRatio = .005f;
    float currentSpeedVal = 0;
    bool usingVoice = false;
    bool spokeAlready = false;
    AudioClip voice;
    public void UseTextLine(string metadata, string text)
    {
        MetadataObject myMetadata = gameObject.GetComponent<MetadataCompiler>().CompileMetadata(metadata);
        SetNameBoxText(myMetadata.GetName());
        if (myMetadata.HasVoice())
        {
            SetTextBoxText(text, myMetadata.GetSpeed(), myMetadata.GetVoice());
        }
        else
            SetTextBoxText(text, myMetadata.GetSpeed());

    }
    public void SetTextBoxText(string text, float speedRatio)
    {
        currentText = text;
        flowingText = "";
        mySpeedRatio = speedRatio;
        hasTextToUpdate = true;
        usingVoice = false;
    }
    public void SetTextBoxText(string text, float speedRatio, string voiceFile)
    {
        currentText = text;
        flowingText = "";
        mySpeedRatio = speedRatio;
        hasTextToUpdate = true;
        usingVoice = true;
        voice = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Visual Novel/Sound/Voices/" + voiceFile, typeof(AudioClip));
    }
    public void SetNameBoxText(string text)
    {
        GameObject.FindGameObjectWithTag("Name").GetComponent<Text>().text = text;
    }
    public bool SceneIsFinishedFlowing()
    {
        return !hasTextToUpdate;
    }
    public void SkipFlowingText()
    {
        if (hasTextToUpdate)
        {
            flowingText = currentText;
            currentSpeedVal = 0;
            hasTextToUpdate = false;
            GameObject.FindGameObjectWithTag("TextBox").GetComponent<Text>().text = flowingText;
        }
    }
    private void Update()
    {
        if (hasTextToUpdate)
        {
            if (currentSpeedVal <= 0)
            {
                bool noPunc =  !currentText.Substring(flowingText.Length, 1).Contains(".") && !currentText.Substring(flowingText.Length, 1).Contains("!") && !currentText.Substring(flowingText.Length, 1).Contains("?");
                if (usingVoice && !currentText.Substring(flowingText.Length, 1).Contains(" ") && noPunc && !spokeAlready)
                {
                    GetComponent<AudioSource>().PlayOneShot(voice);
                    spokeAlready = true;
                }
                else
                    spokeAlready = false;
                flowingText += currentText.Substring(flowingText.Length, 1);
                if (!noPunc)
                {
                    currentSpeedVal = mySpeedRatio * 2;
                }else
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
