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

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
		recharge = 0f;
	}
	
	// Update is called once per frame
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
		}
		else if (Input.GetButtonDown(chargeButton) && isCharging) 
		{
			Debug.Log("I'm Already charging");
		}

	}
}
