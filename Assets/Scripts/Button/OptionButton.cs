using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    GameObject setting;
    [SerializeField]
    GameObject menuButtons;

    public void onClickButton()
    {
        setting.SetActive(true);
        menuButtons.SetActive(false);
    }
}
