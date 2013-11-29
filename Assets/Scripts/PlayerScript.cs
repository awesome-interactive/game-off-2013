using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behaviour
/// </summary>
public class PlayerScript : MonoBehaviour 
{
	public int speed = 5;
	public bool isJeykll = true;
	public Animator anim;
	public bool IsDead = false;

	private Jump jump;
	private Charge charge;

	void Start()
	{
		jump = GetComponent<Jump> ();
		charge = GetComponent<Charge> ();
		anim = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () 
	{
		jump.enabled = isJeykll;
		charge.enabled = !isJeykll;

		Move();

		if (Input.GetButtonDown("Fire1")) 
		{
			Transform();
		}
	}

	private void Move()
	{
		float inputX = Input.GetAxis("Horizontal");
		Vector3 movement = new Vector3(speed * inputX, 0);
		movement *= Time.deltaTime;
		transform.Translate(movement);
	}

	private void Transform()
	{
		if (isJeykll)
		{
			isJeykll = false;
			anim.SetTrigger("Transform to Hyde");
		}
		else
		{
			isJeykll = true;
			anim.SetTrigger("Transform to Jekyll");
		}
	}

	private void Die()
	{
		IsDead = true;
		speed = 0;

		if (isJeykll)
		{
			anim.SetTrigger("Jeykll Dead");
		}
		else 
		{
			anim.SetTrigger("Hyde Dead");
		}

		transform.parent.gameObject.AddComponent<GameOverScript>();
	}

	void OnBecameInvisible()
	{
		Die();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		Chimney chimney = collider.gameObject.GetComponent<Chimney>();

		if (chimney != null) 
		{
			if (!isJeykll && charge.isCharging)
			{
				Debug.Log("You live");
			}
			else 
			{
				Die ();
			}
		}
	}
}
