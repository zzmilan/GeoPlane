using UnityEngine;

public class TriggerPoluostrva : MonoBehaviour
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
            if (gameObject.name == Poluostrva.word)
            {
                cameraSound.clip = correct;
                cameraSound.Play();
                Poluostrva.pick = true;
                Destroy(transform.parent.gameObject);
                Poluostrva.brl = 0;
                Poluostrva.bl = false;
            }
            else
            {
                cameraSound.clip = incorrect;
                cameraSound.Play();
                Poluostrva.brl++;
                if (Poluostrva.brl == 3 && !Poluostrva.bl)
                {
                    GameObject.Find(Poluostrva.word).GetComponent<MeshRenderer>().material = checkpointMat;
                    Poluostrva.sphere.GetComponent<MeshRenderer>().material = sphereMat;
                    Poluostrva.brl = 0;
                    Poluostrva.bl = true;
                }
            }
        }
    }
}
