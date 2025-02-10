using UnityEngine;
/* 
 * �ŏ��̏����ł�邱�� 
 * - �g��Ȃ��{�^���̔�\��
 * - �I�u�U�[�o�[�̃Z�b�g
 */

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject ponButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideObject();
        SetObserver();
    }
    void HideObject()
    {
        handButtons.SetActive(false);
        settingModal.SetActive(false);
        ponButton.SetActive(false);
    }
    void SetObserver()
    {

    }
}
