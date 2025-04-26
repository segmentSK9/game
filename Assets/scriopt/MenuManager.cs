using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the Main Gameplay scene
        SceneManager.LoadScene("MAIN");
    }

    public void OpenVisitors()
    {
        // Load the Visitor scene
        SceneManager.LoadScene("VISITOR");
    }

    public void OpenSettings()
    {
        // Optional: You can either open a Settings panel or another scene
        Debug.Log("Settings Clicked"); // (For now, just a debug log)
        // Or if you have a Settings scene: SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
        Debug.Log("Game is exiting..."); // This will only show inside the editor
    }
}
