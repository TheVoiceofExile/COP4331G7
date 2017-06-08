using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public static float pixelsToUnits = 1f;
	public static float scale = 1f;
	public Vector2 nativeRes = new Vector2(240, 160);

	void Awake()
	{
		var camera = GetComponent<Camera>();

		if(camera.orthographic)
		{
			scale = Screen.height / nativeRes.y;
			pixelsToUnits *= scale;
			camera.orthographicSize = (Screen.height / 2f) / pixelsToUnits;
		}
	}
}
