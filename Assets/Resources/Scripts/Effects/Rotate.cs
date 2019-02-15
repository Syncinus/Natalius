using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float Speed = 5.0f;

    private void FixedUpdate () {
        transform.Rotate(0, 0, Speed * Time.deltaTime * GameSettings.GameSpeed, Space.Self);
	}
}
