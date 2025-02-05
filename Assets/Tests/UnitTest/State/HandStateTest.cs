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
        // ƒeƒXƒg‚ğ‚·‚é‚½‚ß‚Éfalse‚Éİ’è
        handButtons.SetActive(false);

        // handButtons ‚ÌˆË‘¶ŠÖŒW‚ğİ’è
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
