using UnityEngine;

public class SunTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;

    void Update()
    {
        sun.transform.position = new Vector3(transform.position.x - 140f, transform.position.y + 257f, transform.position.z - 660f);
    }
}
