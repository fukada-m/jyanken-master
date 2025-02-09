using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    GameObject setting;
    [SerializeField]
    GameObject menuButtons;

    public void OnClickButton()
    {
        setting.SetActive(true);
        menuButtons.SetActive(false);
    }
}
