using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour 
{
	public static PlayerScore Instance;

	public bool updateScore = true;
	public float score;
	float sessionTime;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		sessionTime = 0;

		if (Instance != null)
		{
			Debug.LogError("Multiple instances of PlayerScore!");
		}
		Instance = this;
	}

	void Update () 
	{
		if (updateScore)
		{
			sessionTime += Time.deltaTime;
			float i = sessionTime * (2.8f * (sessionTime / 3));
			score = Mathf.Ceil(i);
		}
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(20,20,200,20), "Score: " + score);
	}

	public void ResetGame()
	{
		sessionTime = 0;
		score = 0;
	}
}