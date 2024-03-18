using UnityEngine;
using UnityEngine.Rendering;

public class LensDirt : MonoBehaviour
{
    [SerializeField]
    private float timeMultiply = 1f;

    [SerializeField]
    private GameObject lensDirt;

    private Renderer renderor;

    private Volume vol;

    void Start() {
        renderor = GetComponent<Renderer>();
        vol = lensDirt.GetComponent<Volume>();
    }

    void Update()
    {
        if (renderor.isVisible && vol.weight < 1f)
        {
            vol.weight += Time.deltaTime * timeMultiply;

            vol.weight = vol.weight > 1f ? 1f : vol.weight;
        }
        else if (!renderor.isVisible && vol.weight > 0.2f) {
            vol.weight -= Time.deltaTime * timeMultiply;
            vol.weight = vol.weight < 0.2f ? 0.2f : vol.weight;
        }
    }
}
