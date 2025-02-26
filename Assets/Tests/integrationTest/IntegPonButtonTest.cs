using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class IntegPonButtonTest
{
    GameObject handButtonsOBJ;
    GameObject ponButtonOBJ;
    GameObject resultButtonOBJ;
    GameObject messageTextOBJ;
    PonButton ponButton;
    IObserver messageText;
    Notify notify;
    TMP_Text text;
    ILogicJyanken logicJyanken;
    IEnemyHand enemyHand;
    IHand hand;
    IResult result;

    [SetUp]
    public void SetUp()
    {
        handButtonsOBJ = new GameObject("HandButtons");
        ponButtonOBJ = new GameObject("PonButton");
        resultButtonOBJ = new GameObject("ResultButton");
        // 最初はリザルトボタンは非表示
        resultButtonOBJ.SetActive(false);
        ponButton = new GameObject().AddComponent<PonButton>();
        messageTextOBJ = new GameObject("MessageText");
        messageText = messageTextOBJ.AddComponent<ObserverText>();
        text = messageTextOBJ.AddComponent<TextMeshProUGUI>();
        notify = new Notify();
        messageText.Initialize(text);
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
        hand = new Hand();
        result = new Result();

        ponButton.Initialize(
            handButtonsOBJ,
            ponButtonOBJ,
            resultButtonOBJ,
            notify, 
            logicJyanken,
            enemyHand,
            hand,
            result
        );

    }

    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_EnemyPickHand()
    {
        ponButton.OnClickButton();
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        // 今のCPUの使用だとグーしか出さない
        Assert.AreEqual(text.text, "相手はグーを選びました");
        Assert.IsFalse(ponButtonOBJ.activeSelf);
        Assert.IsTrue(resultButtonOBJ.activeSelf);
    }

}
