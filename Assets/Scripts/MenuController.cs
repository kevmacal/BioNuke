using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string firstLevelName = "Level1";

    public void Play()
    {
        if (GameManager.Instance) GameManager.Instance.ResetTimer();
        SceneManager.LoadScene(firstLevelName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
