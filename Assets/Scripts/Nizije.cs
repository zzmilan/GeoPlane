using UnityEngine;
using TMPro;

public class Nizije : MonoBehaviour
{
    [SerializeField]
    private GameObject pojam;
    [SerializeField]
    private GameObject finish;
    [SerializeField]
    private GameObject[] pojmovi;
    [SerializeField]
    private GameObject[] spheres;
    [SerializeField]
    private GameObject plane;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject OtherStuff;
    [SerializeField]
    private Transform stuff;
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private GameObject play;
    [SerializeField]
    private GameObject flashbang;

    private int br = 0;
    private int current;
    private string[] words;
    private bool[] numbers;

    public static Vector3 mainCameraPosition;
    public static float rotationX, rotationY, rotationZ;

    //TODO: Replace Trigger variables!!!!
    public static int n = 8;
    public static string word;
    public static GameObject sphere;
    public static bool pick = true;
    public static int brl = 0;
    public static bool bl = false;

    void Start()
    {
        br = 0;
        brl = 0;
        pick = true;
        bl = false;

        words = new string[n];

        words[0] = "Панонска низија";
        words[1] = "Падска низија";
        words[2] = "Влашка низија";
        words[3] = "Западноевропска низија";
        words[4] = "Прибалтичка низија";
        words[5] = "Источноевропска низија";
        words[6] = "Тракија";
        words[7] = "Андалузија";

        numbers = new bool[n];
        while (br < n) {
            numbers[br] = false;
            br++;
        }
        br = 0;
    }

    void Update()
    {
        if (pick)
        {
            while (true && br != n)
            {
                current = Random.Range(0, n);
                if (!numbers[current])
                {
                    numbers[current] = true;
                    break;
                }
            }
            pick = false;

            pojam.GetComponent<TextMeshProUGUI>().text = words[current];
            word = words[current];
            sphere = spheres[current];
            if (br <= n) {
                PercentageNizije.per = br;
            }
            if (br == n)
            {
                play.transform.SetParent(stuff, true);
                pause.transform.SetParent(stuff, true);
                OtherStuff.SetActive(false);
                plane.GetComponent<PlaneMovement>().enabled = false;

                mainCamera.transform.position = mainCameraPosition;
                mainCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);

                flashbang.SetActive(false);

                GameSettings.finished = true;
                finish.SetActive(true);
            }
            br++;
        }
    }
}
