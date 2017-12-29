using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionMasterTest
{

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster actionMaster;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void Setup () {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T023Bowl8ReturnsTidy () {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T04Bowl28ReturnsEndTurn () {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame () {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T06CheckResetAtStpareInLastFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        actionMaster.Bowl(1);
        Assert.AreEqual(reset, actionMaster.Bowl(9));
    }

    [Test]
    public void T07YouTubeRollsIsEndInEndGame () {
        int[] rolls = { 8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }

    [Test]
    public void T08GameEndsAtBowl20() {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test]
    public void T09DarylBowl20Test() {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }

    [Test]
    public void T10BensBowl20Test() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test]
    public void T11NathanBowlIndexTest() {
        int[] rolls = { 0,10,5};

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }

    [Test]
    public void T12Dondi10thFrameTurkey() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};

        foreach (int roll in rolls) {
            actionMaster.Bowl(roll);
        }

        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test]
    public void T13ZeroOneGivesEndTurn() {
        actionMaster.Bowl(0);
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }

}