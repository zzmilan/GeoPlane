using UnityEngine;

public class TriggerOstrva : MonoBehaviour
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
            if (gameObject.name == Ostrva.word)
            {
                cameraSound.clip = correct;
                cameraSound.Play();
                Ostrva.pick = true;
                Destroy(transform.parent.gameObject);
                Ostrva.brl = 0;
                Ostrva.bl = false;
            }
            else
            {
                cameraSound.clip = incorrect;
                cameraSound.Play();
                Ostrva.brl++;
                if (Ostrva.brl == 3 && !Ostrva.bl)
                {
                    GameObject.Find(Ostrva.word).GetComponent<MeshRenderer>().material = checkpointMat;
                    Ostrva.sphere.GetComponent<MeshRenderer>().material = sphereMat;
                    Ostrva.brl = 0;
                    Ostrva.bl = true;
                }
            }
        }
    }
}
