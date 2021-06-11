using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    Vector2 movement;
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal"); //left -1 ,right +1,nothing 0  (X)
        movement.y = Input.GetAxisRaw("Vertical");// up 1,down -1,nothing 0        (Y)

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);




        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));

        }
    }
    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        //Flipping
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -1f;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = 1f;


        }
        transform.localScale = characterScale;
    }











}