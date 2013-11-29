using UnityEngine;
using System.Collections;

public class Chimney : MonoBehaviour 
{
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		anim.SetTrigger ("Demolish");
		gameObject.collider2D.enabled = false;
		SoundEffectsHelper.Instance.MakeChimneyCollapseSound();
	}
}
