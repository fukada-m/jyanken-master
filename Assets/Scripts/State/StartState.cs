using UnityEngine;

public class StartState : MonoBehaviour, IState
{
    public void ChangeState()
    {
        DispButton();
    }

    public void DispButton()
    {
        this.gameObject.SetActive(true);
    }
}
