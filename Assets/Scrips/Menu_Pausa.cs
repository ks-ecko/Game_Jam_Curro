using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Pausa : MonoBehaviour
{
    public GameObject menuPausa; // Cambié el nombre del GameObject a minúscula

    public bool IsPaused;
    

    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false); // Cambié False a minúscula
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        menuPausa.SetActive(true); // Cambié True a minúscula
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        menuPausa.SetActive(false); // Cambié False a minúscula
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
