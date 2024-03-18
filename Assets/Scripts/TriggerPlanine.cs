using UnityEngine;

public class TriggerPlanine : MonoBehaviour
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
            if (gameObject.name == Planine.word)
            {
                cameraSound.clip = correct;
                cameraSound.Play();
                Planine.pick = true;
                Destroy(transform.parent.gameObject);
                Planine.brl = 0;
                Planine.bl = false;
            }
            else
            {
                cameraSound.clip = incorrect;
                cameraSound.Play();
                Planine.brl++;
                if (Planine.brl == 3 && !Planine.bl)
                {
                    GameObject.Find(Planine.word).GetComponent<MeshRenderer>().material = checkpointMat;
                    Planine.sphere.GetComponent<MeshRenderer>().material = sphereMat;
                    Planine.brl = 0;
                    Planine.bl = true;
                }
            }
        }
    }
}
