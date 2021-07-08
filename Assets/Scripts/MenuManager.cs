using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void PlayScene()
    {
        SceneManager.LoadScene(2);
    }

    public static void HowScene()
    {
        SceneManager.LoadScene(1);
    }

    public static void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
