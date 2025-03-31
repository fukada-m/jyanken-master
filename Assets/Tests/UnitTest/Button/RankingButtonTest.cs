using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RankingButtonTest
{
    RankingButton rankingButton;
    GameObject rankingModal;
    [SetUp]
    public void RankingButtonSetUp()
    {
        rankingButton = new GameObject().AddComponent<RankingButton>();
        rankingModal = new GameObject("RankingModal");
        rankingButton.Initialize(rankingModal);

        //�e�X�g�p�ɍŏ��̓����L���O���[�_�����\���ɂ���
        rankingModal.SetActive(false);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void RankingButtonTestShowRanking()
    {
        rankingButton.OnClickButton();
        Assert.IsTrue(rankingModal.activeSelf);
    }

   
}
