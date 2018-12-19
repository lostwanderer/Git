﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if(this.delta> span)
        {
            this.delta = 0;
            int dice = Random.Range(1, 11);
            GameObject item;
            if (dice <=ratio)
            {
               item = Instantiate(bombPrefab) as GameObject;

            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }
            float itemx = Random.Range(-1, 2);
            float itemz = Random.Range(-1, 2);
            item.transform.position = new Vector3(itemx, 4, itemz);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
		
	}
}
