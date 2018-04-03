using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausebutton : MonoBehaviour {

    GUITexture tex;
     public bool pressed;
	
	void Start () {
        tex = GetComponent<GUITexture>();
        }
	
	
	void Update ()
    {
        if (Input.touches.Length > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if(tex.HitTest(Input.GetTouch(i).position))
                {
                    if(Input.GetTouch(i).phase==TouchPhase.Began)
                    {
                        pressed = true;

                        Invoke("repressed", 1f);
                    }

                }

            }
        }

    }

    private void repressed()
    {
        pressed = false;
    }


}
