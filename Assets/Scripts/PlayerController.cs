using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed =500;
	public float speedAc = 10;

	//accelerometer
	private Vector3 zeroAc;
	private Vector3 curAc;
	private float sensH = 10;
	private float sensV = 10;
	private float smooth = 0.5f;
	private float GetAxisH = 0;
	private float GetAxisV = 0;

	//public float speed ;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	public AudioSource mySound;

	private SoundTest soun;

	void Start(){
		//this.speed = 4.13f;
		rb = GetComponent<Rigidbody> ();
		this.count = 0;
		this.setCountText ();
		winText.text = "";
	}

	void FixedUpdate(){
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement * this.speed * Time.deltaTime);
		}else
		{
			// Player movement in mobile devics
			// Building of force vector 
			//Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
			// Adding force to rigidbody
			//rb.AddForce(movement * speed * Time.deltaTime);

			//get input by accelerometer
			curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
			GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
			GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
			// now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
			// If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
			// in the above equations. If some axis is going in the wrong direction, invert the
			// signal (use -curAc.x or -curAc.y)

			Vector3 movement = new Vector3 (GetAxisH, 0.0f, GetAxisV);

			rb.AddForce(movement * speedAc);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			this.count = this.count + 1;
			this.setCountText ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();

			//mySound.PlayOneShot ();
		}

    }

	void setCountText(){
		this.countText.text = "Count: " + this.count.ToString ();
		if(this.count == 6){
			winText.text = "You Won !!";
		}
	}
}