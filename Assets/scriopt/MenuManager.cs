using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene");  // Put your real scene name here
    }

    public void StartVisitorMode()
    {
        SceneManager.LoadScene("SampleScene");  // Same scene for now
    }

    public void OpenSettings()
    {
        Debug.Log("Settings clicked!");
        // You can show a settings panel later here
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
