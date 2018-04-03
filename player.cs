using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float movex, movez, movey, m;
    float rest;   
   //Animator anim;
    Vector3 vec1;
   //public GameObject target;
    CharacterController cont;
    float spacex = 1, gravity = -12;
    bool on, jumpon;
    public float health;
    public camera cam;
    private float accorot;
    Animator cameraanim; 
   //public mouse mousescript;
    public pausebutton pausebuttonscript;
    private Vector3 direc;
   
    

    void Start () { 

      //anim = GetComponent<Animator>();
        cont = GetComponent<CharacterController>();
        on = false;
      //anim.SetBool("on", on);
        jumpon = false;
        accorot = 0;
        cameraanim = cam.GetComponent<Animator>();
        health = 100;
    }

    void Update()
    {
        if (Input.acceleration.x < -0.1)
        {
            accorot = 1;
        }
        else if (Input.acceleration.x > 0.1)
        {
            accorot = -1;
        }
        else
            accorot = 0;

        direc = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        
         
       //  movez = Input.GetAxis("vertical");
     // movex = Input.GetAxis("Horizontal");
     // movex = Mathf.Clamp(movex, -0.99f, 1);
   
      //  anim.SetFloat("movez", 1);
     //  anim.SetFloat("movex", movex);
       
        if (/*movez !=0*/ (health>0f))
        {
          
            /*if (Input.GetKey(KeyCode.Mouse1))                                          // for smothing varition of gun and man
            {
                Vector3.SmoothDamp(vec2, target.transform.forward, ref vec2, 1f);
            }
            else
            {
                Vector3.SmoothDamp(vec2, target.transform.forward, ref vec2, 2f);
            }

            vec2.y = 0;     */                                                           // set the facing the player
            transform.forward = Vector3.right;
            cameraanim.SetFloat("run", 1);
            cont.Move( direc * 2.5f * Time.deltaTime);
           cont.Move(Vector3.forward * accorot * 1.8f * Time.deltaTime);//moving the player
           // cont.Move(transform.right * movex * 1.2f * Time.deltaTime);
          
        }

           if (cont.isGrounded)
        {
            m = transform.position.y + 10f;
          // Debug.Log("grounded");
        }

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < m && !jumpon & movex == 0f)
        {          
            spacex = -2;
           // anim.SetFloat("spacex", -1);
            jumpon = true;
        }

        else if  (transform.position.y > m)
        {
            Mathf.SmoothDamp(spacex, 6f, ref spacex, 1f); 
        }
       
        cont.Move(transform.up * spacex * gravity * 2f * Time.deltaTime);
      
        if (pausebuttonscript.pressed)
        {
            Application.LoadLevel(0);
        }
      
       /* if (Input.GetKey(KeyCode.Mouse1))
        {
            vec2 = target.transform.forward;
            vec2.y = 0;
            transform.forward = vec2 * Time.deltaTime;
        }*/
        else if (movez == 0f)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
               // anim.Play("axe_kick", -1, 0f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
               // anim.Play("brazilian_kick", -1, 0f);

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
               // anim.Play("defensive_side_kick", -1, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
               // anim.Play("back_kick 0", -1, 0f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                //anim.Play("front_kick", -1, 0f);
            }

            /*  if (Input.GetKey(KeyCode.DownArrow))
              {
                  anim.SetBool("back", true);
                  cont.Move(transform.forward * -2.5f* Time.deltaTime);
              }
              else
                  anim.SetBool("back", false);*/
           
        }
        if (health <= 0)
        {
           // anim.Play("DAMAGED01");
            Invoke("dead", 2);

        }
      

    }

  

    public void dead()
    {
        Application.LoadLevel(2);
    }
    public void OnTriggerEnter(Collider other)
    {
      //  anim.SetFloat("spacex", 1);
        jumpon = false;
    }
}
