using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
    // ‚ ‚¢‚±‚ÌƒeƒXƒg
    [TestCase(0, 0)]
    public void LogicJyankenTestSimplePasses(int player1, int player2)
    {
        // Use the Assert class to test conditions
        var result = LogicJyanken.Judge(player1, player2);
        // ‚ ‚¢‚±‚ÌŽž‚Í0
        Assert.AreEqual(result, 0);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LogicJyankenTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
