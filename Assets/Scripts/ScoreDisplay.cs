using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);
        for(int i = 0; i < scoresString.Length; i++)
        {
            rollTexts[i].text = scoresString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for(int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for(int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1; // score box 1 to 21
            if(rolls[i] == 0)
            {
                output += "-"; // always enter 0 as dash
            }
            else if((box % 2 == 0 || box == 21) && rolls[i-1] + rolls[i] == 10)
            {
                output += "/"; // SPARE
            }
            else if (box >= 19 && rolls[i] == 10)
            {
                output += "X"; // STRIKE in frame 10
            }
            else if(rolls[i] == 10)
            {
                output += "X "; // STRIKE
            }
            else
            {
                output += rolls[i].ToString(); // normal 1-9 bowl
            }
        }
        return output;
    }
}
