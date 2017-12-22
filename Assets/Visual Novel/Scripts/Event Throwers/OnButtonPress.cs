using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonPress : MonoBehaviour {
    /// <summary>
    /// Uses the VisualNovelController to load a visual novel scene based on the file name, which is assumed to be in the Text folder of the visual novel controller.
    /// </summary>
    /// <param name="fileName">Path of the file, the file is assumed to be in "Assets/Visual Novel/Text/", so all you need to write is the file name, and ensure it is in the right place.</param>
    public void LoadNewScene(string fileName)
    {
        GameObject.FindGameObjectWithTag("VisualNovelController").GetComponent<VisualNovelController>().LoadNewScene(fileName);
    }
}