using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moonstruck : GameController {
    public void Start()
    {
        StartCoroutine(LevelExecution());
    }
    public IEnumerator LevelExecution()
    {
        yield return new WaitForSeconds(0.1f);
        MusicCheck = true;
        #region Initilization
        SetToInitilizationScheme();
        Color32 Coloring = new Color32(153, 0, 0, 255);
        yield return StartCoroutine(WaitForTime(1f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 270f, 4f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.75f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 90f, 4f, 18, 10f);
        yield return StartCoroutine(WaitForTime(1.25f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 4f, 18, 20f);
        yield return StartCoroutine(WaitForTime(0.75f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 4f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 180f, 4f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(Coloring, 0f, 170f, 1.25f, false);
        LaserCutter(Coloring, 180f, 350f, 1.25f, false);
        yield return StartCoroutine(WaitForTime(1.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 180f, 4f, 9, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 90f, 270f, 4f, 9, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, 0f, 1f, 0f, false, 3f, 200f, 0f, 0f);
        ChoppingBeam(Coloring, 90f, 1f, 0f, false, 3f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, 45f, 1f, 0f, false, 3f, 200f, 0f, 0f);
        ChoppingBeam(Coloring, 135f, 1f, 0f, false, 3f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(1.25f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 4f, 28, 10f);
        yield return StartCoroutine(WaitForTime(0.75f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 180f, 4f, 28, 10f);
        yield return StartCoroutine(WaitForTime(1.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 180f, 4f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 90f, 270f, 4f, 13, 10f);
        yield return StartCoroutine(WaitForTime(1.25f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 4f, 18, 20f);
        yield return StartCoroutine(WaitForTime(1.25f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 45f, 225f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 135f, 315f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 180f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 90f, 270f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(1.25f));
        //ChoppingBeam(Coloring, )
        //LaserCutter(Coloring, 270f, 360f, 1.5f, false);
        #endregion
    }

    #region Color Schemes
    public void SetToInitilizationScheme()
    {
        ColorScheme InitilizationScheme = new ColorScheme();
        InitilizationScheme.Name = "Initilization Scheme";
        InitilizationScheme.BackgroundColor = Color.black;
        InitilizationScheme.PlayerColor = new Color32(153, 0, 0, 255);
        InitilizationScheme.LineColor = Color.clear;
        InitilizationScheme.CoreColor = new Color32(153, 0, 0, 255);
        InitilizationScheme.LargeRingColor = new Color32(153, 0, 0, 255);
        InitilizationScheme.SmallRingColor = new Color32(153, 0, 0, 255);
        InitilizationScheme.CenterCircle.Color1 = Color.clear;
        InitilizationScheme.CenterCircle.Color2 = Color.clear;
        InitilizationScheme.MiddleCircle.Color1 = Color.clear;
        InitilizationScheme.MiddleCircle.Color2 = Color.clear;
        InitilizationScheme.EnclosingCircle.Color1 = Color.clear;
        InitilizationScheme.EnclosingCircle.Color2 = Color.clear;
        InitilizationScheme.LoopingCircle.Color1 = Color.clear;
        InitilizationScheme.LoopingCircle.Color2 = Color.clear;
        InitilizationScheme.CoreVibrating = false;
        ChangeColors(InitilizationScheme);
    }
    #endregion
}
