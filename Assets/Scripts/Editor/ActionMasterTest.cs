﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{

    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void SetUp()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl28SpareReturnsEndTurn()
    {
        int[] rolls = { 2, 8 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05CheckResetAtSpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06YouTubeRollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07GameEndsAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08Bowl20TidyCondition()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09Bowl20ShootGutterCondition()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T102ndFrame10PinsCondition()
    {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11Dondi10thFrameTurkey()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12ZeroOneGivesEndTurn()
    {
        int[] rolls = { 0, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
}
