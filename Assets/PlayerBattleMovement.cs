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
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate(){
        onGround = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f){
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround && Input.GetKeyDown("space")){
            rigid.AddForce(new Vector2(0,jumpForce));
            onGround = false;
        }
    }
}
