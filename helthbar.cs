using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helthbar : MonoBehaviour {

  //  player pl;
    float a, b;
    public GameObject player;
    public Image im;
	void Start () {
       // pl = player.GetComponent<player>();       
        b = 3; 
	}
	
	
	void Update () {
       // a = pl.health;
        b = (a / 100) * 3;
        b =  Mathf.Clamp(b, 0, 3);
        im.transform.localScale = new Vector3(b, 0.08284f,1);

    }
}
