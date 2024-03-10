using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using static Mushroom;

public class Brew 
{

    public Brew()
    {
        // foreach (var k in content.Keys)
        // {
        //     content[k] = 0;
        // }
        ColorUtility.TryParseHtmlString("#64E6FF", out defaultColor);
    }

    private Dictionary<FungiType, int> content = new Dictionary<FungiType, int>();
    private List<Color> colors = new List<Color>();

    private Color defaultColor; 

    public void AddMushroom(Mushroom mushy)
    {
        Debug.Log("Added " + mushy.type);

        // content[mushy.type] += 1;

        Color c = Color.white;
        switch (mushy.type)
        {
            case FungiType.Red:
            c = Color.red;
            break;
            case FungiType.Green:
            c = Color.green;
            break;
            case FungiType.Purple:
            c = Color.magenta;
            break;
            case FungiType.Brown:
            c = Color.yellow;
            break;
            case FungiType.DarkRed:
            c = Color.grey;
            break;
        }
        
        Debug.Log("Added color " + c);
        colors.Add(c);
    }

    public Color GetColor()
    {
        if (colors.Count == 0)
        {
            return defaultColor;
        }

        var invertedColorSum = Color.black;
        foreach (var color in colors)
        {
            invertedColorSum += Color.white - color;
        }

        return Color.white - invertedColorSum / colors.Count;
    }


}
