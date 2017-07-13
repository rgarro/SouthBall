using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed ;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;


	void Start(){
		this.speed = 4.13f;
		rb = GetComponent<Rigidbody> ();
		this.count = 0;
		this.setCountText ();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.05f, moveVertical);
		rb.AddForce (movement * this.speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			this.count = this.count + 1;
			this.setCountText ();
		}

    }

	void setCountText(){
		this.countText.text = "Count: " + this.count.ToString ();
		if(this.count == 6){
			winText.text = "You Won !!";
		}
	}
}