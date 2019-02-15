using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour {

    public Transform Core;
    public float Angle;

	private void FixedUpdate () {
		transform.RotateAround (Core.position, new Vector3 (0f, 0f, -1f), Angle * GameSettings.GameSpeed);
	}
}
