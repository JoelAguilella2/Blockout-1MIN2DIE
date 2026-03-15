using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    [SerializeField] Animator Hand;
    [SerializeField] Animator Beer;

    [SerializeField] Animator Panel;

    [SerializeField] GameObject ExitButton;
    [SerializeField] GameObject CreditsPanel;


    private void Awake()
    {
        ExitButton.SetActive(Application.platform != RuntimePlatform.WebGLPlayer);

        Cursor.lockState = CursorLockMode.None;
    }
    private void Start()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
        }
    }
    public void PressPlay()
    {
        Hand.Play("DRINK");
        Beer.Play("DRINK");
        StartCoroutine(WaitSix());
    }
    private IEnumerator WaitSix()
    {
        yield return new WaitForSeconds(5.5f);

        Panel.Play("DISOLVE");

        yield return new WaitForSeconds(2.1f);

        SceneManager.LoadScene(1);
    }

    public void AbrirCreditos()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(true);
        }
       
    }

    public void CerrarCreditos()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
            
        }
        
    }



    public void PressExit()
    {
        Application.Quit();
    }
}
