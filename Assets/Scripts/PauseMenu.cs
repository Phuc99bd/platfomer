using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(isPause);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        pauseUI.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1;
    }

    public void resume()
    {
        isPause = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }
}
