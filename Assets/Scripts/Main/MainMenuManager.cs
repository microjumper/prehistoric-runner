using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadPrologue()
    {
        SceneManager.LoadScene("Prologue");
    }
}
