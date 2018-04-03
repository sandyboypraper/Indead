using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toerman : MonoBehaviour {

    public GameObject target;
    Vector3 vec;
    player pl;
    public ParticleSystem muggel;
    bool life;
    Animator anim1;
    void Start () {
		pl = target.GetComponent<player>();
        life = true;
        anim1 = GetComponent<Animator>();
    }
	
	
	void Update () {
        vec = target.transform.position - transform.position;
        if (life)
        {
            if (vec.magnitude < 100)
            {
                muggel.Play();
                transform.forward = vec;
                pl.health = pl.health - 0.1f;
            }
        }
        else
        {
            anim1.Play("DAMAGED01");
            Destroy(gameObject, 2.5f);
        }
	}
}
