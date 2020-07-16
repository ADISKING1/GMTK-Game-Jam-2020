using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float moveSpeedY;
    public float defaultMoveSpeed;

    public float bustedMultiple = 0.4f;

    public GameManager gm;

    public Rigidbody rb;

    public Vector3 movement;
    public Vector3 movementY;

    public float smooth = 5.0f;
    public float tiltAngleX = 60.0f;
    public float tiltAngleY = 60.0f;

    public enum Busted {L, R, V, N};

    public Busted currentlyBusted = Busted.N;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movementY.y = Input.GetAxisRaw("Vertical");

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * -tiltAngleX;
        float tiltAroundX = Input.GetAxis("Vertical") * -tiltAngleY;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    private void LateUpdate()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }

    private void FixedUpdate()
    {
        SetForces();
    }


    void SetForces()
    {
        if (currentlyBusted == Busted.R && movement.x > 0)
        {
            moveSpeed *= bustedMultiple;
        }
        if (currentlyBusted == Busted.L && movement.x < 0)
        {
            moveSpeed *= bustedMultiple;
        }
        if (currentlyBusted == Busted.V)
        {
            moveSpeedY *= bustedMultiple;
        }
        Move();
        moveSpeed = defaultMoveSpeed;
        moveSpeedY = defaultMoveSpeed;
    }
    public void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movementY * moveSpeedY * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collided");
        gm.SetGameOver();
    }

    
}
