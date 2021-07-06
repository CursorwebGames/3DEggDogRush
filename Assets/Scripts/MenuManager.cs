using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void PlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
