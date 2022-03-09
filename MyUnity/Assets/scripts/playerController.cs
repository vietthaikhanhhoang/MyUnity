using System.Timers;
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpHeight;

    bool facingRight;

    Rigidbody2D myBody;
    Animator myAnim;

    bool grounded;

    //khai bao cac bien de ban
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>(); //.velocity: di len, xuong, trai phai
        myAnim = GetComponent<Animator>(); //thay doi trang thai: dung im, chay

        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Di chuyen nhan vat sang trai hoac sang phai
        float move = Input.GetAxis("Horizontal");
        myBody.velocity = new Vector2(move*maxSpeed, myBody.velocity.y);

        //Chuyen trang thai dung yen -> chay
        myAnim.SetFloat("speed", Math.Abs(move));

        //Kiem tra mat quay sang phai
        if(move > 0 && !facingRight) {
            flip();
        } else if (move < 0 && facingRight) {
            flip();
        }

        if(Input.GetKey(KeyCode.Space)) {
            if(grounded) {
                grounded = false;

                //luc giup nhay len
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
             }
        }

        //Chuc nang ban tu ban phim, ban ngay lap tuc la GetAxisRaw
        if(Input.GetAxisRaw("Fire1") > 0) {
            fireBullet();
        }
    }

    void fireBullet(){
        if(Time.time > nextFire) {
            nextFire = Time.time + fireRate; //sau fireRate giay moi duoc ban 1 phat
            if(facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    void flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground") {
            grounded = true;
        } 
    }
}
