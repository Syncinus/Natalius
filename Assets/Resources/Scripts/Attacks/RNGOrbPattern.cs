using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RNGOrbPattern", menuName = "New RNG Orb Pattern")]
public class RNGOrbPattern : OrbPattern
{
    public Orb Object;
    public float Times;
    public Vector2 RandomLimits;
}

