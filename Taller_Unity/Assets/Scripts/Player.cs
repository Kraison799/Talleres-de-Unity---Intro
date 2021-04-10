using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement variables
    public float speed = 1;
    public float jumpVelocity = 10;
    float tempX = 0; // Values: 1, -1
    float tempY = 0; // Values: 1, -1
    Vector3 axis;
    [SerializeField] bool isGrounded = false;

    // Components
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempX = Input.GetAxis(Actions.Horizontal.ToString());
        tempY = Input.GetAxis(Actions.Vertical.ToString());

        if (Input.GetButtonDown(Actions.Jump.ToString()) && isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        }
    }

    // FixeUpdated
    void FixedUpdate()
    {
        axis = new Vector3(tempX, 0, tempY);
        rb.MovePosition(rb.position + axis * speed);
    }

    // Collision
    private void OnCollisionEnter(Collision collision)
    {
        // Respawns if collision with obstacles
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            rb.transform.position = new Vector3(0, 5, 0);
            Destroy(collision.gameObject);
        }
        // While touching ground
        if (collision.gameObject.layer.Equals(3))
            isGrounded = true;
    }

    // Trigger
    private void OnTriggerEnter(Collider other)
    {
        // If close to target
        if (other.gameObject.tag.Equals("Target"))
            Destroy(other.gameObject);
    }

    // Possible actions
    public enum Actions
    {
        Horizontal, Vertical, Jump
    }
}
