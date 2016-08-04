using UnityEngine;
using System.Collections;

public class ShadowInputPlayer : InputPlayer
{
	[SerializeField]
	private Gun gun;

	public override void PlayInput (InputState inputState)
	{
		foreach (var keycode in inputState.keyCode) 
		{
			if (keycode == KeyCode.Space) 
			{
				gun.Fire ();
			}
		}

	}
}

