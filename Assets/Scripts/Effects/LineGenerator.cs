using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour {

    public Transform Core;
    public Transform Line;
    public Transform EffectStorage;
    public int Interval;
    public float LineAngle;

    private Vector3 OriginalPosition = new Vector3(-80f, 0f, 0f);
    private Quaternion OriginalRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
    private Vector3 OriginalScale = new Vector3(30f, 65f, 10f);

    private void Awake()
    {
        for (int i = 0; i < 360; i += Interval)
        {
            Transform NewLine = Instantiate(Line, OriginalPosition, OriginalRotation, EffectStorage);
            NewLine.localScale = OriginalScale;
            NewLine.RotateAround(Core.position, new Vector3(0f, 0f, -1f), i);
            NewLine.GetComponent<SpriteRenderer>().sortingOrder = -1;
            Looper LoopingEffect = NewLine.gameObject.AddComponent<Looper>();
            LoopingEffect.Angle = LineAngle;
            LoopingEffect.Core = Core;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
