using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour 
{
	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffectsHelper Instance;

	public AudioClip chimneyCollapse;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	/// <summary>
	/// Makes the chimney collapse sound.
	/// </summary>
	public void MakeChimneyCollapseSound()
	{
		MakeSound(chimneyCollapse);
	}

	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip">clip to play</param>
	private void MakeSound(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint(clip, transform.position);
	}
}
