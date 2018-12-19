using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour {

    public AudioClip appleSE;
    public AudioClip bombSE;
    int point = 0;
    GameObject pointText;
    AudioSource aud;
	// Use this for initialization
	void Start () {
        this.aud = GetComponent<AudioSource>();
        this.pointText = GameObject.Find("Point");
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            this.point += 10;
        }
            
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            this.point /= 2;
        }
           
        Destroy(other.gameObject);

    }
    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);

            }
        }
        this.pointText.GetComponent<Text>().text = this.point.ToString() + "points";
	}
}
