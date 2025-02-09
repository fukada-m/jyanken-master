using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject menuButtons;
    public void OnClickButton()
    {
        settingModal.SetActive(false);
        menuButtons.SetActive(true);
    }
}
