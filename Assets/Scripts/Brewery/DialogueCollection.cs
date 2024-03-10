using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueCollectionAsset : ScriptableObject
{
    public DialogueAsset[] dialogs;

    public int[] sequence;
    public string goalPotion;
    public DialogueCollectionAsset nextGoal;
}
