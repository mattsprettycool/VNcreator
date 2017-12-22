using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VisualNovelController : MonoBehaviour {
    int textFileLine = 0;
    bool sceneIsLoaded = false;
    bool textIsLoaded = false;
    string debugVoice = "justmetalking.ogg";
    string[] rawTextLines;
    string[] textLines;
    string[] metadataLines;
    /// <summary>
    /// Loads a visual novel scene based on the file name, which is assumed to be in the Text folder of the visual novel controller.
    /// </summary>
    /// <param name="filePath">Path of the file, the file is assumed to be in "Assets/Visual Novel/Text/", so all you need to write is the file name, and ensure it is in the right place.</param>
    public void LoadNewScene(string filePath)
    {
        sceneIsLoaded = true;
        TextAsset textFile = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Visual Novel/Text/" + filePath, typeof(TextAsset));
        rawTextLines = textFile.text.Split('\n');
        SplitMetadata(rawTextLines);
        gameObject.GetComponent<TextController>().SetTextBoxText(textLines[0], .005f, debugVoice);
        gameObject.GetComponent<TextController>().SetNameBoxText(metadataLines[0]);
        textFileLine = 1;
    }
    private void Update()
    {
        bool continueKeyDown = Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return);
        if (sceneIsLoaded&&textFileLine< textLines.Length)
        {
            if (gameObject.GetComponent<TextController>().SceneIsFinishedFlowing() && continueKeyDown)
            {
                gameObject.GetComponent<TextController>().SetTextBoxText(textLines[textFileLine], .005f, debugVoice);
                gameObject.GetComponent<TextController>().SetNameBoxText(metadataLines[textFileLine]);
                textFileLine++;
            }else if (continueKeyDown)
            {
                gameObject.GetComponent<TextController>().SkipFlowingText();
            }
        }else if(sceneIsLoaded&&continueKeyDown)
            gameObject.GetComponent<TextController>().SkipFlowingText();
    }
    private void SplitMetadata(string[] rawText)
    {
        metadataLines = new string[rawTextLines.Length];
        textLines = new string[rawTextLines.Length];
        int i = 0;
        foreach (string obj in rawText) {
            metadataLines[i] = obj.Substring(obj.IndexOf("{"), obj.IndexOf("}") + 1);
            textLines[i] = obj.Substring(obj.IndexOf(">") + 1);
            i++;
            }
        }
    }
