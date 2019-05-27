using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Animator anim;
    SpriteRenderer render;
    Rigidbody2D rigid;
    public bool controls = true;
    enum animDirection {ANIM_UNKNOWN = 0, ANIM_UP, ANIM_DOWN, ANIM_LEFT, ANIM_RIGHT};

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    animDirection GetDirectionForAnimation(){
        if(Input.GetAxisRaw("Horizontal") > 0)
            return animDirection.ANIM_RIGHT;
        if(Input.GetAxisRaw("Horizontal") < 0)
            return animDirection.ANIM_LEFT;
        if(Input.GetAxisRaw("Vertical") < 0)
            return animDirection.ANIM_DOWN;
        if(Input.GetAxisRaw("Vertical") > 0)
            return animDirection.ANIM_UP;
        return animDirection.ANIM_UNKNOWN;
    }

    bool HandleAnimation(){
        if(Input.GetAxisRaw("Vertical") != 0.0f || Input.GetAxisRaw("Horizontal") != 0.0f){
            anim.speed = 1;
            anim.SetBool("MoveX",false);
            anim.SetBool("MoveUp",false);
            anim.SetBool("MoveDown", false);
            render.flipX = false;
        }
        else{
            anim.speed = 0;
        }
        switch(GetDirectionForAnimation()){
            case(animDirection.ANIM_RIGHT):
                anim.SetBool("MoveX",true);
                render.flipX = true;
                break;
            case(animDirection.ANIM_LEFT):
                anim.SetBool("MoveX", true);
                break;
            case(animDirection.ANIM_UP):
                anim.SetBool("MoveUp",true);
                break;
            case(animDirection.ANIM_DOWN):
                anim.SetBool("MoveDown",true);
                break;
            default:
                return false;
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f){
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f){
            transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }
        
        bool animationHappened = HandleAnimation();

    }
}
