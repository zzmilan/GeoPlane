using UnityEngine;

public class Propeller : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, (1080f + 360f * PlaneMovement.vertical) * Time.deltaTime, 0f, Space.Self);
    }
}
