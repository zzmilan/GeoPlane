using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject childPlane;
    [SerializeField]
    private float forwardSpeed = 8f, strafeSpeed = 7.5f;
    //private float hoverSpeed = 5f;

    private float activeForwardSpeed, activeStrafeSpeed;
    //private float activeHoverSpeed;

    [SerializeField]
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f;
    //private float hoverAcceleration = 2f;

    [SerializeField]
    private float lookRateSpeed = 90f;

    private Vector2 lookInput, screenCenter, mouseDistance;
    private float rollInput;

    [SerializeField]
    private float rollSpeed = 90f, rollAcceleration = 3.5f;
    
    [SerializeField]
    private float minSpeed = 5f;

    private AudioSource propeller;
    private bool up = false;
    private bool down = false;

    public static float vertical;
    public static bool check = false;

    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined;

        propeller = childPlane.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (check) {
            GetComponent<Rigidbody>().isKinematic = false;
            activeForwardSpeed = 0f;
            activeStrafeSpeed = 0f;
            lookInput = new Vector2(0, 0);
            screenCenter = new Vector2(0, 0);
            mouseDistance = new Vector2(0, 0);
            rollInput = 0;
            screenCenter.x = Screen.width * 0.5f;
            screenCenter.y = Screen.height * 0.5f;
            check = false;
        }

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;


        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        vertical = Input.GetAxisRaw("Vertical");
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, forwardSpeed + vertical * 7.5f, forwardAcceleration * Time.deltaTime);
        activeForwardSpeed = activeForwardSpeed < minSpeed ? minSpeed : activeForwardSpeed;
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        //activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);
        //Debug.Log(activeForwardSpeed);
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        //transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        if (vertical == 1 && propeller.pitch <= 1.08f)
        {
            propeller.pitch += 0.02f;
            up = true;
        }
        else if (vertical == 0) {
            if (propeller.pitch > 1f && up) {
                propeller.pitch -= 0.02f;
                if (propeller.pitch == 0)
                {
                    up = false;
                }
            }
            else if (propeller.pitch < 1f && down)
            {
                propeller.pitch += 0.02f;
                if (propeller.pitch == 0)
                {
                    down = false;
                }
            } }
        else if (vertical == -1 && propeller.pitch >= 0.92f)
        {
            propeller.pitch -= 0.02f;
            down = true;
        }
    }
}
