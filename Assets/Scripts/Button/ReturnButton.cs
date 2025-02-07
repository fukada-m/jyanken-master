using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    GameObject setting;
    [SerializeField]
    GameObject menuButtons;
    public void onClickButton()
    {
        setting.SetActive(false);
        menuButtons.SetActive(true);
    }
}
