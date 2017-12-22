using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour
{
    public GameObject backGround;
    public Text outText;
    public TextAsset tFile;
    //array with lines from tFile
    public string[] lines;
    //line player startsat
    public int startLine;
    //# of current line
    public int currLine;
    //# that player cannot go past
    public int stopLine;

    void Start()
    {
        //sets array lines to the text in script.txt, split at each return
        if (tFile != null)
        {
            lines = (tFile.text.Split('\n'));
        }
        //defaults to length of lines[]-1 if no value is assigned to stopValue
        if (stopLine == 0)
        {
            stopLine = lines.Length - 1;
        }
    }
    void Update()
    {
            //sets text box text to whatever is at line[currline] in the tFile
            outText.text = lines[currLine];
            //increases line # with enter button press
            if (Input.GetKeyDown(KeyCode.Return) && currLine != stopLine)
            {
                currLine++;
            }
    }
}