using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

	void Start () {
		this.rb = GetComponent<Rigidbody> ();
		this.count = 0;
		this.winText.text = "";
		this.UpdateCountText ();
	}
		
	void FixedUpdate () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (h, 0, v);

		this.rb.AddForce (movement * speed);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			this.count++;
			this.UpdateCountText ();
		}
	}
		
	void UpdateCountText() {
		this.countText.text = "Count: " + this.count.ToString();
		if (this.count >= 12) {
			this.winText.text = "Ya done it!";
		}
	}
}
