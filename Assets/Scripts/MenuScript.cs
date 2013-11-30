using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour 
{
	void OnGUI()
	{
		const int buttonWidth = 100;
		const int buttonHeight = 40;
		const int y = 450;
		const int x = 430;

		Rect rect = new Rect(x, y, buttonWidth, buttonHeight);

		if (GUI.Button(rect, "Start!"))
		{
			Application.LoadLevel("Stage1");
		}
	}
}
