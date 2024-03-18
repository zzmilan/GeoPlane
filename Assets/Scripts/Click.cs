using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private AudioClip click;

    private AudioSource cameraSound;

    void Start()
    {
        cameraSound = cam.GetComponent<AudioSource>();
    }

    public void ClickyClicky()
    {
        cameraSound.clip = click;
        cameraSound.Play();
    }
}
