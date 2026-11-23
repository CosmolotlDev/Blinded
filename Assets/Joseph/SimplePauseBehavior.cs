using UnityEngine;
using UnityEngine.Events;
public class SimplePauseBehavior : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject notPausedUI;
    public bool isPaused = false;

    public bool inputPauseDown = false;
    public UnityEvent onPause, onResume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();


        if(inputPauseDown)
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void getInput()
    {
        
        inputPauseDown = Input.GetKeyDown(KeyCode.Escape);
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        notPausedUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        onResume.Invoke();
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        notPausedUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        onPause.Invoke();
    }
}
