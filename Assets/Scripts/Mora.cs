using UnityEngine;
using TMPro;

public class Mora : MonoBehaviour
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
    public static int n = 14;
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

        words[0] = "Лигуријско море";
        words[1] = "Тиренско море";
        words[2] = "Јадранско море";
        words[3] = "Јонско море";
        words[4] = "Средоземно море";
        words[5] = "Егејско море";
        words[6] = "Мраморно море";
        words[7] = "Црно море";
        words[8] = "Азовско море";
        words[9] = "Северно море";
        words[10] = "Ирско море";
        words[11] = "Балтичко море";
        words[12] = "Норвешко море";
        words[13] = "Бело море";

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
                PercentageMora.per = br;
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
