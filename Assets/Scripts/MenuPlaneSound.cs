using UnityEngine;

public class MenuPlaneSound : MonoBehaviour
{
    private float br = 0f;

    private AudioSource plane;

    void Start()
    {
        plane = GetComponent<AudioSource>();
        br = 0f;
    }

    void Update()
    {
        br += 0.01f;
        plane.volume = br;
        if (br >= 0.5f)
        {
            Destroy(GetComponent<MenuWaves>());
        }
    }
}
