using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour 
{
	public string jumpButton  = "Jump";
	public float jumpPower = 250.0f;
	public Animator anim;
	private bool isJumping = false;

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown(jumpButton) && !isJumping) 
		{
			isJumping = true;
			anim.SetTrigger("Jump Start");
			rigidbody2D.AddForce(transform.up * jumpPower);
		}
	}

	void OnCollisionEnter2D()
	{
		if (isJumping)
		{
			isJumping = false;
			anim.SetTrigger ("Jump End");
		}
	}
}
