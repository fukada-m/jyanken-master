using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    GameObject setting;
    [SerializeField]
    GameObject menuButtons;
    public void OnClickButton()
    {
        setting.SetActive(false);
        menuButtons.SetActive(true);
    }
}
