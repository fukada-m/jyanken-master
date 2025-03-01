using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;


public class ButtonsTest
{
    GameObject _menuButtonsObj;
    GameObject _startButtonObj;
    Button _startButton;
    GameObject _optionButtonObj;
    Button _optionButton;
    GameObject _handButtons;
    GameObject _settingModal;
    GameObject _returnButtonObj;
    Button _returnButton;
    GameObject _messageText;
    IObserver _observerText;

    [UnitySetUp]
    public IEnumerator ButtonsTestSetUp()
    {
        SceneManager.LoadScene("JyankenScene");
        yield return null;

        _menuButtonsObj = GameObject.Find("MenuButtons");
        Assert.IsNotNull( _menuButtonsObj);
    }

    [UnityTest]
    public IEnumerator OnClickOption_ShowSettingModalAndReturn()
    {
        yield return null;

        // false�ɂȂ��Ă���GameObject���܂߂Ď擾����
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        _settingModal = objects.FirstOrDefault(o => o.name == "SettingModal");
        Assert.IsNotNull(_settingModal);

        _messageText = GameObject.Find("MessageText");
        Assert.IsTrue(_messageText);

        _returnButtonObj = objects.FirstOrDefault(o => o.name == "ReturnButton");
        Assert.IsNotNull(_returnButtonObj);
        _returnButton = _returnButtonObj.GetComponent<Button>();
        Assert.IsNotNull(_returnButton);
        Assert.IsTrue(CheckOnclickButton(_returnButton));


        _optionButtonObj = GameObject.Find("OptionButton");
        Assert.IsNotNull(_optionButtonObj);
        _optionButton = _optionButtonObj.GetComponent<Button>();
        Assert.IsNotNull(_optionButton);
        Assert.IsTrue(CheckOnclickButton(_optionButton));

        // ������Ԃł�MenuButtons�͕\���A�ݒ胂�[�_���͔�\��
        Assert.IsTrue(_menuButtonsObj.activeSelf);
        Assert.IsFalse(_settingModal.activeSelf);

        // �I�v�V�����{�^�����N���b�N����Ɛݒ胂�[�_���Ɩ߂�{�^�����\������A
        // MenuButtons��MessageText�͔�\���ɂȂ�
        _optionButton.onClick.Invoke();
        Assert.IsTrue(_settingModal.activeSelf);
        Assert.IsFalse(_menuButtonsObj.activeSelf);
        Assert.IsFalse(_messageText.activeSelf);

        // �߂�{�^�����N���b�N����ƍĂѐݒ胂�[�_���͔�\���ɂȂ�A
        // MenuButtons��MessageText���\�������
        _returnButton.onClick.Invoke();
        Assert.IsFalse(_settingModal.activeSelf);
        Assert.IsTrue(_menuButtonsObj.activeSelf);
        Assert.IsTrue(_messageText.activeSelf);
    }
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator onClickStartButton_ShowHandButton()
    {
        yield return null;

        // false�ɂȂ��Ă���HandButtons���擾����
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        _handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
        Assert.IsFalse(_handButtons.activeSelf);
        _startButtonObj = GameObject.Find("StartButton");
        Assert.IsNotNull(_startButtonObj);
        _startButton = _startButtonObj.GetComponent<Button>();
        Assert.IsNotNull(_startButton);
        Assert.IsTrue(CheckOnclickButton(_startButton));
        // �X�^�[�g�{�^�����N���b�N����ƃ��b�Z�[�W���\�������
        // HandButtons���\�������
        // MenuButtons�͔�\���ɂȂ�B
        _startButton.onClick.Invoke();
        _observerText = GameObject.Find("MessageText").GetComponent<IObserver>();
        Assert.AreEqual(_observerText.GetText(), "���̎���o�������߂Ă�������");
        Assert.IsTrue(_handButtons.activeSelf);
        Assert.IsFalse(_menuButtonsObj.activeSelf);

    }

    // �����Ă���Button�ɁAOnClickButton���Z�b�g����Ă��邩�m�F����
    bool CheckOnclickButton(Button b)
    {
        return (b.onClick.GetPersistentMethodName(0) == "OnClickButton");
    }
}
