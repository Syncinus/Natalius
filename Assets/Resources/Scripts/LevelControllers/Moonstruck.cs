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
        /*
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
        yield return StartCoroutine(WaitForTime(1f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 45f, 225f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 135f, 315f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 180f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        DoubleSpreadOrbPattern(Coloring, new Vector2(5f, 5f), 90f, 270f, 3f, 13, 10f);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(Coloring, 30, 1, 0, false);
        ChoppingBeam(Coloring, 60, 1, 0, false);
        ChoppingBeam(Coloring, 90, 1, 0, false);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, 120, 1, 0, false);
        ChoppingBeam(Coloring, 150, 1, 0, false);
        ChoppingBeam(Coloring, 180, 1, 0, false);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, 210, 1, 0, false);
        ChoppingBeam(Coloring, 240, 1, 0, false);
        ChoppingBeam(Coloring, 270, 1, 0, false);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, 300, 1, 0, false);
        ChoppingBeam(Coloring, 330, 1, 0, false);
        ChoppingBeam(Coloring, 360, 1, 0, false);
        WarningRectangle(Coloring, new Vector2(5f, 200f), Vector2.zero, 3, 1.3f, 0f);
        WarningRectangle(Coloring, new Vector2(5f, 200f), Vector2.zero, 3, 1.3f, 90f);
        WarningRectangle(Coloring, new Vector2(5f, 200f), Vector2.zero, 3, 1.3f, 45f);
        WarningRectangle(Coloring, new Vector2(5f, 200f), Vector2.zero, 3, 1.3f, 135f);
        yield return StartCoroutine(WaitForTime(1.25f));
        ChoppingBeam(Coloring, 0f, 1f, 0f, false, 5f, 100f, 0f, 0f);
        ChoppingBeam(Coloring, 90f, 1f, 0f, false, 5f, 100f, 0f, 0f);
        ChoppingBeam(Coloring, 45f, 1f, 0f, false, 5f, 100f, 0f, 0f);
        ChoppingBeam(Coloring, 135f, 1f, 0f, false, 5f, 100f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(2.25f));
        #endregion
        
        #region Elimination 
        SetToEliminationScheme();
        Color32 Coloring = Color.black;
        yield return StartCoroutine(WaitForTime(0.5f));
        AttackBursts();
        for (int i = 0; i < 13; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 30f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 13; ++i)
        {
            ChoppingBeam(Coloring, i * 30f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        AttackBursts();
        for (int i = 0; i < 14; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 25f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 14; ++i)
        {
            ChoppingBeam(Coloring, i * 25f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbPattern(Coloring, new Vector2(5f, 5f), 0f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Coloring, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f)));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Coloring, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f)));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Coloring, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f)));
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(Coloring, 0f, 360f, 3f, false);
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(Coloring, -0f, -360f, 2.75f, false);
        yield return StartCoroutine(WaitForTime(2.75f));
        AttackBursts();
        for (int i = 0; i < 13; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 30f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 13; ++i)
        {
            ChoppingBeam(Coloring, i * 30f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        AttackBursts();
        for (int i = 0; i < 14; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 25f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 14; ++i)
        {
            ChoppingBeam(Coloring, i * 25f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(Coloring, Random.Range(0f, 360f), 1f, 0f, false, 5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, Random.Range(0f, 360f), 1f, 0f, false, 5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Coloring, Random.Range(0f, 360f), 1f, 0f, false, 5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 0f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 180f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 90f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 270f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        AttackBursts();
        for (int i = 0; i < 13; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 30f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 13; ++i)
        {
            ChoppingBeam(Coloring, i * 30f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        AttackBursts();
        for (int i = 0; i < 14; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 25f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 14; ++i)
        {
            ChoppingBeam(Coloring, i * 25f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 6; i++)
        {
            SpreadOrbExplosion(Coloring, new Vector2(10f, 10f), 180f, 5f, 1, 10f, new Vector2(Random.Range(-50f, 50f), 50f));
            SpreadOrbExplosion(Coloring, new Vector2(10f, 10f), 180f, 5f, 1, 10f, new Vector2(Random.Range(-50f, 50f), 50f));
            SpreadOrbExplosion(Coloring, new Vector2(10f, 10f), 180f, 5f, 1, 10f, new Vector2(Random.Range(-50f, 50f), 50f));
            SpreadOrbExplosion(Coloring, new Vector2(10f, 10f), 180f, 5f, 1, 10f, new Vector2(Random.Range(-50f, 50f), 50f));
            yield return StartCoroutine(WaitForTime(0.5f));
        }
        yield return StartCoroutine(WaitForTime(1f));
        AttackBursts();
        for (int i = 0; i < 13; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 30f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 13; ++i)
        {
            ChoppingBeam(Coloring, i * 30f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        AttackBursts();
        for (int i = 0; i < 14; ++i)
        {
            WarningRectangle(Coloring, new Vector2(2.4f, 100f), new Vector2(0f, 130f), 2, 1f + (0.1f * i), i * 25f);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 14; ++i)
        {
            ChoppingBeam(Coloring, i * 25f, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        Transform Box1 = Square(Coloring, new Vector2(100f, 100f), 3);
        Box1.position = new Vector2(-175f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        Transform Box2 = Square(Coloring, new Vector2(100f, 100f), 3);
        Box2.position = new Vector2(175f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        List<GameObject> Things = new List<GameObject>();
        List<float> Positions = new List<float>();
        Things.Add(Box1.gameObject);
        Things.Add(Box2.gameObject);
        for (int i = 0; i < 20; i++)
        {
            float NewPos = UnityEngine.Random.Range(-45f, 45f);
            Positions.Add(NewPos);
            Vector2 Location = new Vector2(0f, NewPos);
            WarningRectangle(Coloring, new Vector2(100f, 0.5f), Location, 3, 0.9f, 0f);
            //Transform NBox = Square(Color.black, new Vector2(100f, 0.5f), 3);
            //NBox.position = new Vector2(0f, UnityEngine.Random.Range(-40f, 40f));
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 20; i++)
        {
            float Position = Positions[i];
            Transform NBox = Square(Coloring, new Vector2(100f, 0.5f), 3);
            Things.Add(NBox.gameObject);
            if (i % 2 == 0)
            {
                NBox.position = new Vector2(-200f, Position);
            }
            else
            {
                NBox.position = new Vector2(200f, Position);
            }
            Move(NBox, new Vector2(0f, Position), 0.5f);
            yield return StartCoroutine(WaitForTime(0.125f));
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        foreach (GameObject Obj in Things)
        {
            Size(Obj.transform, new Vector2(0f, 0f), 0.5f, true);
        }
        Things.Clear();
        yield return StartCoroutine(WaitForTime(1f));
        Flash(Color.white, 0.5f, 5);
        #endregion
        

        #region Fusion
        SetToFusionScheme();
        Color32 FusionColoring = new Color32(21, 244, 238, 255);
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(FusionColoring, 0f, 360f, 1.5f);
        yield return StartCoroutine(WaitForTime(1.75f));
        PlayerCrusher(FusionColoring, new Vector2(5f, 100f), 0f, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        SpreadOrbPattern(FusionColoring, new Vector2(5f, 5f), 0f, 3f, 15, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(FusionColoring, new Vector2(5f, 5f), 90f, 3f, 15, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(FusionColoring, new Vector2(5f, 5f), 180f, 3f, 15, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(FusionColoring, new Vector2(5f, 5f), 270f, 3f, 15, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        WarningRectangle(FusionColoring, new Vector2(5, 200f), Vector2.zero, 3, 0.51f, 0f);
        WarningRectangle(FusionColoring, new Vector2(5f, 200f), Vector2.zero, 3, 0.51f, 90f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(FusionColoring, 0f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(FusionColoring, 90f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        WarningRectangle(FusionColoring, new Vector2(5, 200f), Vector2.zero, 3, 0.51f, 45f);
        WarningRectangle(FusionColoring, new Vector2(5f, 200f), Vector2.zero, 3, 0.51f, 135f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(FusionColoring, 45f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(FusionColoring, 135f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(FusionColoring, 0f, 1.5f, 0f, false, 5f);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(FusionColoring, 45f, 1.5f, 0f, false, 5f);
        ChoppingBeam(FusionColoring, 315f, 1.5f, 0f, false, 5f);
        yield return StartCoroutine(WaitForTime(1.25f));
        LaserCutter(FusionColoring, 0f, 162.5f, 1.5f, true);
        LaserCutter(FusionColoring, -0f, -162.5f, 1.5f, true);
        yield return StartCoroutine(WaitForTime(1f));
        InverseSpreadOrbPattern(FusionColoring, new Vector2(5f, 5f), 0f, 4f, 18, 20f);
        yield return StartCoroutine(WaitForTime(0.5f));
        InverseSpreadOrbPattern(FusionColoring, new Vector2(5f, 5f), 10f, 4f, 18, 20f);
        yield return StartCoroutine(WaitForTime(1.5f));
        ChoppingBeam(FusionColoring, 0f, 1f, 0f, false, 3.5f);
        ChoppingBeam(FusionColoring, 180f, 1f, 0f, false, 3.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(FusionColoring, 30f, 1f, 0f, false, 3.5f);
        ChoppingBeam(FusionColoring, 210f, 1f, 0f, false, 3.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(FusionColoring, 60f, 1f, 0f, false, 3.5f);
        ChoppingBeam(FusionColoring, 240f, 1f, 0f, false, 3.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(FusionColoring, 90f, 1f, 0f, false, 3.5f);
        ChoppingBeam(FusionColoring, 270f, 1f, 0f, false, 3.5f);
        yield return StartCoroutine(WaitForTime(1f));
        Flash(Color.white, 0.5f, 5);
        yield return StartCoroutine(WaitForTime(0.5f));
        Flash(Color.white, 0.5f, 5);
        yield return StartCoroutine(WaitForTime(0.2f));
        #endregion
        


        SetToInitilizationScheme();
        yield return StartCoroutine(WaitForTime(82.8f));

        #region Freon
        SetToFreonScheme();
        yield return StartCoroutine(WaitForTime(0.5f));
        FreonSweeping();
        FreonBlasting();
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 90f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 270f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(1f));
        WarningRectangle(Color.black, new Vector2(5f, 200f), Vector2.zero, 3, 0.51f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 0f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 0f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 90f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 180f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 270f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(1.5f));
        ChoppingBeam(Color.black,  90f, 1f, 0.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 270f, 1f, 0.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(Color.black, 0f, 130f, 1.5f);
        LaserCutter(Color.black, -0f, -130f, 1.5f);
        yield return StartCoroutine(WaitForTime(1.75f));
        Flash(Color.white, 0.25f, 2);
        yield return StartCoroutine(WaitForTime(1.25f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 90f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 270f, 3f, 18, 10f);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(Color.black, 0f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Color.black, 45f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Color.black, 90f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Color.black, 135f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        WarningArea(Color.black, 180f, 270f, 1.25f, false, false);
        WarningArea(Color.black, 360f, 450f, 1.75f, false, false);
        yield return StartCoroutine(WaitForTime(0.5f));
        InverseSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 135f, 3f, 10, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        InverseSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 315f, 3f, 10, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 90f, 1f, 0.5f, false, 5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 270f, 1f, 0.5f, false, 5f);
        yield return StartCoroutine(WaitForTime(1.25f));
        SpreadOrbExplosion(Color.black, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(45f, 0f));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Color.black, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(-45f, 0f));
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 75f, 1f, 0f, false, 3f);
        ChoppingBeam(Color.black, 105f, 1f, 0f, false, 3f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 265f, 1f, 0f, false, 3f);
        ChoppingBeam(Color.black, 185f, 1f, 0f, false, 3f);
        yield return StartCoroutine(WaitForTime(2f));
        Flash(Color.white, 0.5f, 4);
        #endregion
        */

        SetToInitilizationScheme();
        yield return StartCoroutine(WaitForTime(104f));

        #region Reiteration
        SetToInitilizationScheme();
        Color32 ReiterationColoring = new Color32(153, 0, 0, 255);
        yield return StartCoroutine(WaitForTime(0.5f));
        Transform Rod1 = Square(ReiterationColoring, new Vector2(0f, 200f), 3);
        Transform R1P1 = Square(ReiterationColoring, new Vector2(5f, 100f), 3);
        Transform R1P2 = Square(ReiterationColoring, new Vector2(5f, 100f), 3);
        R1P1.position = new Vector2(0f,  230f);
        R1P2.position = new Vector2(0f, -230f);
        Move(R1P1, new Vector2(0f, 130f), 0.5f);
        Move(R1P2, new Vector2(0f, -130f), 0.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        Destroy(R1P1.gameObject);
        Destroy(R1P2.gameObject);
        Rod1.localScale = new Vector3(5f, 200f, 1f);

        Transform Rod2 = Square(ReiterationColoring, new Vector2(200f, 0f), 3);
        Transform R2P1 = Square(ReiterationColoring, new Vector2(100f, 5f), 3);
        Transform R2P2 = Square(ReiterationColoring, new Vector2(100f, 5f), 3);
        R2P1.position = new Vector2(230f, 0f);
        R2P2.position = new Vector2(-230f, 0f);
        Move(R2P1, new Vector2(130f, 0f), 0.5f);
        Move(R2P2, new Vector2(-130f, 0f), 0.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        Destroy(R2P1.gameObject);
        Destroy(R2P2.gameObject);
        Rod2.localScale = new Vector2(200f, 5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        Flash(Color.white, 0.25f, 2);
        Orbit(Rod1, 90f, 1f);
        Orbit(Rod2, 90f, 1f);
        List<float> Angles = new List<float>();
        List<Transform> Beams = new List<Transform>();
        for (int i = 0; i < 16; i++)
        {
            float Angle = UnityEngine.Random.Range(0f, 360f);
            Angles.Add(Angle);
            WarningRectangle(ReiterationColoring, new Vector2(1f, 200f), Vector2.zero, 2, 1f, Angle);
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < Angles.Count / 4; ++i)
        {
            float Angle = Angles[i];
            Transform Beam = Square(ReiterationColoring, new Vector2(0f, 200f), 2);
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
            Beams.Add(Beam);
            Size(Beam, new Vector2(1f, 200f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        for (int i = Angles.Count / 4; i < (Angles.Count / 4) * 2; ++i)
        {
            float Angle = Angles[i];
            Transform Beam = Square(ReiterationColoring, new Vector2(0f, 200f), 2);
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
            Beams.Add(Beam);
            Size(Beam, new Vector2(1f, 200f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        for (int i = (Angles.Count / 4) * 2; i < (Angles.Count / 4) * 3; ++i)
        {
            float Angle = Angles[i];
            Transform Beam = Square(ReiterationColoring, new Vector2(0f, 200f), 2);
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
            Beams.Add(Beam);
            Size(Beam, new Vector2(1f, 200f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        for (int i = (Angles.Count / 4) * 3; i < (Angles.Count / 4) * 4; ++i)
        {
            float Angle = Angles[i];
            Transform Beam = Square(ReiterationColoring, new Vector2(0f, 200f), 2);
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
            Beams.Add(Beam);
            Size(Beam, new Vector2(1f, 200f), 1f, false);
        }
        /*
        foreach (Transform Beam in Beams)
        {
            Size(Beam, new Vector2(1f, 0f), 0.75f, true);
        }
        */
        Beams.Clear();
        Angles.Clear();
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

    public void SetToEliminationScheme()
    {
        ColorScheme EliminationScheme = new ColorScheme();
        EliminationScheme.Name = "Elimination Scheme";
        EliminationScheme.BackgroundColor = Color.black;
        EliminationScheme.PlayerColor = new Color32(153, 0, 0, 255);
        EliminationScheme.LineColor = Color.black;
        EliminationScheme.CoreColor = Color.black;
        EliminationScheme.LargeRingColor = Color.black;
        EliminationScheme.SmallRingColor = Color.black;
        EliminationScheme.CenterCircle.Color1 = new Color32(255, 127, 0, 255);
        EliminationScheme.CenterCircle.Color2 = new Color32(153, 0, 0, 255);
        EliminationScheme.MiddleCircle.Color1 = new Color32(128, 0, 0, 255);
        EliminationScheme.MiddleCircle.Color2 = Color.yellow;
        EliminationScheme.EnclosingCircle.Color1 = new Color32(153, 0, 0, 255);
        EliminationScheme.EnclosingCircle.Color2 = new Color32(255, 127, 0, 255);
        EliminationScheme.LoopingCircle.Color1 = Color.yellow;
        EliminationScheme.LoopingCircle.Color2 = new Color32(153, 0, 0, 255);
        EliminationScheme.CoreVibrating = true;
        ChangeColors(EliminationScheme);
    }

    public void SetToFusionScheme()
    {
        ColorScheme FusionScheme = new ColorScheme();
        FusionScheme.Name = "Fusion Scheme";
        FusionScheme.BackgroundColor = Color.black;
        FusionScheme.PlayerColor = new Color32(21, 244, 238, 255);
        FusionScheme.LineColor = Color.black;
        FusionScheme.CoreColor = new Color32(21, 244, 238, 255);
        FusionScheme.LargeRingColor = new Color32(21, 244, 238, 255);
        FusionScheme.SmallRingColor = new Color32(21, 244, 238, 255);
        FusionScheme.CenterCircle.Color1 = Color.clear;
        FusionScheme.CenterCircle.Color2 = Color.clear;
        FusionScheme.MiddleCircle.Color1 = Color.clear;
        FusionScheme.MiddleCircle.Color2 = Color.clear;
        FusionScheme.EnclosingCircle.Color1 = Color.clear;
        FusionScheme.EnclosingCircle.Color2 = Color.clear;
        FusionScheme.LoopingCircle.Color1 = Color.clear;
        FusionScheme.LoopingCircle.Color2 = Color.clear;
        FusionScheme.CoreVibrating = false;
        ChangeColors(FusionScheme);
    }

    public void SetToFreonScheme()
    {
        ColorScheme FreonScheme = new ColorScheme();
        FreonScheme.Name = "Freon Scheme";
        FreonScheme.BackgroundColor = Color.black;
        FreonScheme.PlayerColor = Color.black;
        FreonScheme.LineColor = Color.black;
        FreonScheme.CoreColor = Color.black;
        FreonScheme.LargeRingColor = Color.black;
        FreonScheme.SmallRingColor = Color.black;
        FreonScheme.CenterCircle.Color1 = new Color32(0, 128, 255, 255); 
        FreonScheme.CenterCircle.Color2 = new Color32(102, 255, 255, 255); 
        FreonScheme.MiddleCircle.Color1 = new Color32(127, 255, 255, 255); 
        FreonScheme.MiddleCircle.Color2 = new Color32(0, 135, 189, 255);
        FreonScheme.EnclosingCircle.Color1 = new Color32(102, 255, 255, 255);
        FreonScheme.EnclosingCircle.Color2 = new Color32(0, 128, 255, 255);
        FreonScheme.LoopingCircle.Color1 = new Color32(0, 135, 189, 255);
        FreonScheme.LoopingCircle.Color2 = new Color32(102, 255, 255, 255); 
        FreonScheme.CoreVibrating = true;
        ChangeColors(FreonScheme);
    }
    #endregion

    #region Attack Streams
    public void AttackBursts()
    {
        StartCoroutine(attackBursts());
    }
    public IEnumerator attackBursts()
    {
        for (int i = 0; i < 30; i++)
        {
            SpreadOrbPattern(Color.black, new Vector2(2.5f, 2.5f), Random.Range(0f, 360f), 3f, 1, 10f);
            yield return StartCoroutine(Wait(1.25f / 30));
        }
    }

    public void FreonSweeping()
    {
        StartCoroutine(freonSweeping());
    }

    public void FreonBlasting()
    {
        StartCoroutine(freonBlasting());
    }

    public IEnumerator freonBlasting()
    {
        for (int i = 0; i < 60; i++)
        {
            SpreadOrbPattern(Color.black, new Vector2(5f, 5f), Random.Range(0f, 360f), 3f, 1, 10f);
            yield return StartCoroutine(WaitForTime(0.33f));
        }
    }

    public IEnumerator freonSweeping()
    {
        for (int i = 0; i < 27; i++)
        {
            ChoppingBeam(Color.black, i *  20, 1f, 0f, false, 2.5f);
            ChoppingBeam(Color.black, i * -20, 1f, 0f, false, 2.5f);
            yield return StartCoroutine(Wait(0.75f));
        }
    }
    #endregion
}
