using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private PlayerMotor motor;
    [SerializeField]
    private float lookSens = 3f;

    void Start() {
        motor = GetComponent<PlayerMotor>();
    }

    void Update() {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;
        // normalize so the vector is length 1, meaning it just gets the direction
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        // Apply Movement
        motor.Move(velocity);

        // Calculate Rotation (turning around)
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookSens;

        // Apply rotation
        motor.Rotate(rotation);

        // // Calculate Rotation
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3 (xRot, 0f, 0f) * lookSens;

        // Apply camera rotation
        motor.RotateCamera(cameraRotation);
    }
}
