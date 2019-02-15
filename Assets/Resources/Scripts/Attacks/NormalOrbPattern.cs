using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalOrbPattern", menuName = "New Orb Pattern")]
public class NormalOrbPattern : OrbPattern
{
    public List<Orb> Pattern = new List<Orb>();
}

