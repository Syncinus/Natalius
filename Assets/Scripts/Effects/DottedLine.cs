using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lines {
public class DottedLine : MonoBehaviour {
		public Sprite Dot;
		public Material Mat;
		public Color32 Color;
		[Range(0.01f, 1f)]
		public float Size;
		[Range(0.1f, 2f)]
		public float Delta;

		private static DottedLine instance;
		public static DottedLine Instance {
			get {
				if (instance == null)
					instance = FindObjectOfType<DottedLine> ();
				return instance;
			}
		}

		List<Vector2> positions = new List<Vector2>();
		List<GameObject> dots = new List<GameObject>();

		void FixedUpdate()
		{
			//if (positions.Count > 0)
			//{
			//	DestroyAllDots();
			//	positions.Clear();
			//}

		}
	
		private void DestroyAllDots()
		{
			foreach (var dot in dots) {
				Destroy (dot);
			}
			dots.Clear ();
		}

		GameObject GetOneDot()
		{
			var gameObject = new GameObject ();
			gameObject.transform.localScale = Vector3.one * Size;
			gameObject.transform.parent = transform;

			var sr = gameObject.AddComponent<SpriteRenderer> ();
			sr.material = Mat;
			sr.sprite = Dot;
			sr.color = Color;
			sr.sortingOrder = 2;
			return gameObject;
		}

		public void DrawDottedLine(Vector2 start, Vector2 end)
		{
			DestroyAllDots ();

			Vector2 point = start;
			Vector2 direction = (end - start).normalized;

			while ((end - start).magnitude > (point - start).magnitude) {
				positions.Add (point);
				point += (direction * Delta);
			}

			Render ();
		}

		public void Clean() {
			if (positions.Count > 0) {
				DestroyAllDots ();
				positions.Clear ();
			}
		}


		private void Render()
		{
			foreach (var position in positions) {
				var g = GetOneDot ();
				g.transform.position = position;
				dots.Add (g);
			}
		}
	}
}
