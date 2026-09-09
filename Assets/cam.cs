using UnityEngine;

public class cam : MonoBehaviour
{
    public float speed = 10f;
    public float fastSpeed = 30f;
    public float mouseSensitivity = 3f;

    float rotationX = 0f;
    float rotationY = 0f;

    void Update()
    {
        // Movimiento
        float currentSpeed = Input.GetKey(KeyCode.LeftShift)
            ? fastSpeed
            : speed;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        transform.position += movement * currentSpeed * Time.deltaTime;

        // Mirar con botón derecho
        if (Input.GetMouseButton(1))
        {
            rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
}