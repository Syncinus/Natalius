using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Direction;
	public float PassedTime = 0.5f;

    float DistanceTravelled;
    Vector3 LastPosition;

    public void Start()
    {
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));	
		LastPosition = transform.position;
		if (PassedTime > 0) {
			transform.Translate(Vector3.up * PassedTime * Speed * 10, Space.Self);
			DistanceTravelled += Vector3.Distance(transform.position, LastPosition);
		}
    }

    public void FixedUpdate()
    {
		transform.Translate(Vector3.up * Time.deltaTime * Speed * 10, Space.Self);
        DistanceTravelled += Vector3.Distance(transform.position, LastPosition);
        LastPosition = transform.position;
        if (DistanceTravelled > 75)
        {
            Destroy(gameObject);
        }
    }
}

