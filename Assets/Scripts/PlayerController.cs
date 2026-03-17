using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;

    public Transform cam;
    public float lookSensitivity;
    public float minXRot;
    public float maxXRot;
    private float curXRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    } 

    void Update ()
    {
        Move();

        if(Cursor.lockState == CursorLockMode.Locked)
            Look();
    } 

    void Move ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;

        controller.Move(dir);
    }

    void Look ()
    {
        // get x and y mouse inputs
        float x = Input.GetAxis("Mouse X") * lookSensitivity;
        float y = Input.GetAxis("Mouse Y") * lookSensitivity;

        // rotate the player horizontally
        transform.eulerAngles += Vector3.up * x;

        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);

    }

}
