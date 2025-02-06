using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject handButtons;

    public void onClick()
    {
        menuButtons.SetActive(false);
        handButtons.SetActive(true);
    }
}
