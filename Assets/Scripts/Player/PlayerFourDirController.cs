using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFourDirController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        float moveInputHor = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInputHor * speed, rb.velocity.y);


        if (moveInputHor > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (moveInputHor < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }



        float moveInputVert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveInputVert * speed);
        if (moveInputHor != 0 && moveInputVert != 0)
            rb.velocity = new Vector2(moveInputHor * speed / 1.41f, moveInputVert * speed / 1.41f);

        if (moveInputHor != 0 && !player.IsDrinking || moveInputVert != 0 && !player.IsDrinking)
        {
            animator.Play("SlimeRun");
        }
        else if (!player.IsDrinking)
        {
            animator.Play("SlimeIdle");
        }
        else
            animator.Play("SlimeDrink");
    }
}
