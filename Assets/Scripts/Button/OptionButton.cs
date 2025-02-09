using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject menuButtons;

    public void OnClickButton()
    {
        settingModal.SetActive(true);
        menuButtons.SetActive(false);
    }
}
