using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    float speed = 0;
    Vector2 startpos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            this.startpos = Input.mousePosition;
            
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 endpos = Input.mousePosition;
            float SwipeLength = endpos.x - startpos.x;

            this.speed = SwipeLength / 500.0f;
            GetComponent<AudioSource>().Play();
        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
	}
}
