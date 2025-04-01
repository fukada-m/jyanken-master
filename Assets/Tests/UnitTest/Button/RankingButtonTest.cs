using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RankingButtonTest
{
    RankingButton rankingButton;
    GameObject rankingModal;
    GameObject menuButtons;
    //GameObject optionButton;
    GameObject messageText;
    //GameObject rankingButtonOBJ;
    [SetUp]
    public void RankingButtonSetUp()
    {
        //rankingButtonOBJ = new GameObject();
        rankingButton = new GameObject().AddComponent<RankingButton>();
        rankingModal = new GameObject("RankingModal");
        menuButtons = new GameObject("MenuButtons");
        //startButton = new GameObject("StartButton");
        //optionButton = new GameObject("OptionButton");
        messageText = new GameObject("MessageText");
        rankingButton.Initialize(rankingModal, menuButtons, messageText);

        //テスト用に最初はランキングモーダルを非表示にする
        rankingModal.SetActive(false);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void RankingButtonTestShowRanking()
    {
        rankingButton.OnClickButton();
        Assert.IsTrue(rankingModal.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
        //Assert.IsFalse(optionButton.activeSelf);
        Assert.IsFalse(messageText.activeSelf);
        //Assert.IsFalse(rankingButtonOBJ.activeSelf);
    }

   
}
