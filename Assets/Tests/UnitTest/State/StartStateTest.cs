using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StartStateTest
{
    GameObject menuButtons;
    IState startState;

    [SetUp]
    public void StartStateSetUp()
    {
        menuButtons = new GameObject("MenuButtons");
        startState = menuButtons.AddComponent<StartState>();
    }
    // A Test behaves as an ordinary method
    [Test]
    public void DispButton_StartAndOption()
    {
        startState.DispButton();
        Assert.IsTrue(menuButtons.activeSelf);
    }

}
