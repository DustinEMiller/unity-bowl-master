using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class OurScoreDisplayTest
{

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1() {
        int[] rolls = {2,3};
        int[] frames = {5};

        

        foreach (var human in frames.ToList()) {
            Debug.Log(human);
        }

        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl234() {
        int[] rolls = { 2,3,4 };
        int[] frames = { 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl2345() {
        int[] rolls = { 2, 3, 4,5  };
        int[] frames = { 5, 9 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl23456() {
        int[] rolls = { 2, 3, 4, 5, 6 };
        int[] frames = { 5, 9 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl234561() {
        int[] rolls = { 2, 3, 4, 5, 6, 1 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl2345612() {
        int[] rolls = { 2, 3, 4, 5, 6, 1, 2 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T07BowlX1() {
        int[] rolls = { 10, 1 };
        int[] frames = {  };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T08Bowl19() {
        int[] rolls = { 1, 9 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T09Bowl123455() {
        int[] rolls = { 1, 2, 3,4,5,5 };
        int[] frames = {3,7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T10SpareBonus() {
        int[] rolls = { 1, 2, 3, 5, 5, 5,3,3 };
        int[] frames = { 3, 8, 13,6 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T11SpareBonus2() {
        int[] rolls = { 1,2,3,5,5,5,3,3,7,1,9,1,6 };
        int[] frames = { 3, 8, 13, 6,8,16 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T12StrikeBonus() {
        int[] rolls = { 10,3,4 };
        int[] frames = { 17,7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T13StrikeBonus3() {
        int[] rolls = { 1,2,3,4,5,4,3,2,10,1,3,3,4 };
        int[] frames = { 3,7,9,5,14,4,7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T14MultiStrikes() {
        int[] rolls = { 10,10,2,3 };
        int[] frames = { 22,15,5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T15MultiStrikes3() {
        int[] rolls = { 10, 10, 2, 3,10,5,3 };
        int[] frames = { 22, 15, 5,18,8 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T16GutterGame() {
        int[] rolls = { 0,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0 };
        int[] frames = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T17AllOnes() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int[] frames = {  2,   4,   6,   8,   10,  12,  14,  16,  18,  20 };
        Debug.Log(frames.ToList());
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T18TestAllStrikes() {
        int[] rolls = { 10,10,10,10,10,10,10,10,10,10,10,10};
        int[] frames = { 30,60,90,120,150,180,210,240,270,300 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T19ImmediateStrikeBonus() {
        int[] rolls = { 5,5,3 };
        int[] frames = { 13 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T20SpareInLastFrame () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,7};
		int[] totalS = {  2,   4,   6,   8,  10,  12,  14,  16,  18,    35};
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreCumulative (rolls.ToList()));
	}

    public void T21StrikeInLastFrame() {
       int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,2,3};
       int[] totalS = { 2,   4,   6,   8,  10,  12,  14,  16,  18,     33};
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    //
    //	[Test]
    //	public void T03Bowl19 () {
    //		int[] rolls = {1,9};
    //		string rollsString = "1/"; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	[Test]
    //	public void T04BowlStrikeInLastFrame () {
    //		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
    //		string rollsString = "111111111111111111X11"; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	[Test]
    //	public void T05Bowl0 () {
    //		int[] rolls = {0};
    //		string rollsString = "-"; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	
    //
    //	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG01GoldenCopyB1of3 () {
    //		int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 8,2,10};
    //		string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG02GoldenCopyB2of3 () {
    //		int[] rolls = { 8,2, 8,1, 9,1, 7,1, 8,2, 9,1, 9,1, 10, 10, 7,1};
    //		string rollsString = "8/819/718/9/9/X X 71";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG03GoldenCopyB3of3 () {
    //		int[] rolls = { 10, 10, 9,0, 10, 7,3, 10, 8,1, 6,3, 6,2, 9,1,10};
    //		string rollsString = "X X 9-X 7/X 8163629/X";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG04GoldenCopyC1of3 () {
    //		int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9};
    //		string rollsString = "72X X X X 7/X X 9/XX9";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG05GoldenCopyC2of3 () {
    //		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
    //		string rollsString = "X X X X 9-X X X X X91";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //

    //
    //	[Test]
    //	public void T02BowlX () {
    //		int[] rolls = {10};
    //		string rollsString = "X "; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	[Test]
    //	public void T03Bowl19 () {
    //		int[] rolls = {1,9};
    //		string rollsString = "1/"; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	[Test]
    //	public void T04BowlStrikeInLastFrame () {
    //		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
    //		string rollsString = "111111111111111111X11"; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	[Test]
    //	public void T05Bowl0 () {
    //		int[] rolls = {0};
    //		string rollsString = "-"; // Remember the space
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
    //	}
    //
    //	
    //
    //	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG01GoldenCopyB1of3 () {
    //		int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 8,2,10};
    //		string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG02GoldenCopyB2of3 () {
    //		int[] rolls = { 8,2, 8,1, 9,1, 7,1, 8,2, 9,1, 9,1, 10, 10, 7,1};
    //		string rollsString = "8/819/718/9/9/X X 71";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG03GoldenCopyB3of3 () {
    //		int[] rolls = { 10, 10, 9,0, 10, 7,3, 10, 8,1, 6,3, 6,2, 9,1,10};
    //		string rollsString = "X X 9-X 7/X 8163629/X";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG04GoldenCopyC1of3 () {
    //		int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9};
    //		string rollsString = "72X X X X 7/X X 9/XX9";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //	
    //	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    //	[Category ("Verification")]
    //	[Test]
    //	public void TG05GoldenCopyC2of3 () {
    //		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
    //		string rollsString = "X X X X 9-X X X X X91";
    //		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //	}
    //
}