using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
   float mousemovex, mousemovey, mousemovexx, mousemoveyy, dst = 10;
    public float mousesensitivity = 5;
   
    Vector3 vecz;
    AudioSource audio;
    public Canvas point;
    public GameObject bulletspace;
    GameObject newbullet;
    public GameObject targetforpoint, gun, gun1;
   // public GameObject enemies;
    public float range;
    public GameObject  first, second;
    Renderer sec1;
    public float movementamount = 2;
    public float compres, exten;
    
    GameObject newgameobj;
   public ParticleSystem gunmuzzel;

    public int count = 0, count1 = 0;
    Rigidbody rb, rb1;
    Vector3 gunpos, refv, refv1;
    Animator anim2, anim3, anim4;
    public GameObject  player;
    public bool on, gunapp, gunapp1;
   // player py;
    public mouse mousescript;
    public shootb shootbscript;
    public shootb gunchanger;



    void Start()
    {
        audio = GetComponent<AudioSource>();
        point.enabled = true;
        first.active = true;
        second.active = false;
        
       // py = player.GetComponent<player>();
        compres = movementamount;
        exten = -movementamount;
        rb = gun.GetComponent<Rigidbody>();
        rb1 = gun1.GetComponent<Rigidbody>();
        gunpos = gun.transform.localPosition;
        dst = 7;
        on = true;
        gunapp = true;
        gunapp1 = false;
        range = 52f;
        mousemovexx = 90;
        transform.eulerAngles = new Vector3(0, 90, 0);
    }


    void Update()
    {

                  // camera move karega plyer nahi so automaticalyy when mw aim the only turnings allow movement is only forward
       


       /* if(mousescript.rightclickdown)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }*/
        
        
        if (shootbscript.shootingstart/* && (py.health > 0f)*/)
        {
         
           // transform.position = target1.transform.position;
           // point.enabled = true;
            first.active = gunapp;
            second.active = gunapp1;
           


            if (gunchanger.shootbuttondown)
            {
                if (gunapp)
                {
                    gunapp = false;
                    range = 100f;
                }
                else
                    gunapp = true;
                if (gunapp1)
                {
                    gunapp1 = false;
                    range = 52f;
                }
                else
                    gunapp1 = true;
            }



            if (shootbscript.shootbuttondown)
            {

                audio.Play();
                RaycastHit hit;
                Vector3 newvec = targetforpoint.transform.position - bulletspace.transform.position;
                gunmuzzel.Play();
                if (Physics.Raycast(bulletspace.transform.position, newvec, out hit, range))
                {
                    if (hit.transform.tag == "enemy")
                    {
                        bullets _bullets;
                        _bullets = hit.transform.GetComponent<bullets>();
                        _bullets.crack();

                    }
                    if (hit.transform.tag == "enemy1")
                    {
                        anim2 = hit.transform.GetComponent<Animator>();
                        if (gunapp1)
                        {
                            count += 3;

                        }
                        else
                        {
                            count++;

                        }
                        enemy enemy1;

                        on = false;
                        enemy1 = hit.transform.GetComponent<enemy>();

                        enemy1.blood.Play();
                        anim2.Play("DAMAGED00");
                        if (count >= 5)
                        {
                            enemy1.life = false;
                            enemy1.blood1.Play();
                            count = 0;
                        }
                    }
                    if (hit.transform.tag == "enemy2")
                    {
                        anim3 = hit.transform.GetComponent<Animator>();
                        if (gunapp1)
                        {
                            count1 += 3;

                        }
                        else
                        {
                            count1++;

                        }
                        motor enemy2;

                        on = false;
                        enemy2 = hit.transform.GetComponent<motor>();

                        enemy2.blood.Play();
                        anim3.Play("DAMAGED00");
                        if (count1 >= 5)
                        {
                            enemy2.life1 = false;
                            enemy2.blood1.Play();
                            count1 = 0;
                        }
                        if (hit.transform.tag == "enemy3")
                        {
                            anim4 = hit.transform.GetComponent<Animator>();
                            count1 += 3;
                            toerman enemy3;

                            on = false;
                            enemy3 = hit.transform.GetComponent<toerman>();

                            anim3.Play("DAMAGED00");
                            if (count1 >= 5)
                            {
                                enemy2.life1 = false;
                                count1 = 0;
                            }
                        }
                    }
                   

                }

                rb.AddForce(-gun.transform.forward * 20);
                rb1.AddForce(gun1.transform.forward * 20);
            }
            else
            {
                gun.transform.localPosition = Vector3.SmoothDamp(gun.transform.localPosition, gunpos, ref refv, 0.1f);
                gun1.transform.localPosition = Vector3.SmoothDamp(gun1.transform.localPosition, gunpos, ref refv1, 0.1f);
            }


        }
        else
        {
           // point.enabled = false;
          
            first.active = true;
            second.active = false;
            mousemoveyy = Mathf.Clamp(mousemoveyy, -35f, 60f);
            on = true;


        }
    }
}

