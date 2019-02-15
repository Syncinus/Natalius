using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingGenerator : MonoBehaviour {

	public Transform Ring;
	public float Delay;
	public float Timing;

	void Awake () {
		StartCoroutine (UpdateRings ());
	}

	private IEnumerator UpdateRings() {
		while (true) {
			Transform NewRing = Instantiate (Ring, Vector2.zero, Quaternion.identity, transform);
			NewRing.localScale = new Vector3 (200, 200, 1);
			NewRing.GetComponent<SpriteRenderer> ().color = Color.black;
			Vector3 StartSize = new Vector3 (200, 200, 1);
			Vector3 EndSize = new Vector3 (100, 100, 1);

			float Timer = 0.0f;
			do {
				NewRing.localScale = Vector2.Lerp(StartSize, EndSize, Timer / Timing);
				Timer += Time.deltaTime * GameSettings.GameSpeed;
				yield return null;
			} while (Timer < Timing);
			Destroy (NewRing.gameObject);
			yield return new WaitForSeconds (Delay * GameSettings.GameSpeed);
		}
	}
}
