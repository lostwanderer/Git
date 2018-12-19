using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2D;
    float jumpForce = 780.0f;
    float walkForce = 30.0f;
    float maxWalkForce = 2.0f;
    float acc = 0.2f;
    Animator animator;
	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y ==0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            this.animator.SetTrigger("JumpTrigger");
        }
        int key = 0;
        if (Input.acceleration.x > this.acc) key = 1;
        if (Input.acceleration.x < -this.acc) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkForce)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        if (this.rigid2D.velocity.y == 0)
            this.animator.speed = speedx / 2.0f;
        else
            this.animator.speed = 1.0f;

        if (transform.position.y < -10)
            SceneManager.LoadScene("GameoverScene");
    }
        void OnTriggerEnter2D(Collider2D other)
        {
        SceneManager.LoadScene("ClearScene");
        }
    
}
