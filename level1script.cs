using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1script : MonoBehaviour {
    AudioSource audio;

	void Start () {
        audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
}
