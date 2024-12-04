using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    float jumpForce = 5.0f;
    Animator plrAnim;
    bool isOnGround = true;
    Rigidbody plrRb;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        plrAnim = GetComponent<Animator>();
        plrRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);

        if (horizontal != 0)
        {
            plrAnim.SetFloat("Speed_f", 0.26f);
            plrAnim.SetBool("Static_b", true);
            Debug.Log("here");
        }
        else
        {
            plrAnim.SetFloat("Speed_f", 0);
        }

        if (vertical == 0)
        {
            plrAnim.SetFloat("Speed_f", 0);
        }
        else
        {
            plrAnim.SetFloat("Speed_f", 0.26f);
            plrAnim.SetBool("Static_b", true);
        }

        movement = new Vector3(horizontal, transform.position.y, vertical);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            plrRb.velocity = plrRb.velocity + Vector3.up * jumpForce;
            isOnGround = false;
            plrAnim.SetTrigger("Jump_trig");
        }

        plrRb.velocity = movement * speed * Time.fixedDeltaTime;
    } 
}
