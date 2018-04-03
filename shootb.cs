using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootb : MonoBehaviour {

    GUITexture tex;
    public bool shootbuttondown;
    public bool shootingstart;

    float deltatime = 0;

    void Start () {
        tex = GetComponent<GUITexture>();
        shootbuttondown = false;
        shootingstart = false;
    }
	
	
	void Update ()
    {
        if (Input.touches.Length > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (tex.HitTest(Input.GetTouch(i).position))
                {

                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        shootbuttondown = true;
                        shootingstart = true;
                        deltatime = 0;
                           
                    }
                    else
                    {
                        shootbuttondown = false;
                         
                    }
                    
                }

            }
        }
        if (shootingstart)
        {
            deltatime += 0.1f;
            if (deltatime > 3)
                Invoke("reshooting", 0.5f);
        }
    }

    void reshooting()
    {      
        shootingstart = false;
    }
}
