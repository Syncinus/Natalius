using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : GameController {

    public void Start()
    {
        StartCoroutine(LevelExecution());
    }

    public IEnumerator LevelExecution()
    {

        yield return null;
    }

}
