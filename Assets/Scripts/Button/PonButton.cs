using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    public void onClickButton()
    {
        handButtons.SetActive(false);
    }
}
