﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	public Text countText;
	public Text winText;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCounter();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Pick up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			setCounter ();


		}
		if (count >= 12) 
		{
			winText.text = "You win!";
		}
	}

	void setCounter()
	{
		countText.text = "Count:" + count.ToString();
	}
}
