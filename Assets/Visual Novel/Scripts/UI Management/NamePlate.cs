using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {
	void FixedUpdate () {
        if (gameObject.GetComponentInChildren<Text>().text.Equals(""))
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }else
            gameObject.GetComponent<Canvas>().enabled = true;
    }
}
