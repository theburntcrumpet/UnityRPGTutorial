using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public Transform target;

    SpriteRenderer render;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
        }
        else if (distance <= stopDistance)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", false);
        }
        if (target.position.x > transform.position.x)
            render.flipX = true;
        else if (target.position.x < transform.position.x)
            render.flipX = false;
    }
}
