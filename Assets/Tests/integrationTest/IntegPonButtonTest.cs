using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using System.Collections.Generic;

public class IntegPonButtonTest
{
    GameObject handButtonsOBJ;
    GameObject ponButtonOBJ;
    GameObject resultButtonOBJ;
    PonButton ponButton;
    IObserver messageText;
    Notify notify;
    TMP_Text text;
    ILogicJyanken logicJyanken;
    EnemyHand enemyHand;
    Hand hand;
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
        messageText = new GameObject().AddComponent<ObserverText>();
        text = new GameObject().AddComponent<TextMeshProUGUI>();
        notify = new Notify();
        messageText.Initialize(text);
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
        hand = new PlayerHand();
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
        var expect = new List<string> { "相手はグーを選びました", "相手はパーを選びました", "相手はチョキを選びました" };
        ponButton.OnClickButton();
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        Assert.That(expect, Contains.Item(text.text));
        Assert.IsFalse(ponButtonOBJ.activeSelf);
        Assert.IsTrue(resultButtonOBJ.activeSelf);
    }

}
