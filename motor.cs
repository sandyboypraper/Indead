using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class motor : MonoBehaviour {

    public GameObject[] target1 = new GameObject[3];
    NavMeshAgent agent;
    public GameObject target;
    Rigidbody rbody1;
    Animator anim;
    float dst;
    Vector3 cur;
    public bool life1;
    player plscr;
    public GameObject gun,cameraa1;
    public ParticleSystem blood, blood1,mugg;
    camera cam1;
    public bool on1;


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        rbody1 = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        life1 = true;
        cam1 = cameraa1.GetComponent<camera>();
        on1 = cam1.on;
        anim.SetBool("on1", on1);
    }
	
	
	void Update () {
        int i = Random.Range(0, 3);
        Vector3 vec2 = target1[i].transform.position - transform.position;
        Vector3 vec = transform.position - target.transform.position;
        Vector3 vec1 = new Vector3(vec.x, 0, vec.z);
        agent.stoppingDistance =  8f;
        if (life1)
        {
            RaycastHit hit2;
            if (vec.magnitude < 100f)
            {
                transform.forward = Vector3.SmoothDamp(transform.forward, new Vector3(-vec.x, 0, -vec.z), ref cur, 0.5f);
                agent.SetDestination(target.transform.position);
            }
            if (vec.magnitude <= 8f)
            {

                transform.forward = Vector3.SmoothDamp(transform.forward, new Vector3(-vec.x, 0, -vec.z), ref cur, 0.5f);
            }
            if (Physics.Raycast(gun.transform.position, vec2, out hit2, 50) && vec1.magnitude <= 50f)
            {
                plscr = hit2.transform.GetComponent<player>();
                if (hit2.transform.name == "ToonSoldier_WW2_demo_model")
                {
                    mugg.Play();
                    plscr.health--;
                }

            }
        }
        else
        {
            anim.Play("DAMAGED01");
            Destroy(gameObject, 2.3f);
        }
        anim.SetFloat("dst", vec.magnitude); 



    }
}
