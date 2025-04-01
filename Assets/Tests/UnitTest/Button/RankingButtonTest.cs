using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class RankingButtonTest
{
    RankingButton rankingButton;
    Mock<GetRanking> mockGetRanking;
    GameObject rankingModal;
    GameObject menuButtons;
    GameObject messageText;
    [SetUp]
    public void RankingButtonSetUp()
    {
        rankingButton = new GameObject().AddComponent<RankingButton>();
        mockGetRanking = new Mock<GetRanking>();
        rankingModal = new GameObject("RankingModal");
        menuButtons = new GameObject("MenuButtons");
        messageText = new GameObject("MessageText");
        rankingButton.Initialize(rankingModal, menuButtons, messageText, mockGetRanking.Object);

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
        Assert.IsFalse(messageText.activeSelf);
    }

   
}
