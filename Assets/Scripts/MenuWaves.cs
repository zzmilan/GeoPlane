using UnityEngine;

public class MenuWaves : MonoBehaviour
{
    private float br = 0f;

    private AudioSource waves;

    void Start()
    {
        waves = GetComponent<AudioSource>();
        br = 0f;
    }

    void Update()
    {
        br += 0.01f;
        waves.volume = br;
        if (br >= 0.4f) {
            Destroy(GetComponent<MenuWaves>());
        }
    }
}
