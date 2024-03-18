using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject flashbang;
    [SerializeField]
    private GameObject video;
    [SerializeField]
    private GameObject waves;
    [SerializeField]
    private GameObject planeObject;
    [SerializeField]
    private float divideTime = 2f;

    private Image image;
    private bool fade = false;
    private float br = 1f;



    private void Start()
    {
        image = flashbang.GetComponent<Image>();
    }

    void Update() {
        if (fade)
        {
            br -= Time.deltaTime / divideTime;
            image.color = new Color(0f, 0f, 0f, br);

            if (image.color.a <= 0f)
            {
                Destroy(flashbang);
                fade = false;
                Destroy(GetComponent<SplashScreen>());
            }
        }
        else if (Time.time >= 8f)
        {
            fade = true;
            waves.SetActive(true);
            planeObject.SetActive(true);
            Destroy(video);
        }
    }
}
