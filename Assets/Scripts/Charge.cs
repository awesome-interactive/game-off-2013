using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour 
{
	public string chargeButton  = "Jump";
	public float chargePower = 10.0f;
	public bool isCharging = false;
	public float rechargeRate = 0.50f;
	public float recharge = 0;
	public Animator anim;
	public float chargeDistance = 0.5f;
	private int chargeCurrentFrame = 0;
	public int chargeFrameCount = 15;
	private int chargeDirection = 0;
	private float startingPos;
	private float speed;

	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
		recharge = 0f;
		startingPos = transform.position.x;
		speed = (chargeDistance / chargeFrameCount);
	}
	
	void Update () 
	{
		if (recharge > 0) 
		{
			recharge -= Time.deltaTime;
		}
		else
		{
			isCharging = false;
		}

		if (Input.GetButtonDown(chargeButton) && !isCharging)
		{
			isCharging = true;
			recharge = rechargeRate;
			anim.SetTrigger("Charge");
			Debug.Log("Charge" + rechargeRate);
			rigidbody2D.AddForce (transform.right * chargePower);
			chargeDirection = 1;
		}

		if(chargeDirection == 1) 
		{
			Vector3 movement = new Vector3(speed, 0);
			transform.Translate(movement);

			if(++chargeCurrentFrame == chargeFrameCount) 
			{
				chargeDirection = -1;
			}
		}
		else if (chargeDirection == -1) 
		{
			Vector3 movement = new Vector3(-speed, 0);
			transform.Translate(movement);
			if(--chargeCurrentFrame == 0) 
			{
				chargeDirection = 0;
			}
		}
	}
}
