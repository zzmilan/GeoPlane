using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    private TextMeshProUGUI timeText;

    public static float startTime;
    public static bool timeStart = false;

    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timeStart)
        {
            time = Time.time - startTime;
        }
        if ((time % 60).ToString("0") != "60")
        {
            timeText.text = ((int)time / 60).ToString() + ":" + (time % 60).ToString("0");
        }
        if (((int)time / 60) == 60) {
            SceneManager.LoadScene("menu1");
        }
    }
}
