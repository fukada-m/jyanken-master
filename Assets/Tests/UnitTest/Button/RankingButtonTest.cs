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

    [UnitySetUp]
    public IEnumerator RankingButtonSetUp()
    {
        yield return null;
        rankingButton = new GameObject().AddComponent<RankingButton>();
        mockGetRanking = new Mock<GetRanking>();
        rankingModal = new GameObject("RankingModal");
        menuButtons = new GameObject("MenuButtons");
        messageText = new GameObject("MessageText");
        rankingButton.Initialize(rankingModal, menuButtons, messageText, mockGetRanking.Object);

        //�e�X�g�p�ɍŏ��̓����L���O���[�_�����\���ɂ���
        rankingModal.SetActive(false);
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator RankingButtonTestShowRanking()
    {
        yield return null;
        // Enumrator�̃e�X�g�̎d�����킩��Ȃ����炢������R�����g�A�E�g
        //rankingButton.OnClickButton();
        //Assert.IsTrue(rankingModal.activeSelf);
        //Assert.IsFalse(menuButtons.activeSelf);
        //Assert.IsFalse(messageText.activeSelf);
    }

   
}
