using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClueBoxFormatter
{
    // in pixels
    private static int averageCharacterWidth = 6;
    private static int averageCharacterHeight = 8;
    private static int lineWidth = 140;

    public static TextWithDimensions Adjust(string text)
    {
        int width = 220;
        int height = 0;
        string formattedText = "";

        int currentLineWidth = 0;

        string[] delimiters = new string[] { " " };

        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        for(int i = 0; i < words.Length; i++)
        {
            formattedText += words[i] + " ";
            currentLineWidth += 1 + words[i].Length * averageCharacterWidth;
            if (currentLineWidth > lineWidth)
            {
                formattedText += "\n\n";
                height += 2;
                currentLineWidth = 0;
            }
        }
            height -= 2;
            if (height <= 0)
                height = 2;
        return new TextWithDimensions(width, height * averageCharacterHeight, formattedText);
    }
}