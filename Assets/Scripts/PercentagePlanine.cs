using UnityEngine;
using TMPro;

public class PercentagePlanine : MonoBehaviour
{
    private TextMeshProUGUI perText;

    public static int per = 0;

    private void Start()
    {
        per = 0;
        perText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        perText.text = ((per * 100) / Planine.n).ToString() + "%";
    }
}
