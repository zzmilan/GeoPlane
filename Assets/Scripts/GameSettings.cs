using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject childPlane;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private GameObject play;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private AudioClip click;

    private bool isPaused;

    public static bool done;
    public static bool finished;

    private AudioSource propeller;
    private AudioSource cameraSound;

    void Start()
    {
        isPaused = false;
        done = false;
        finished = false;

        play.SetActive(false);

        propeller = childPlane.GetComponent<AudioSource>();

        cameraSound = cam.GetComponent<AudioSource>();
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && done && !finished)
        {
            cameraSound.clip = click;
            cameraSound.Play();
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (finished) {
            play.SetActive(false);
            pause.SetActive(false);
        }
    }
    public void Resume()
    {
        propeller.UnPause();

        play.SetActive(false);
        pause.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        propeller.Pause();

        play.SetActive(true);
        pause.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu1");
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
