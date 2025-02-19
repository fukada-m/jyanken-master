using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using Moq;
using System.Linq;

public class JyankenTest
{
    GameObject handButtonsOBJ;
    HandButtons handButtons;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButton;
    Button paperButton;
    Button scissorsButton;
    Button ponButton;
    TMP_Text text;

    Sign.Hand Stone = Sign.Hand.Stone;
    Sign.Hand Paper = Sign.Hand.Paper;
    Sign.Hand Scissors = Sign.Hand.Scissors;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        //�ŏ���\����HandButtons���擾����
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        handButtonsOBJ = objects.FirstOrDefault(o => o.name == "HandButtons");
        var ponButtonOBJ = objects.FirstOrDefault(o => o.name == "PonButton");
        Assert.IsNotNull(handButtonsOBJ, "�n���h�I�u�W�F�N�g����낤");
        handButtons = handButtonsOBJ.GetComponent<HandButtons>();
        Assert.IsNotNull(handButtons, "HandButtons���A�^�b�`���悤");
        // HandButtons�͍ŏ���\���ɂȂ��Ă��邩��\������
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        handButtonsOBJ.SetActive(true);

        //HandButtons�̎q�I�u�W�F�N�g���m�F����
        Assert.IsTrue(handButtonsOBJ.activeSelf);
        stoneButtonObj = handButtonsOBJ.transform.Find("StoneButton");
        Assert.IsNotNull(stoneButtonObj, "Hand�̎q�I�u�W�F�N�g��StoneButton����낤");
        scissorsButtonObj = handButtonsOBJ.transform.Find("ScissorsButton");
        Assert.IsNotNull(scissorsButtonObj, "Hand�̎q�I�u�W�F�N�g��ScissorsButton����낤");
        paperButtonObj = handButtonsOBJ.transform.Find("PaperButton");
        Assert.IsNotNull(paperButtonObj, "Hand�̎q�I�u�W�F�N�g��PaperButton����낤");

        //Button�������Ă��邩�m�F����
        stoneButton = stoneButtonObj.GetComponent<Button>();
        Assert.IsNotNull(stoneButton, "StoneButon��Button�R���|�[�l���g�����悤");
        paperButton = paperButtonObj.GetComponent<Button>();
        Assert.IsNotNull(paperButton, "PaperButon��Button�R���|�[�l���g�����悤");
        scissorsButton = scissorsButtonObj.GetComponent<Button>();
        Assert.IsNotNull(scissorsButton, "ScissorsButon��Button�R���|�[�l���g�����悤");
        ponButton = ponButtonOBJ.GetComponent<Button>();
        Assert.IsNotNull(ponButton, "PonButon��Button�R���|�[�l���g���A�^�b�`���悤");

        text = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        Assert.IsNotNull(text, "TMP�R���|�[�l���g���A�^�b�`����ĂȂ�");
        // �ŏ��ɃX�^�[�g�{�^��������
        var startButton = GameObject.Find("StartButton").GetComponent<StartButton>();
        startButton.OnClickButton();
        Assert.AreEqual("���̎���o�������߂Ă�������", text.text);

        // �{�^���Ƀ��\�b�h���A�^�b�`���Ă��邩�m�F����
        Assert.IsTrue(stoneButton.onClick.GetPersistentMethodName(0) == "OnClickStoneButton",
            "Stone�{�^����OnClickStoneButton()��ݒ肵�悤"
        );
        Assert.IsTrue(scissorsButton.onClick.GetPersistentMethodName(0) == "OnClickScissorsButton",
            "scissors�{�^����OnClickScissorsButton()��ݒ肵�悤"
        );
        Assert.IsTrue(paperButton.onClick.GetPersistentMethodName(0) == "OnClickPaperButton",
            "paper�{�^����OnClickPaperButton()��ݒ肵�悤"
        );

    }

    // �n���h�{�^���𕡐��񉟂����Ƃ��̃e�X�g
    [UnityTest]
    public IEnumerator HandButtonsClickTest()
    {

        //�O�[�{�^�����V�~�����[�g
        stoneButton.onClick.Invoke();
        Assert.AreEqual("���Ȃ��̓O�[��I��ł��܂�", text.text);

        //�p�[�{�^�����V�~�����[�g
        paperButton.onClick.Invoke();
        Assert.AreEqual("���Ȃ��̓p�[��I��ł��܂�", text.text);

        //�`���L�{�^�����V�~�����[�g
        scissorsButton.onClick.Invoke();
        Assert.AreEqual("���Ȃ��̓`���L��I��ł��܂�", text.text);

        //�ēx�O�[�{�^�����V�~�����[�g
        stoneButton.onClick.Invoke();
        Assert.AreEqual("���Ȃ��̓O�[��I��ł��܂�", text.text);

        yield return null;
    }

    [UnityTest]
    public IEnumerator DoJyankenTest()
    {
        yield return null;
        stoneButton.onClick.Invoke();
        ponButton.onClick.Invoke();
        // HandButtons�͔�\���ɂȂ�B
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        // CPU���I�񂾎��\������

    }
}
