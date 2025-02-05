using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HandStateTest
{
    GameObject handButtons;
    GameObject menuButtons;
    IState handState;

    [SetUp]
    public void HandStateSetUp()
    {
        handButtons = new GameObject("HandButtons");
        menuButtons = new GameObject("MenuButtons");
        handState = handButtons.AddComponent<HandState>();
        // テストをするためにfalseに設定
        handButtons.SetActive(false);

        // handButtons の依存関係を設定
        typeof(HandState)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(handState, menuButtons);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void DispButton_HandButtons()
    {
        handState.ChangeState();
        Assert.IsTrue(handButtons.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
    }

}
