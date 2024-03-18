using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField]
    private GameObject childPlane;
    [SerializeField]
    private GameObject flashbang;
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private float divideTime = 2f;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private GameObject planeCameraPosition;
    [SerializeField]
    private GameObject plane;
    [SerializeField]
    private GameObject checkpoints;
    [SerializeField]
    private GameObject otherStuff;
    [SerializeField]
    private Transform pauseMenu;
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private GameObject play;

    private Image image;
    private float br = 0f;
    private float vbr = 0f;
    private bool fade = false;
    private bool phase1 = false;

    private AudioSource propeller;

    void Start()
    {
        br = 0f;
        vbr = 0f;
        fade = false;
        phase1 = false;

        //get mainCamera position and rotation
        if (SceneManager.GetActiveScene().name == "mora" || SceneManager.GetActiveScene().name == "moraNT")
        {
            Mora.mainCameraPosition = planeCameraPosition.transform.position;
            Mora.rotationX = planeCameraPosition.transform.localEulerAngles.x;
            Mora.rotationY = planeCameraPosition.transform.localEulerAngles.y;
            Mora.rotationZ = planeCameraPosition.transform.localEulerAngles.z;
        }
        else if (SceneManager.GetActiveScene().name == "nizije" || SceneManager.GetActiveScene().name == "nizijeNT")
        {
            Nizije.mainCameraPosition = planeCameraPosition.transform.position;
            Nizije.rotationX = planeCameraPosition.transform.localEulerAngles.x;
            Nizije.rotationY = planeCameraPosition.transform.localEulerAngles.y;
            Nizije.rotationZ = planeCameraPosition.transform.localEulerAngles.z;
        }
        if (SceneManager.GetActiveScene().name == "planine" || SceneManager.GetActiveScene().name == "planineNT")
        {
            Planine.mainCameraPosition = planeCameraPosition.transform.position;
            Planine.rotationX = planeCameraPosition.transform.localEulerAngles.x;
            Planine.rotationY = planeCameraPosition.transform.localEulerAngles.y;
            Planine.rotationZ = planeCameraPosition.transform.localEulerAngles.z;
        }
        if (SceneManager.GetActiveScene().name == "ostrva" || SceneManager.GetActiveScene().name == "ostrvaNT" || SceneManager.GetActiveScene().name == "ostrvaS" || SceneManager.GetActiveScene().name == "ostrvaSNT")
        {
            Ostrva.mainCameraPosition = planeCameraPosition.transform.position;
            Ostrva.rotationX = planeCameraPosition.transform.localEulerAngles.x;
            Ostrva.rotationY = planeCameraPosition.transform.localEulerAngles.y;
            Ostrva.rotationZ = planeCameraPosition.transform.localEulerAngles.z;
        }
        if (SceneManager.GetActiveScene().name == "poluostrva" || SceneManager.GetActiveScene().name == "poluostrvaNT")
        {
            Poluostrva.mainCameraPosition = planeCameraPosition.transform.position;
            Poluostrva.rotationX = planeCameraPosition.transform.localEulerAngles.x;
            Poluostrva.rotationY = planeCameraPosition.transform.localEulerAngles.y;
            Poluostrva.rotationZ = planeCameraPosition.transform.localEulerAngles.z;
        }

        image = flashbang.GetComponent<Image>();
        image.color = new Color(0f, 0f, 0f, 0f);
        flashbang.SetActive(false);
        otherStuff.SetActive(false);

        propeller = childPlane.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            fade = true;
            flashbang.SetActive(true);
        }
        if (fade)
        {
            br += Time.deltaTime / divideTime;
            image.color = new Color(0f, 0f, 0f, br);

            if (image.color.a >= 1f)
            {
                plane.SetActive(true);
                checkpoints.SetActive(true);
                otherStuff.SetActive(true);

                play.transform.SetParent(pauseMenu, true);
                pause.transform.SetParent(pauseMenu, true);

                planeCameraPosition.transform.SetParent(parent, true);
                planeCameraPosition.transform.position = new Vector3(0f, 51.7f, 202.2f);
                planeCameraPosition.transform.rotation = Quaternion.Euler(20f, 180f, 0f);

                start.SetActive(false);

                fade = false;
                phase1 = true;
                GameSettings.done = true;

                Timer.timeStart = true;
                Timer.startTime = Time.time;

                propeller.volume = 0f;
            }
        }
        else if (phase1)
        {
            br -= Time.deltaTime / divideTime;
            vbr += Time.deltaTime / divideTime;
            image.color = new Color(0f, 0f, 0f, br);
            propeller.volume = vbr;

            if (image.color.a <= 0f)
            {
                image.color = new Color(0f, 0f, 0f, 0f);
                propeller.volume = 1f;
                phase1 = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        fade = true;
        flashbang.SetActive(true);
    }
}
