using UnityEngine;

public class StartState : MonoBehaviour, IState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DispButton()
    {
        this.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        // �X�^�[�g���͉B���{�^���͂Ȃ�
    }
}
