using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {

    // return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frames = new List<int>();

        // index i points to second bowl of frame
        for(int i = 1; i < rolls.Count; i += 2)
        {
            if(frames.Count == 10) { break; }   // prevents 11th frame score

            if (rolls[i - 1] + rolls[i] < 10) //normal "OPEN" frame
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }
            if(rolls.Count - i <= 1) { break; } // ensure at least one look-ahead available

            if(rolls[i-1] == 10) //STRIKE
            {
                i--; // we need to decrement the index number because strike frame is only one bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10) //calculate SPARE bonus
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }
        
        return frames;

    }

    // returns a list of cumulative scores, like a normal score card
    public static List<int> ScoreCumulative (List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }
}
