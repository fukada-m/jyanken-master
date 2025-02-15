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
    GameManager gameManager;
    HandButtons handButtons;
    ObserverText observerText;

    GameObject textObject;
    GameObject gameManagerObj;
    ObserverText ot;
    Transform stoneButtonObj;
    Transform scissorsButtonObj;
    Transform paperButtonObj;
    Button stoneButtonComp;
    Button paperButtonComp;
    Button scissorsButtonComp;
    TMP_Text text;

    Sign.Hand Stone = Sign.Hand.Stone;
    Sign.Hand Paper = Sign.Hand.Paper;
    Sign.Hand Scissors = Sign.Hand.Scissors;

    [SetUp]
    public void JyankenTestSetUp()
    {
        gameManager = new GameObject().AddComponent<GameManager>();
        handButtons = new GameObject().AddComponent<HandButtons>();
        observerText = new GameObject().AddComponent<ObserverText>();
        //hand = new GameObject().AddComponent<Hand>();
        //hand.AddObserver(observerText);
    }

    //[UnitySetUp]
    //public IEnumerator Setup()
    //{
    //    SceneManager.LoadScene("JyankenScene");
    //    yield return null;

    //    //�Q�[���I�u�W�F�N�g�������Ă��邩�m�F����
    //    GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
    //    handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
    //    Assert.IsNotNull(handButtons, "�n���h�I�u�W�F�N�g����낤");
    //    // HandButtons�͍ŏ���\���ɂȂ��Ă���
    //    handButtons.SetActive(true);
    //    gameManagerObj = GameObject.Find("GameManager");
    //    Assert.IsNotNull(gameManagerObj, "GameManager���I�u�W�F�N�g���쐬���悤");
    //    stoneButtonObj = handButtons.transform.Find("StoneButton");
    //    Assert.IsNotNull(stoneButtonObj, "Hand�̎q�I�u�W�F�N�g��StoneButton����낤");
    //    scissorsButtonObj = handButtons.transform.Find("ScissorsButton");
    //    Assert.IsNotNull(scissorsButtonObj, "Hand�̎q�I�u�W�F�N�g��ScissorsButton����낤");
    //    paperButtonObj = handButtons.transform.Find("PaperButton");
    //    Assert.IsNotNull(paperButtonObj, "Hand�̎q�I�u�W�F�N�g��PaperButton����낤");
    //    observerText = GameObject.Find("ObserverText");
    //    Assert.IsNotNull(observerText, "�n���h�I�u�U�[�o�[���Ȃ��B");
    //    textObject = GameObject.Find("Message");
    //    Assert.IsNotNull(textObject, "�e�L�X�g�I�u�W�F�N�g���Ȃ�");


    //    //�R���|�[�l���g�������Ă��邩�m�F����
    //    gameManager = gameManagerObj.GetComponent<GameManager>();
    //    Assert.IsNotNull(gameManager, "GameManager�R���|�[�l���g���A�^�b�`���悤");
    //    hand = handButtons.GetComponent<Hand>();
    //    Assert.IsNotNull(hand, "Hand�X�N���v�g��ǉ����悤");
    //    stoneButtonComp = stoneButtonObj.GetComponent<Button>();
    //    Assert.IsNotNull(stoneButtonComp, "StoneButon��Button�R���|�[�l���g�����悤");
    //    paperButtonComp = paperButtonObj.GetComponent<Button>();
    //    Assert.IsNotNull(paperButtonComp, "PaperButon��Button�R���|�[�l���g�����悤");
    //    scissorsButtonComp = scissorsButtonObj.GetComponent<Button>();
    //    Assert.IsNotNull(scissorsButtonComp, "ScissorsButon��Button�R���|�[�l���g�����悤");
    //    text = textObject.GetComponent<TMP_Text>();
    //    Assert.IsNotNull(text, "TMP�R���|�[�l���g���A�^�b�`����ĂȂ�");
    //    Assert.AreEqual("�o��������߂Ă�������", text.text);
    //    ot = observerText.GetComponent<ObserverText>();
    //    Assert.IsNotNull(ot, "�n���h�I�u�U�[�o�[�X�N���v�g���Ȃ��B");

    //    // �{�^���Ƀ��\�b�h���A�^�b�`���Ă��邩�m�F����
    //    Assert.IsTrue(stoneButtonComp.onClick.GetPersistentMethodName(0) == "onClickStoneButton",
    //        "Stone�{�^����OnClickStoneButton()��ݒ肵�悤"
    //    );
    //    Assert.IsTrue(scissorsButtonComp.onClick.GetPersistentMethodName(0) == "onClickScissorsButton",
    //        "scissors�{�^����OnClickScissorsButton()��ݒ肵�悤"
    //    );
    //    Assert.IsTrue(paperButtonComp.onClick.GetPersistentMethodName(0) == "onClickPaperButton",
    //        "paper�{�^����OnClickPaperButton()��ݒ肵�悤"
    //    );

    //}

    //// �{�^������������I�u�U�[�o�[�ɒʒm���s�����e�X�g
    //[UnityTest]
    //public IEnumerator HandButtonsTest()
    //{
    //    // �I�u�U�[�o�[���ǉ��ł��邩�e�X�g
    //    var mock = new Mock<IObserver>();
    //    mock.Setup(service => service.Up(hand));
    //    hand.AddObserver(mock.Object);
    //    var observer = hand.GetObserver(0);
    //    Assert.IsInstanceOf<IObserver>(observer, "IObserver�^�ł͂Ȃ�����");

    //    //�O�[�{�^�����V�~�����[�g
    //    stoneButtonComp.onClick.Invoke();
    //    Assert.AreEqual(hand.Current, Stone);
    //    //�p�[�{�^�����V�~�����[�g
    //    paperButtonComp.onClick.Invoke();
    //    Assert.AreEqual(hand.Current, Paper);
    //    //�`���L�{�^�����V�~�����[�g
    //    scissorsButtonComp.onClick.Invoke();
    //    Assert.AreEqual(hand.Current, Scissors);

    //    // �I�u�U�[�o�[�ɒʒm������Ă��邩�e�X�g�B�{�^����3�񉟂�������3��Ă΂�Ă���B
    //    mock.Verify(service => service.Up(hand), Times.Exactly(3));

    //    yield return null;
    //}

    //// �n���h�̏�Ԃɂ���ăe�L�X�g�������������邩�e�X�g
    //[UnityTest]
    //public IEnumerator ObserverTest()
    //{
    //    // ���b�N���쐬
    //    var mock = new Mock<IHand>();

    //    //�@�����\��
    //    Assert.AreEqual("�o��������߂Ă�������", text.text);

    //    // �O�[��I�񂾏ꍇ
    //    mock.Setup(p => p.Current).Returns(Stone);
    //    //�@�e�L�X�g�̕\�����ς����邩�e�X�g
    //    ot.Up(mock.Object);
    //    Assert.AreEqual("�O�[��I��ł��܂�", text.text);

    //    // �p�[��I�񂾏ꍇ
    //    mock.Setup(p => p.Current).Returns(Paper);
    //    //�@�e�L�X�g�̕\�����ς����邩�e�X�g
    //    ot.Up(mock.Object);
    //    Assert.AreEqual("�p�[��I��ł��܂�", text.text);

    //    // �`���L��I�񂾏ꍇ
    //    mock.Setup(p => p.Current).Returns(Scissors);
    //    //�@�e�L�X�g�̕\�����ς����邩�e�X�g
    //    ot.Up(mock.Object);
    //    Assert.AreEqual("�`���L��I��ł��܂�", text.text);

    //    yield return null;
    //}

    //// �n���h�{�^���̌����e�X�g
    //[UnityTest]
    //public IEnumerator JoinTest()
    //{

    //    //�O�[�{�^�����V�~�����[�g
    //    stoneButtonComp.onClick.Invoke();
    //    Assert.AreEqual("�O�[��I��ł��܂�", text.text);

    //    //�p�[�{�^�����V�~�����[�g
    //    paperButtonComp.onClick.Invoke();
    //    Assert.AreEqual("�p�[��I��ł��܂�", text.text);

    //    //�`���L�{�^�����V�~�����[�g
    //    scissorsButtonComp.onClick.Invoke();
    //    Assert.AreEqual("�`���L��I��ł��܂�", text.text);

    //    yield return null;
    //}
}
