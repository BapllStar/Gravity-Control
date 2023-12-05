using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float
        moveSpeed,
        jumpHeight,
        maxGroundAngle;

    //private GameObject groundCheck;
    [SerializeField]
    private Transform
        head,
        xROrigin;
    private Rigidbody rb;
    private bool
        isGrounded,
        wasGrounded;

    private GravityManager gm;
    private void Awake()
    {
        gm = GameObject.Find("Gravity Manager").GetComponent<GravityManager>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            float jumpForce = Mathf.Sqrt(jumpHeight * 2 * gm.globalGravity.magnitude);
            //Debug.Log(jumpForce);
            rb.AddForce(gm.globalGravity.normalized * -jumpForce, ForceMode.Impulse);
            //isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Handle horizontal and vertical inputs
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Get the rotation of the VR headset (assuming you have a reference to it)
        //Quaternion headsetRotation = OnlyYAxis(head.localRotation) * head.parent.rotation;
        Quaternion headsetRotation = head.rotation;

        Debug.DrawRay(head.position, headsetRotation * Vector3.forward, Color.black);


        // Rotate the movement vector based on the headset's rotation
        movement = Vector3.ProjectOnPlane(headsetRotation * movement, gm.globalGravity);

        // Move the player
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    /*private Quaternion OnlyYAxis(Quaternion original)
    {
        return Quaternion.Euler(new Vector3(0, original.eulerAngles.y, 0));
    }*/

    private Vector3 NoNAxis(Vector3 original, Vector3 axis)
    {
        return new Vector3(original.x, 0, original.z);
    }

    void OnCollisionStay(Collision collision)
    {
        bool registered = EvalueateGrounded(collision, "Stay");
        isGrounded = registered || wasGrounded;
        wasGrounded = registered;

    }

    void OnCollisionExit(Collision collision)
    {
        bool registered = EvalueateGrounded(collision, "Stay");
        isGrounded = registered;
        wasGrounded = registered;
    }

    bool EvalueateGrounded(Collision collision, string callFrom = "")
    {
        isGrounded = true;
        int groundPoints = 0;
        foreach (ContactPoint contact in collision.contacts)
        {
            // Visualize the contact point and normal
            /*Debug.DrawLine(contact.point, contact.point + contact.normal, Color.green, 2f);
            Debug.DrawLine(contact.point, contact.point + gm.Inverse().normalized, Color.blue, 2f);
            Debug.Log(Vector3.Angle(contact.normal, gm.Inverse()));*/

            if (Vector3.Angle(contact.normal, gm.Inverse()) < maxGroundAngle)
            {
                groundPoints++;
                break;
            }
        }

        bool now = groundPoints > 0;

        //Debug.Log(callFrom + "\n" + collision.contacts.Length + " / " + now);

        return now;
        
    }


}