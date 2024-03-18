using UnityEngine;

public class MenuPlane : MonoBehaviour
{
    private float x;
    private float z;

    void Start() {
        x = transform.position.x;
        z = transform.position.z;
    }

    void Update()
    {
        x += Time.deltaTime * 1.125f / 3f;
        z -= Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y, z);
    }
}
