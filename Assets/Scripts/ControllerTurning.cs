using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTurning : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty joystickAction; // Assign the joystick action in the Inspector.

    [SerializeField]
    private float rotationSpeed = 30f; // Adjust the rotation speed as needed.

    [SerializeField]
    private Transform head;

    private void Update()
    {
        // Read the joystick input value.
        Vector2 joystickInput = joystickAction.action.ReadValue<Vector2>();

        // Rotate the object based on the joystick input.
        RotateObject(joystickInput);
    }

    private void RotateObject(Vector2 input)
    {
        // Calculate the rotation amount based on joystick input.
        float rotationAmount = input.x * rotationSpeed * Time.deltaTime;

        // Apply rotation around the head transform.
        transform.RotateAround(head.position, transform.up, rotationAmount);
    }
}