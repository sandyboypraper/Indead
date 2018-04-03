using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject[] target = new GameObject[3];
    CharacterController cont;
    float mag;
    float dst;
    Animator anim;
     public bool life;
    public GameObject target1, cameraa,gun;
   public  ParticleSystem muggel;
    camera cam;
    bool on1;
    player plscr;
    public ParticleSystem blood, blood1;


    void Start()
    {
        cont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        life = true;
        cam = cameraa.GetComponent<camera>();
        on1 = cam.on;
        anim.SetBool("on",on1 );
       
    }


    void Update()
    {
        int i = Random.Range(0 , 3);
      
        Vector3 vec = target[i].transform.position - transform.position;//transform.forward;
        Vector3 veci = transform.position - target[0].transform.position;
        Vector3 vec1 = new Vector3(veci.x, 0, veci.z);
        if (life)
        {
            RaycastHit hit1;
            if (vec1.magnitude < 50f && vec1.magnitude >= 3)
            {
               
                mag = 0.5f;
                if (Input.GetKey(KeyCode.RightShift))
                {
                    mag = 0.5f;
                }
                else if (vec1.magnitude < 30 )
                {
                  
                    mag = 1f;
                }
   
                transform.forward = new Vector3(-veci.x, 0f, -veci.z);
              
                cont.Move(-vec1 * mag * Time.deltaTime);

            }
            
            if (Physics.Raycast(gun.transform.position, vec, out hit1, 50) && vec1.magnitude<50f)
            {
               
                plscr = hit1.transform.GetComponent<player>();
                if (hit1.transform.name == "ToonSoldier_WW2_demo_model")
                {      
                    muggel.Play();
                    plscr.health--;
                }

            }
          
            anim.SetFloat("dst", vec1.magnitude);
        }
        else
        {
            anim.Play("DAMAGED01");
            Destroy(gameObject, 2.5f); 
        }
        
    }
}
    

