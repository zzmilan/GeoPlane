using UnityEngine;

public class TriggerNizije : MonoBehaviour
{
    [SerializeField]
    private Material checkpointMat;
    [SerializeField]
    private Material sphereMat;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private AudioClip correct;
    [SerializeField]
    private AudioClip incorrect;

    private AudioSource cameraSound;

    void Start()
    {
        cameraSound = cam.GetComponent<AudioSource>();
    }

    void OnTriggerEnter() {
        if (!TheLaw.collided)
        {
            if (gameObject.name == Nizije.word)
            {
                cameraSound.clip = correct;
                cameraSound.Play();
                Nizije.pick = true;
                Destroy(transform.parent.gameObject);
                Nizije.brl = 0;
                Nizije.bl = false;
            }
            else
            {
                cameraSound.clip = incorrect;
                cameraSound.Play();
                Nizije.brl++;
                if (Nizije.brl == 3 && !Nizije.bl)
                {
                    GameObject.Find(Nizije.word).GetComponent<MeshRenderer>().material = checkpointMat;
                    Nizije.sphere.GetComponent<MeshRenderer>().material = sphereMat;
                    Nizije.brl = 0;
                    Nizije.bl = true;
                }
            }
        }
    }
}
