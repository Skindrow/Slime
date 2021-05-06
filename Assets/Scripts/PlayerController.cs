using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private KeyCode KeyJump;
    [SerializeField] private KeyCode KeyLeft;
    [SerializeField] private KeyCode KeyRight;
    [SerializeField] private KeyCode KeyDown;


    private bool canJump;
    private Rigidbody2D rb;
    private float jumpPowerStart;

    void Start()
    {
        canJump = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpPowerStart = jumpPower;
    }

    void Update()
    {
        //if (Input.GetKey(KeyLeft))
        //{
        //    rb.AddForce(new Vector2(-1.0f * speed, 0.0f));
        //}
        //if (Input.GetKey(KeyRight))
        //{
        //    rb.AddForce(new Vector2(1.0f * speed, 0.0f));
        //}
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }


        if (canJump && Input.GetKey(KeyJump))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyJump))
        {
            canJump = false;
            jumpPower = jumpPowerStart;
        }
        if (Input.GetKey(KeyDown))
        {
            rb.AddForce(new Vector2(0.0f, -1.0f * jumpPower));
        }

    }



    private IEnumerator JumpRecharge()
    {
        for (float i = 0; i <= jumpTime; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
        }
        canJump = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpPower = jumpPowerStart;
            canJump = true;
        }
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0.0f, 1.0f * jumpPower));
        jumpPower /= 2;
    }
   
}
