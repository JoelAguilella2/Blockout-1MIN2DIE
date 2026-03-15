using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public void GoBackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
