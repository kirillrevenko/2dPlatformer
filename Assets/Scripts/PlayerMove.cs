using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

[SerializeField] private float speed;   
private Rigidbody2D body;
private Animator anima;

private void Awake()
{
    body = GetComponent<Rigidbody2D>();
    anima = GetComponent<Animator>();
}

private void FixedUpdate()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
    
    if (horizontalInput> 0.01f)
        transform.localScale = Vector3.one;
    else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(-1, 1, 1);

    if (Input.GetKey(KeyCode.D))
        body.velocity = new Vector2(body.velocity.x, speed);   

    anima.SetBool("run", horizontalInput !=0);


}

}
