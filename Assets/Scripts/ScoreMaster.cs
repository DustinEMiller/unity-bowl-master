using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ScoreMaster
{

    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // Return a list of individual frame scores.
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frames = new List<int>();

        // Index i points to 2nd bowl of frame
        for (int i = 1; i < rolls.Count; i += 2) {
            if (frames.Count == 10) { break; }              

            if (rolls[i - 1] + rolls[i] < 10) {             
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1) { break; }                

            if (rolls[i - 1] == 10) {
                i--;                                        
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10) {      
                frames.Add(10 + rolls[i + 1]);
            }
        }
        return frames;
    }
}
