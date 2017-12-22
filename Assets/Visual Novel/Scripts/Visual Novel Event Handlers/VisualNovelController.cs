using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VisualNovelController : MonoBehaviour {
    /// <summary>
    /// Loads a visual novel scene based on the file name, which is assumed to be in the Text folder of the visual novel controller.
    /// </summary>
    /// <param name="filePath">Path of the file, the file is assumed to be in "Assets/Visual Novel/Text/", so all you need to write is the file name, and ensure it is in the right place.</param>
    public void LoadNewScene(string filePath)
    {
        TextAsset textFile = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Visual Novel/Text/" + filePath, typeof(TextAsset));
        Debug.Log(textFile.text);
    }
}
