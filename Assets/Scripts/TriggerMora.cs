using UnityEngine;

public class TriggerMora : MonoBehaviour
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
            if (gameObject.name == Mora.word)
            {
                cameraSound.clip = correct;
                cameraSound.Play();
                Mora.pick = true;
                Destroy(transform.parent.gameObject);
                Mora.brl = 0;
                Mora.bl = false;
            }
            else
            {
                cameraSound.clip = incorrect;
                cameraSound.Play();
                Mora.brl++;
                if (Mora.brl == 3 && !Mora.bl)
                {
                    GameObject.Find(Mora.word).GetComponent<MeshRenderer>().material = checkpointMat;
                    Mora.sphere.GetComponent<MeshRenderer>().material = sphereMat;
                    Mora.brl = 0;
                    Mora.bl = true;
                }
            }
        }
    }
}
