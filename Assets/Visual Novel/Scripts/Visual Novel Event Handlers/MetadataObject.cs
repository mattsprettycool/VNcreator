using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetadataObject : ScriptableObject {
    string defaultName = "";
    string objName = "";
    bool hasName = false;
    string voice = "";
    bool hasVoice = false;
    float defaultSpeed = .005f;
    float speed = 0;
    bool hasSpeed = false;
    public void SetName(string myName)
    {
        objName = myName;
        hasName = true;
    }
    public string GetName()
    {
        if(hasName)
            return objName;
        return defaultName;
    }
    public void SetVoice(string myVoice)
    {
        voice = myVoice;
        hasVoice = true;
    }
    public bool HasVoice()
    {
        return hasVoice;
    }
    public string GetVoice()
    {
        return voice;
    }
    public void SetSpeed(float mySpeed)
    {
        speed = mySpeed;
        hasSpeed = true;
    }
    public float GetSpeed()
    {
        if (hasSpeed)
            return speed;
        return defaultSpeed;
    }
}
