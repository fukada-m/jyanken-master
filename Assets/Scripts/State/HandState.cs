using UnityEngine;

public class HandState : MonoBehaviour, IState
{
    [SerializeField]
    GameObject menuButtons;

    public void ChangeState()
    {
        DispButton();
        HideButton();
    }
    void DispButton()
    {
        this.gameObject.SetActive(true);
    }

    void HideButton()
    {
        menuButtons.SetActive(false);
    }
}
