using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntervalOrbPattern", menuName = "New Interval Orb Pattern")]
public class IntervalOrbPattern : OrbPattern
{
    public float StartDirection;
    public float Interval;
    public float Times;
    public Orb Object;
    public int[] ReversePoints;
}
