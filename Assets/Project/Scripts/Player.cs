using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10.0f;
    public Rigidbody rb;
    public Vector3 Direction;
    public float thrust = 3;
    public bool IsJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Walk();
        //jump
        if (Input.GetKeyDown("space") == true && IsJumping == false)
        {
            rb.AddForce(Vector3.up * thrust * 100);
            IsJumping = true;
        }
        if (rb.velocity == new Vector3 (0f,0f,0f))
        {
            Debug.Log(IsJumping);
            IsJumping = false;
            Debug.Log(IsJumping);
        }
        //rotatetion here
        transform.Rotate(0f,Input.GetAxis("Mouse X")*2,0f);
    }
    void FixedUpdate()
    {
    }
    void Walk()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position += transform.forward *-1 * Speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.position += transform.right *-1 * Speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
    }
}
