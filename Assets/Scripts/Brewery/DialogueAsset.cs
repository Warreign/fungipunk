using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu]
public class DialogueAsset : ScriptableObject
{
    [TextArea]
    public string[] dialogue;

    private int linePosition = -1;

    public string nextLine()
    {
        linePosition++;

        Debug.Log("" + this.name + ": " + linePosition);
        if (linePosition >= dialogue.Length)
        {
            return String.Empty;
        }

        return dialogue[linePosition];
    }

    public void clear()
    {
        linePosition = -1;
    }
}
