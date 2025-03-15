using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public void OnClickButton()
    {
        SceneManager.LoadScene("JyankenScene");
    }
}
