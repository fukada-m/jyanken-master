using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Collections.Generic;

public class JyankenTest
{
    GameObject handButtonsOBJ;
    GameObject ponButtonOBJ;
    GameObject resultButtonOBJ;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButton;
    Button paperButton;
    Button scissorsButton;
    Button ponButton;
    Button resultButton;
    TMP_Text text;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        //�ŏ���\����HandButtons���擾����
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        handButtonsOBJ = objects.FirstOrDefault(o => o.name == "HandButtons");
        ponButtonOBJ = objects.FirstOrDefault(o => o.name == "PonButton");
        resultButtonOBJ = objects.FirstOrDefault(o => o.name == "ResultButton");
        Assert.IsNotNull(handButtonsOBJ, "�n���h�{�^���I�u�W�F�N�g����낤");
        Assert.IsNotNull(ponButtonOBJ, "�|���{�^���I�u�W�F�N�g����낤");
        Assert.IsNotNull(resultButtonOBJ, "���U���g�{�^���I�u�W�F�N�g����낤");

        //HandButtons�̎q�I�u�W�F�N�g���m�F����
        stoneButtonObj = handButtonsOBJ.transform.Find("StoneButton");
        Assert.IsNotNull(stoneButtonObj, "HandButton�̎q�I�u�W�F�N�g��StoneButton����낤");
        scissorsButtonObj = handButtonsOBJ.transform.Find("ScissorsButton");
        Assert.IsNotNull(scissorsButtonObj, "HandButton�̎q�I�u�W�F�N�g��ScissorsButton����낤");
        paperButtonObj = handButtonsOBJ.transform.Find("PaperButton");
        Assert.IsNotNull(paperButtonObj, "HandButton�̎q�I�u�W�F�N�g��PaperButton����낤");

        //Button�������Ă��邩�m�F����
        stoneButton = stoneButtonObj.GetComponent<Button>();
        Assert.IsNotNull(stoneButton, "StoneButon��Button�R���|�[�l���g�����悤");
        paperButton = paperButtonObj.GetComponent<Button>();
        Assert.IsNotNull(paperButton, "PaperButon��Button�R���|�[�l���g�����悤");
        scissorsButton = scissorsButtonObj.GetComponent<Button>();
        Assert.IsNotNull(scissorsButton, "ScissorsButon��Button�R���|�[�l���g�����悤");
        ponButton = ponButtonOBJ.GetComponent<Button>();
        Assert.IsNotNull(ponButton, "PonButon��Button�R���|�[�l���g���A�^�b�`���悤");
        resultButton = resultButtonOBJ.GetComponent<Button>();
        Assert.IsNotNull(resultButton, "ResultButton��Button�R���|�[�l���g���A�^�b�`���悤");

        text = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        Assert.IsNotNull(text, "TMP�R���|�[�l���g���A�^�b�`����ĂȂ�");
        // �ŏ��ɃX�^�[�g�{�^��������
        var startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.Invoke();
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
        Assert.IsTrue(ponButton.onClick.GetPersistentMethodName(0) == "OnClickButton",
            "�|���{�^����OnClickButton��ݒ肵�悤"
        );
        Assert.IsTrue(resultButton.onClick.GetPersistentMethodName(0) == "OnClickButton",
            "���U���g�{�^����OnClickButton��ݒ肵�悤"
        );
        resultButton = resultButtonOBJ.GetComponent<Button>();

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

    // ����񂯂������e�X�g
    [UnityTest]
    public IEnumerator DoJyankenTest()
    {
        yield return null;
        // �v���C���[�̓O�[��I��
        stoneButton.onClick.Invoke();
        // �|���{�^����������悤�ɂȂ�
        Assert.IsTrue(ponButtonOBJ.activeSelf);
        // �|���{�^�����N���b�N
        ponButton.onClick.Invoke();
        // HandButtons�͔�\���ɂȂ�B
        Assert.IsFalse(handButtonsOBJ.activeSelf);
        // ���U���g�{�^����������悤�ɂȂ�
        Assert.IsTrue(resultButtonOBJ.activeSelf);
        // CPU���I�񂾎��\������
        var expectHand = new List<string> { "����̓O�[��I�т܂���", "����̓p�[��I�т܂���", "����̓`���L��I�т܂���" };
        Assert.That(expectHand, Contains.Item(text.text));
        // ���U���g�{�^�����N���b�N
        resultButton.onClick.Invoke();
        var expectResult = new List<string> { "���ʂ͏����ł�", "���ʂ͂������ł�", "���ʂ͕����ł�" };
        Assert.That(expectResult, Contains.Item(text.text));
    }
}
