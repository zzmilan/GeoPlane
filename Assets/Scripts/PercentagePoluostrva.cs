using UnityEngine;
using TMPro;

public class PercentagePoluostrva : MonoBehaviour
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
        perText.text = ((per * 100) / Poluostrva.n).ToString() + "%";
    }
}
