using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{                 
    GUITexture tex;
    public bool rightclick,rightclickdown;
    Vector2 initial;
    Vector2 final;

    float rotx = 0;
    float roty = 0;

    private float rotationalspeed = 1f;
    public float dir = -1;

    private Touch initouch;
    public Camera cam;

    float ini, fin;

    Rect aim = new Rect(0,0,Screen.width/2,Screen.height);

    float camroty, camrotz;

	void Start ()
    {
      //  rightclick = false;
        tex = GetComponent<GUITexture>();
        initial = Vector2.zero;
        initouch = new Touch();
        ini = 0;
        fin = 0;
	}
	

	void LateUpdate () {

        Debug.Log(rotationalspeed);

        if (Input.touches.Length>0)
        {
            for(int i=0;i<Input.touches.Length;i++)
            {
                if(aim.Contains(Input.GetTouch(i).position))
                {

                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                       // rightclick = (rightclick == true) ? (false) : (true);
                        rightclickdown = true;
                        Invoke("rerightclick", 0.2f);
                        initouch.position = Input.GetTouch(i).position;
                    }
                    else if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {

                        // initouch = new Touch();
                        ini = ini + camrotz;
                        fin = fin + camroty;
                        camrotz = 0;
                        camroty = 0;
                        // camrotz = 0;
                        // camroty = 0;
                        //cam.transform.eulerAngles = new Vector3(0, 90, 0);
                    }

                     else if(Input.GetTouch(i).phase == TouchPhase.Moved|| Input.GetTouch(i).phase == TouchPhase.Stationary)
                    {
                        rotx = -(Input.GetTouch(i).position.x - initouch.position.x);
                        roty = Input.GetTouch(i).position.y - initouch.position.y;
                        
                       
                        camroty = rotx * rotationalspeed * dir  ;
                        camrotz = roty * rotationalspeed * dir ;

                            // camrotz =   Mathf.Clamp(camrotz, -10, 15);
                            // camroty =   Mathf.Clamp(camroty, -55, 55);

                        // cam.transform.rotation = Quaternion.Euler(0, 90 + fin + camroty, 0);
                       

                    }

                  

                 
                }

            }
        }
	}

    private void FixedUpdate()
    {
        cam.transform.eulerAngles = new Vector3(0, 90 + fin + camroty, 0);
    }

    void rerightclick()
    {
        rightclickdown = false;
    }
}
