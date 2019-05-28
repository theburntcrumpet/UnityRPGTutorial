using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool onGround = true;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Transform enemy;
    Animator anim;
    SpriteRenderer render;
    Rigidbody2D rigid;
    enum animDirection { ANIM_UNKNOWN, ANIM_LEFT, ANIM_RIGHT };
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    animDirection GetAnimationDirection() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)
            return animDirection.ANIM_RIGHT;
        if (horizontalInput < 0)
            return animDirection.ANIM_LEFT;
        return animDirection.ANIM_UNKNOWN;
    }

    void FixedUpdate(){
        onGround = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f){
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        anim.speed = 1;
        anim.SetBool("MoveX", false);
        anim.SetBool("Idle", false);
        switch (GetAnimationDirection()) {
            case(animDirection.ANIM_RIGHT):
                anim.SetBool("MoveX", true);
                break;
            case (animDirection.ANIM_LEFT):
                anim.SetBool("MoveX",true);
                break;
            default:
                anim.SetBool("Idle", true);
                anim.speed = 0;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround && Input.GetKeyDown("space")){
            rigid.AddForce(new Vector2(0,jumpForce));
            onGround = false;
        }

        if (enemy.position.x > transform.position.x)
            render.flipX = true;
        else if (enemy.position.x < transform.position.x)
            render.flipX = false;

    }
}
