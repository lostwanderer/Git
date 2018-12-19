using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectorController : MonoBehaviour {
    GameObject timerText;
    GameObject generator;
    float time = 30.0f;
	// Use this for initialization
	void Start () {
        this.generator = GameObject.Find("Generator");
        this.timerText = GameObject.Find("Time");
	}
	
	// Update is called once per frame
	void Update () {
        this.time -= Time.deltaTime;
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        else if (5 <= this.time && this.time < 12)
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        else if (12 <= this.time && this.time < 23)
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
	}
}
