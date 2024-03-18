using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheLaw : MonoBehaviour
{
    [SerializeField]
    private GameObject childPlane;
    [SerializeField]
    private GameObject flashbang;
    [SerializeField]
    private float divideTime = 2f;
    [SerializeField]
    private Transform planeCamera;
    [SerializeField]
    private GameObject planeCameraPosition;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Material mat;
    [SerializeField]
    private GameObject fps;
    [SerializeField]
    private GameObject[] stuff;

    private Image image;
    private float br = 0f;
    private float vbr = 0f;
    private bool fade = false;
    private bool phase1 = false;
    private bool phase2 = false;
    public static bool collided = false;
    private bool skip = true;
    private bool cameraSwitch = false;
    private bool fpsVisible = false;

    private AudioSource propeller;
    private AudioSource cameraSound;
    [SerializeField]
    private AudioClip crash;
    [SerializeField]
    private AudioClip splash;

    private bool audioCheck = true;

    void Start()
    {
        br = 0f;
        vbr = 0f;
        fade = false;
        phase1 = false;
        phase2 = false;
        collided = false;
        skip = true;
        cameraSwitch = false;
        fpsVisible = false;

        image = flashbang.GetComponent<Image>();

        propeller = childPlane.GetComponent<AudioSource>();
        cameraSound = planeCameraPosition.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        propeller.Pause();
        if (audioCheck)
        {
            if (!col.gameObject.CompareTag("ocean"))
            {
                cameraSound.clip = crash;
                cameraSound.Play();
                audioCheck = false;
                StartCoroutine(Wait());
            }
            else if (col.gameObject.CompareTag("ocean"))
            {
                cameraSound.clip = splash;
                cameraSound.Play();
                audioCheck = false;
                StartCoroutine(Wait());
            }
        }

        if (col.gameObject.CompareTag("tree"))
        {
            col.gameObject.GetComponent<MeshRenderer>().material = mat;
            col.gameObject.AddComponent<Rigidbody>();
            col.gameObject.GetComponent<Rigidbody>().useGravity = true;

            /*GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            for (int i = 0; i < 10; i++)
            {
                stuff[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                stuff[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }

            Debug.Log("plane " + GetComponent<Rigidbody>().velocity);
            Debug.Log("tree" + col.gameObject.GetComponent<Rigidbody>().velocity);*/
        }
        else if (col.gameObject.CompareTag("ocean"))
        {
            stuff[9].SetActive(false);
        }

        planeCamera.parent = null;

        for (int i = 0; i < 10; i++)
        {
            stuff[i].GetComponent<MeshCollider>().enabled = true;
            stuff[i].GetComponent<Rigidbody>().useGravity = true;
        }

        stuff[4].GetComponent<Propeller>().enabled = false;
        GetComponent<PlaneMovement>().enabled = false;
        collided = true;
        fade = true;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        audioCheck = true;
    }
    void Update()
    {
        if (Input.GetKeyDown("c")) {
            if (!cameraSwitch)
            {
                planeCameraPosition.transform.localPosition = new Vector3(0f, 6.419983f, -2.480011f);
                cameraSwitch = true;
            }
            else {
                planeCameraPosition.transform.localPosition = new Vector3(0f, 17f, -21.99997f);
                cameraSwitch = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.F3)) 
        {
            fpsVisible = !fpsVisible;
            fps.SetActive(fpsVisible);
        }

        if ((transform.position.z > 400f || transform.position.z < -700f || transform.position.x > 500f || transform.position.x < -600f || transform.position.y < -5f || transform.position.y > 1000f) && !phase1)
        {
            fade = true;
        }

        if (fade)
        {
            br += Time.deltaTime / divideTime;
            image.color = new Color(1f, 1f, 1f, br);

            if (image.color.a >= 1f)
            {
                image.color = new Color(1f, 1f, 1f, br);
                fade = false;
                phase1 = true;
            }
        }
        else if (phase1)
        {
            if (skip)
            {
                stuff[9].SetActive(true);

                transform.position = new Vector3(0f, 50f, 200f);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);

                if (collided)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        stuff[i].GetComponent<MeshCollider>().enabled = false;
                        stuff[i].GetComponent<Rigidbody>().useGravity = false;
                        stuff[i].GetComponent<Rigidbody>().isKinematic = true;
                    }

                    stuff[0].transform.position = new Vector3(-0.004177384f, 49.97707f, 200.0348f);
                    stuff[1].transform.position = new Vector3(-0.004240517f, 50.20964f, 199.8638f);
                    stuff[2].transform.position = new Vector3(-0.004177372f, 50.1339f, 200.7169f);
                    stuff[3].transform.position = new Vector3(0.3711794f, 50.23889f, 200.0282f);
                    stuff[4].transform.position = new Vector3(-0.005492385f, 50.23454f, 199.5843f);
                    stuff[5].transform.position = new Vector3(-0.3795342f, 50.23838f, 200.0264f);
                    stuff[6].transform.position = new Vector3(-0.004177375f, 50.14495f, 200.6858f);
                    stuff[7].transform.position = new Vector3(0.1152425f, 50.01479f, 199.8936f);
                    stuff[8].transform.position = new Vector3(-0.1235972f, 50.01479f, 199.8936f);
                    stuff[9].transform.position = new Vector3(-0.004055924f, 50.37026f, 199.8898f);

                    stuff[0].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);
                    stuff[1].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);
                    stuff[2].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);
                    stuff[3].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);
                    stuff[4].transform.localRotation = Quaternion.Euler(47.512f, -84.56f, -82.063f);
                    stuff[5].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);
                    stuff[6].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);
                    stuff[7].transform.rotation = Quaternion.Euler(0f, 90f, 92.25f);
                    stuff[8].transform.rotation = Quaternion.Euler(0f, 90f, 92.25f);
                    stuff[9].transform.rotation = Quaternion.Euler(-87.75f, 0f, 180f);

                    planeCameraPosition.transform.SetParent(parent, true);

                    stuff[4].GetComponent<Propeller>().enabled = true;

                    if (!cameraSwitch)
                    {
                        planeCameraPosition.transform.localPosition = new Vector3(0f, 17f, -21.99997f);
                    }
                    else
                    {
                        planeCameraPosition.transform.localPosition = new Vector3(0f, 6.419983f, -2.480011f);
                    }

                    planeCameraPosition.transform.rotation = Quaternion.Euler(20f, 180f, 0f);

                    GetComponent<PlaneMovement>().enabled = true;
                }

                GetComponent<Rigidbody>().isKinematic = true;
                PlaneMovement.check = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    stuff[i].GetComponent<Rigidbody>().isKinematic = false;
                }
                propeller.volume = 0f;
                propeller.UnPause();
                phase1 = false;
                phase2 = true;
            }
            skip = false;
        }
        else if (phase2)
        {
            br -= Time.deltaTime / divideTime;
            vbr += Time.deltaTime / divideTime;
            image.color = new Color(1f, 1f, 1f, br);
            propeller.volume = vbr;

            if (image.color.a <= 0f)
            {
                image.color = new Color(1f, 1f, 1f, 0f);
                propeller.volume = 1f;
                phase2 = false;
                collided = false;
                skip = true;
            }
        }
    }
}
