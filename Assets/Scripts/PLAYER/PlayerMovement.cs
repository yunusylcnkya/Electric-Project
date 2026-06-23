using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    Vector3 currentRotation;
    Vector3 targetRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandlePlayerMovement();
        HandlePlayerRotation();
    }

    public void HandlePlayerMovement()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime,
         0,
          Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime));
    }

    public void HandlePlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        targetRotation.x -= mouseY;
        targetRotation.y += mouseX;

        targetRotation.x = Mathf.Clamp(targetRotation.x, -90f, 90f);

        transform.rotation = Quaternion.Euler(new Vector3(0, targetRotation.y, 0));
        Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(targetRotation.x, 0, 0));

    }
}
