using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClueBoxFormatter
{
    // in pixels
    private static int averageCharacterWidth = 8;
    private static int averageCharacterHeight = 8;
    private static int maxCharactersInLine = 30;

    public static TextWithDimensions Adjust(string text)
    {
        //int width = 220;
        int height = 0;
        string formattedText = "";

        int currentCharactersInLine = 0;
        int lineWidth;

        string[] delimiters = new string[] { " " };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        for(int i = 0; i < words.Length; i++)
        {
            if (currentCharactersInLine > maxCharactersInLine)
            {
                formattedText += "\n\n";
                height += 2;
                currentCharactersInLine = 0;
            }
            formattedText += words[i] + " ";
            currentCharactersInLine += 1 + words[i].Length;
        }

        if (height <= 1)
        {
            lineWidth = Mathf.Min(formattedText.Length - 2, maxCharactersInLine - 3);
            if (lineWidth <= 0)
                lineWidth = 3;
            height = 2;
        }
        else
        {
            lineWidth = maxCharactersInLine - 3;
            height++;
        }
        
        return new TextWithDimensions(
            lineWidth * averageCharacterWidth,
            height * averageCharacterHeight,
            formattedText);
    }
}