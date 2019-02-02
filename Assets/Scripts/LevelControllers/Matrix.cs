using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;

public class Matrix : GameController {
	public void Start () {
		StartCoroutine (LevelExecution ());
	}

	public IEnumerator LevelExecution() {
        yield return new WaitForSeconds(0.1f);
        MusicCheck = true;
        //Stuff that is for testing
        //SetToDefaultScheme();
        //WarningArea(Color.black, -90f, 90f);
        //yield return new WaitForSeconds(1000f);
        //End testing stuff here
        ///*
        #region Startup Phase
        SetToDefaultScheme();
        HitCheckpoint();
        //yield return new WaitForSeconds(3f);
        //PlayerCrusher(Color.red, new Vector2(2.5f, 100f), 0f, 0.25f);
        //yield return new WaitForSeconds(1000f);
        SpreadOrbPattern(Color.black, new Vector2(5f, 5f), 0f, 3f, 18, 10);
        yield return StartCoroutine(WaitForTime (0.3f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 7, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 180f, 3f, 7, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 270f, 3f, 7, 10);
		yield return StartCoroutine(WaitForTime (0.5f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 70f, 3f, 33, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 12, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 45f, 3f, 12, 10);
		yield return StartCoroutine(WaitForTime (0.7f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), GetPlayerDirection(), 3f, 13, 10);
		yield return StartCoroutine(WaitForTime (0.3f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), GetPlayerDirection(), 3f, 13, 10);
		yield return StartCoroutine(WaitForTime (1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), GetPlayerDirection(), 3f, 13, 10);
		yield return StartCoroutine(WaitForTime (0.3f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 0f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 180f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (0.4f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 180f, 3f, 10, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 10, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 270f, 3f, 10, 10);
		yield return StartCoroutine(WaitForTime (1f));
		LaserCutter (Color.black, 0f, 180f, 1f);
		yield return StartCoroutine(WaitForTime (1f));
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 30, 10);
		yield return StartCoroutine(WaitForTime (0.4f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), GetPlayerDirection(), 3f, 5, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), GetPlayerDirection(), 3f, 5, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), GetPlayerDirection(), 3f, 5, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 0f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (0.1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 180f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (1f));
		LaserCutter (Color.black, 90f, 180f, 1f);
		yield return StartCoroutine(WaitForTime (1f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 180f, 3f, 9, 10);
		yield return StartCoroutine(WaitForTime (0.5f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), -45f, 3f, 5, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 0f, 3f, 5, 10);
		yield return StartCoroutine(WaitForTime (0.2f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 45f, 3f, 5, 10);
		yield return StartCoroutine(WaitForTime (0.6f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 90f, 3f, 25, 10);
		yield return StartCoroutine(WaitForTime (0.25f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 45f, 3f, 25, 10);
		yield return StartCoroutine(WaitForTime (0.25f));
		SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), 0f, 3f, 25, 10);
		yield return StartCoroutine(WaitForTime (1.75f));
		Flash(Color.white, 0.25f, 2);
		#endregion

		#region Inferno Phase
		SetToInfernoScheme();
        HitCheckpoint();
        SetPlayerCount(PlayerCount.Two);
		yield return StartCoroutine(WaitForTime (0.5f));
		DoubleBlasts();
		InfernoSlashes();
		yield return StartCoroutine(WaitForTime (12f));
        SetPlayerCount(PlayerCount.One);
		LineCutters();
		SuckOrbs();
		yield return StartCoroutine(WaitForTime (14.5f));
		Flash(Color.white, 0.25f, 2);
		#endregion 
					
		#region Glowy Phase
		SetToGlowyScheme();
        HitCheckpoint();
		yield return StartCoroutine(WaitForTime(0.5f));
		EnergyEmmision();
		EnergyEmmision();
		yield return StartCoroutine(WaitForTime (6f));
		PlayerSmashing();
		yield return StartCoroutine(WaitForTime (7.5f));
		Sweeping();
		yield return StartCoroutine(WaitForTime (7f));
		BoxVacuum();
		yield return StartCoroutine(WaitForTime (8f));
		CuttingBlasting();
		yield return StartCoroutine(WaitForTime (14.35f));
        #endregion


        //SetToDefaultScheme ();
        //ArenaSize(0.5f, 1f, Color.gray, true);
        //yield return StartCoroutine (WaitForTime (85f)); //85

        #region Void Phase
        HitCheckpoint();
        SetToVoidScheme();
		GameObject.Find("Player").GetComponent<PlayerController>().Speed = 3.5f;
		ChoppingBeam (Color.red, 0f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 90f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 180f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 270f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine (WaitForTime (0.25f));
		ChoppingBeam (Color.red, 45f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 135f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 225f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 315f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine (WaitForTime (0.25f));
		ChoppingBeam (Color.red, 0f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 90f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 180f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 270f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine (WaitForTime (0.25f));
		ChoppingBeam (Color.red, 45f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 135f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 225f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 315f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine (WaitForTime (0.25f));
		LaserCutter (Color.red, 0f, 170f, 0.25f);
		LaserCutter (Color.yellow, -0f, -170f, 0.25f);
		yield return StartCoroutine (WaitForTime (0.5f));
		PlayerCrusher (Color.red, new Vector2 (2.5f, 100f), 0f, 0.25f);
		PlayerCrusher (Color.yellow, new Vector2 (2.5f, 100f), 0f, 0.25f);
		yield return StartCoroutine (WaitForTime (1f));
		SpreadOrbPattern(Color.red, new Vector2(5f, 5f), 90f, 4f, 21, 10f);
		yield return StartCoroutine (WaitForTime (0.5f));
		SpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), -90f, 4f, 21, 10f);
		yield return StartCoroutine(WaitForTime(0.35f));
		ChoppingBeam (Color.red, 0f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 145f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, -145f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine(WaitForTime(0.35f));
		ChoppingBeam (Color.yellow, 180f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 55f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, -55f, 0.25f, 0f, false, 2.5f);			
		yield return StartCoroutine(WaitForTime(0.35f));			
		ChoppingBeam (Color.red, 0f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 145f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, -145f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine(WaitForTime(0.5f));
		ChoppingBeam (Color.red, 180f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 55f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, -55f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine(WaitForTime(0.35f));
		ChoppingBeam (Color.yellow, 0f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, 145f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.yellow, -145f, 0.25f, 0f, false, 2.5f);			
		yield return StartCoroutine(WaitForTime(0.35f));			
		ChoppingBeam (Color.red, 180f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, 55f, 0.25f, 0f, false, 2.5f);
		ChoppingBeam (Color.red, -55f, 0.25f, 0f, false, 2.5f);
		yield return StartCoroutine(WaitForTime(0.75f));		
        for (int i = 0; i < 3; i++)
        {
            if (i % 2 == 0)
            {
                DoubleSpreadOrbPattern(Color.red, new Vector2(5f, 5f), 0f, 180f, 7f, 4, 10);
                DoubleSpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), 90f, 270f, 7f, 4, 10);
            }
            else
            {
                DoubleSpreadOrbPattern(Color.red, new Vector2(5f, 5f), 315f, 135f, 7f, 4, 10);
                DoubleSpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), 45f, 225f, 7f, 4, 10);
            }
            yield return StartCoroutine(WaitForTime(0.225f));
        }
        yield return StartCoroutine(WaitForTime(0.5f));
		PlayerCrusher (Color.red, new Vector2 (2.5f, 100f), 0f, 0.25f);
		yield return StartCoroutine(WaitForTime(0.2f));
		PlayerCrusher (Color.yellow, new Vector2 (2.5f, 100f), 0f, 0.25f);
		yield return StartCoroutine(WaitForTime(0.2f));
		PlayerCrusher (Color.red, new Vector2 (2.5f, 100f), 0f, 0.25f);
		yield return StartCoroutine(WaitForTime(0.2f));
		PlayerCrusher (Color.yellow, new Vector2 (2.5f, 100f), 0f, 0.25f);
		yield return StartCoroutine(WaitForTime(0.2f));
		SpreadOrbPattern(Color.red, new Vector2(5f, 5f), 0f, 5f, 15, 10f);
		yield return StartCoroutine(WaitForTime(0.25f));
		SpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), 180f, 5f, 15, 10f);
		yield return StartCoroutine(WaitForTime(0.25f));
		for (int i = 0; i < 18; i++) {
			if (i % 2 == 0) {
				ChoppingBeam (Color.red, i * 10, 0.25f, 0f, false, 2.5f);
			} else if (i % 2 != 0) {
				ChoppingBeam (Color.yellow, i * 10, 0.25f, 0f, false, 2.5f);
			}
			yield return StartCoroutine(WaitForTime(0.05f));
		}
		yield return StartCoroutine(WaitForTime(0.4f));
		for (int i = 0; i < 12; i++) {
			if (i % 2 == 0) {
				InverseSpreadSquarePattern(Color.red, new Vector2(2f, 2f), UnityEngine.Random.Range(0f, 360f), 7f, 1, 0f);
			} else {
				InverseSpreadSquarePattern(Color.yellow, new Vector2(2f, 2f), UnityEngine.Random.Range(0f, 360f), 7f, 1, 0f);
			}
			yield return StartCoroutine(WaitForTime(0.0625f));
		}
		yield return StartCoroutine(WaitForTime(1.25f));
		for (int i = 0; i < 15; i++) {
			if (i % 2 == 0) {
				PlayerCrusher (Color.red, new Vector2 (2.5f, 100f), 0f, 0.25f);
			} else {
				PlayerCrusher (Color.yellow, new Vector2 (2.5f, 100f), 0f, 0.25f);
			}
			yield return StartCoroutine(WaitForTime(0.1f));
		}
		yield return StartCoroutine(WaitForTime(0.8f));
		SpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), 0f, 3f, 29, 10f);
		yield return StartCoroutine(WaitForTime(1.2f));
		SpreadOrbPattern(Color.red, new Vector2(5f, 5f), 90f, 5f, 18, 10f);
		yield return StartCoroutine(WaitForTime(0.25f));
		SpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), -90f, 5f, 18, 10f);
		yield return StartCoroutine(WaitForTime(0.25f));
		SpreadOrbPattern(Color.red, new Vector2(5f, 5f), 0f, 5f, 18, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        PlayerCrusher(Color.yellow, new Vector2(2.5f, 100f), 0f, 0.25f);
        yield return StartCoroutine(WaitForTime(0.75f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 5f, 18, 20f, new Vector2(-43, 23f));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.yellow, new Vector2(5f, 5f), 0f, 5f, 18, 20f, new Vector2(16, 10f));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 5f, 18, 20f, new Vector2(23, -30f));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 5f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.yellow, new Vector2(5f, 5f), 0f, 5f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 5f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.yellow, new Vector2(5f, 5f), 0f, 5f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 5f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.yellow, new Vector2(5f, 5f), 0f, 5f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        LaserCutter(Color.red, 0f, 360f, 2f);
        for (int i = 0; i < 24; i++)
        {
            int Direction = 15 * i;
            if (i % 2 == 0)
            {
                ChoppingBeam(Color.red, Direction, 0.0833333333f, 0f, false, 2);
            }
            else
            {
                ChoppingBeam(Color.yellow, Direction, 0.0833333333f, 0f, false, 2);
            }
            yield return StartCoroutine(WaitForTime(0.08333333333f));
        }
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                DoubleSpreadOrbPattern(Color.red, new Vector2(5f, 5f), 0f, 180f, 7f, 4, 10);
                DoubleSpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), 90f, 270f, 7f, 4, 10);
            } else
            {
                DoubleSpreadOrbPattern(Color.red, new Vector2(5f, 5f), 315f, 135f, 7f, 4, 10);
                DoubleSpreadOrbPattern(Color.yellow, new Vector2(5f, 5f), 45f, 225f, 7f, 4, 10);
            }
            yield return StartCoroutine(WaitForTime(0.25f));
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        ArenaSize(0.5f, 0.25f, 0.375f, false, Color.red, Color.yellow);
        yield return StartCoroutine(WaitForTime(0.4f));
        SetPlayerCount(PlayerCount.Two);
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                SpreadOrbExplosion(Color.red, new Vector2(7.5f, 7.5f), 0f, 7f, 1, 10f, new Vector2(UnityEngine.Random.Range(-30f, 30f), 25));
            } else
            {
                SpreadOrbExplosion(Color.yellow, new Vector2(7.5f, 7.5f), 180f, 7f, 1, 10f, new Vector2(UnityEngine.Random.Range(-30f, 30f), 25));
            }
            yield return StartCoroutine(WaitForTime(0.225f));
        }
        ArenaSize(-5f, 0.25f, 0.375f, false, Color.red, Color.yellow);
        yield return StartCoroutine(WaitForTime(0.5f));
        SetPlayerCount(PlayerCount.One);
        Flash(Color.white, 0.5f, 4);
        #endregion
        
        //SetToDefaultScheme();
        //ArenaSize(0.5f, 1f, Color.gray, true);
        //yield return StartCoroutine(WaitForTime(113.65f)); //85
        
        #region Inferno II
        SetToInfernoScheme();
        HitCheckpoint();
        yield return StartCoroutine(Wait(0.1f));
        Flashes();
        SpreadOrbPattern(Color.black, new Vector2(5, 5), -90f, 7f, 15, 10f, 0.05f);
        SpreadOrbPattern(Color.black, new Vector2(5, 5), -270f, 7f, 15, -10f, 0.05f);
        yield return StartCoroutine(WaitForTime(0.75f));
        SpreadOrbPattern(Color.black, new Vector2(5, 5), 180f, 7f, 5, 10f);
        yield return StartCoroutine(WaitForTime(0.25f));
        DoubleSpreadOrbPattern(Color.black, new Vector2(5, 5), 225f, 135f, 7f, 5, 10f);
        yield return StartCoroutine(WaitForTime(0.65f));
        for (int i = 0; i < 36; i++)
        {
            ChoppingBeam(Color.black, i * 10, 0.25f, 0.25f, false);
            yield return StartCoroutine(WaitForTime(0.02777777777f));
        }
        SpreadOrbPattern(Color.black, new Vector2(5, 5), 0f, 3f, 8, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5, 5), 90f, 5f, 25, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(Color.black, new Vector2(5, 5), 180f, 5f, 25, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        for (int i = 0; i < 10; i++)
        {
            PlayerCrusher(Color.black, new Vector2(2.5f, 100f), 0f, 0.1f);
            yield return StartCoroutine(WaitForTime(0.125f));
        }
        yield return StartCoroutine(WaitForTime(0.25f));
        LaserCutter(Color.black, 0f, 180f, 1f);
        yield return StartCoroutine(WaitForTime(0.4f));
        for (int i = 0; i < 16; i++)
        {
            InverseSpreadOrbPattern(Color.black, new Vector2(7f, 7f), UnityEngine.Random.Range(0f, 360f), 7f, 1, 0f);
            yield return StartCoroutine(Wait(0.125f));
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        for (int i = 0; i < 12; i++)
        {
            SpreadOrbExplosion(Color.black, new Vector2(5f, 5f), 0f, 6f, 12, 30f, new Vector2(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-25f, 25f)));
            yield return StartCoroutine(WaitForTime(0.25f));
        }
        yield return StartCoroutine(WaitForTime(0.25f));
        for (int i = 0; i < 19; i++)
        {
            Flash(Color.white, 0.05f, 0);
            yield return StartCoroutine(WaitForTime(0.05f));
        }
        #endregion
        

        #region Deep
        SetToDeepScheme();
        yield return StartCoroutine(WaitForTime(0.5f));
        WarningRectangle(Color.black, new Vector2(5f, 100f), Vector2.zero, 2, 1.1f, 90f);
        ChoppingBeam(Color.black, GetPlayerDirection() - 45f, 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection(), 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection() + 45f, 0.5f, 0.25f, false, 3f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, GetPlayerDirection() - 45f, 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection(), 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection() + 45f, 0.5f, 0.25f, false, 3f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 90f, 0.5f, 0f, false, 5f, 200f, 0f, 0f);
        CameraVibrator.Shake();
        yield return StartCoroutine(WaitForTime(0.5f));
        WarningRectangle(Color.black, new Vector2(5f, 100f), Vector2.zero, 2, 1.1f, 0f);
        ChoppingBeam(Color.black, GetPlayerDirection() - 45f, 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection(), 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection() + 45f, 0.5f, 0.25f, false, 3f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, GetPlayerDirection() - 45f, 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection(), 0.5f, 0.25f, false, 3f);
        ChoppingBeam(Color.black, GetPlayerDirection() + 45f, 0.5f, 0.25f, false, 3f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.black, 0f, 0.5f, 0f, false, 5f, 200f, 0f, 0f);
        CameraVibrator.Shake();
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 5; i++)
        {
            ChoppingBeam(Color.black, (i * 72) - 20, 0.5f, 0.25f, false, 3f);
            ChoppingBeam(Color.black, (i * 72) + 20, 0.5f, 0.25f, false, 3f);
            if (i < 4)
            {
                WarningRectangle(Color.black, new Vector2(1f, 100f), new Vector2(0f, 0f), 2, 0.525f, ((i + 1) * 72) - 20);
                WarningRectangle(Color.black, new Vector2(1f, 100f), new Vector2(0f, 0f), 2, 0.525f, ((i + 1) * 72) + 20);
            }
            yield return StartCoroutine(WaitForTime(0.25f));
        }
        yield return StartCoroutine(WaitForTime(0.1f));
        ChoppingBeam(Color.black, UnityEngine.Random.Range(0f, 360f), 1.25f, 0.25f, false, 5f);
        CameraVibrator.Shake();
        yield return StartCoroutine(WaitForTime(1.25f));
        ChoppingBeam(Color.black, UnityEngine.Random.Range(0f, 360f), 1.25f, 0.25f, false, 5f);
        CameraVibrator.Shake();
        yield return StartCoroutine(WaitForTime(1f));
        Transform Box1 = Square(Color.black, new Vector2(100f, 100f), 3);
        Box1.position = new Vector2(-175f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        Transform Box2 = Square(Color.black, new Vector2(100f, 100f), 3);
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
            WarningRectangle(Color.black, new Vector2(100f, 0.5f), Location, 3, 0.9f, 0f);
            //Transform NBox = Square(Color.black, new Vector2(100f, 0.5f), 3);
            //NBox.position = new Vector2(0f, UnityEngine.Random.Range(-40f, 40f));
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 20; i++)
        {
            float Position = Positions[i];
            Transform NBox = Square(Color.black, new Vector2(100f, 0.5f), 3);
            Things.Add(NBox.gameObject);
            if (i % 2 == 0)
            {
                NBox.position = new Vector2(-200f, Position);
            } else
            {
                NBox.position = new Vector2(200f, Position);
            }
            Move(NBox, new Vector2(0f, Position), 0.5f);
            yield return StartCoroutine(WaitForTime(0.125f));
        }
        yield return StartCoroutine(WaitForTime(1f));
        foreach (GameObject Obj in Things)
        {
            Size(Obj.transform, new Vector2(0f, 0f), 0.5f, true);
        }
        Things.Clear();
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 96; i++)
        {
            InverseSpreadSquarePattern(Color.black, new Vector2(2.5f, 2.5f), UnityEngine.Random.Range(0f, 360f), 2f + (0.04f * i), 1, 0f);
            yield return StartCoroutine(Wait(0.125f));
        }
        #endregion
        
        

        #region Glowy II 
        SetToGlowyScheme();
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 180f, 2f);
        yield return StartCoroutine(WaitForTime(2f));
        LaserCutter(new Color32(120, 255, 90, 255), -0f, -180f, 2f);
        yield return StartCoroutine(WaitForTime(1.75f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), 90f, 4f, 21, 10f);
        yield return StartCoroutine(WaitForTime(2f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 180f, 2f);
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 180f, 1.5f);
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(new Color32(120, 255, 90, 255), -0f, -180f, 1.25f);
        yield return StartCoroutine(WaitForTime(1f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), 90f, 3f, 21, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), 270f, 3f, 21, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), 180f, 3f, 21, 10f);
        yield return StartCoroutine(WaitForTime(1f));
        PlayerCrusher(new Color32(120, 255, 90, 255), new Vector2(2.5f, 130f), 0f, 2f);
        yield return StartCoroutine(WaitForTime(0.5f));
        PlayerCrusher(new Color32(120, 255, 90, 255), new Vector2(2.5f, 130f), 0f, 1.5f);
        yield return StartCoroutine(WaitForTime(1f));
        PlayerCrusher(new Color32(120, 255, 90, 255), new Vector2(2.5f, 130f), 0f, 1f);
        yield return StartCoroutine(WaitForTime(2f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 315f, 1f, 0f, false, 2);
        ChoppingBeam(new Color32(120, 255, 90, 255), 0f, 1f, 0f, false, 2);
        ChoppingBeam(new Color32(120, 255, 90, 255), 45f, 1f, 0f, false, 2);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 90f, 1f, 0f, false, 2);
        ChoppingBeam(new Color32(120, 255, 90, 255), 135f, 1f, 0f, false, 2);
        ChoppingBeam(new Color32(120, 255, 90, 255), 180f, 1f, 0f, false, 2);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 180f, 1f, 0f, false, 2);
        ChoppingBeam(new Color32(120, 255, 90, 255), 225f, 1f, 0f, false, 2);
        ChoppingBeam(new Color32(120, 255, 90, 255), 270f, 1f, 0f, false, 2);
        yield return StartCoroutine(WaitForTime(1f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), 0f, 6f, 28, 10f);
        WarningRectangle(new Color32(120, 255, 90, 255), new Vector2(5f, 200f), Vector2.zero, 3, 1.1f, 0f);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 0f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(1f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), GetPlayerDirection(), 5f, 5, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), GetPlayerDirection(), 5f, 5, 10f);
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbPattern(new Color32(120, 255, 90, 255), new Vector2(5f, 5f), GetPlayerDirection(), 5f, 5, 10f);
        yield return StartCoroutine(WaitForTime(0.25f));
        PlayerCrusher(new Color32(120, 255, 90, 255), new Vector2(2.5f, 100f), 0f, 0.2f);
        yield return StartCoroutine(WaitForTime(0.25f));
        PlayerCrusher(new Color32(120, 255, 90, 255), new Vector2(2.5f, 100f), 0f, 0.2f);
        yield return StartCoroutine(WaitForTime(0.25f));
        PlayerCrusher(new Color32(120, 255, 90, 255), new Vector2(2.5f, 100f), 0f, 0.2f);
        yield return StartCoroutine(WaitForTime(0.25f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 90f, 1f);
        yield return StartCoroutine(WaitForTime(0.25f));
        LaserCutter(new Color32(120, 255, 90, 255), -0f, -90f, 1f);
        yield return StartCoroutine(WaitForTime(0.25f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 180f, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        SpreadOrbExplosion(new Color32(120, 255, 90, 255), new Vector2(2.5f, 2.5f), 0f, 5f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(-50f, 50f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(new Color32(120, 255, 90, 255), new Vector2(2.5f, 2.5f), 0f, 5f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(-50f, 50f)));
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(new Color32(120, 255, 90, 255), new Vector2(2.5f, 2.5f), 0f, 5f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(-50f, 50f)));
        yield return StartCoroutine(WaitForTime(0.5f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 225f, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 0f, 1f, 0f, false, 1f);
        yield return StartCoroutine(WaitForTime(0.25f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 135f, 1f, 0f, false, 1f);
        yield return StartCoroutine(WaitForTime(0.25f));
        ChoppingBeam(new Color32(120, 255, 90, 255), 225f, 1f, 0f, false, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 135f, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        LaserCutter(new Color32(120, 255, 90, 255), -0f, -135f, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        LaserCutter(new Color32(120, 255, 90, 255), 0f, 135f, 1f);
        yield return StartCoroutine(WaitForTime(1f));
        #endregion
        

        //SetToDefaultScheme();
        //yield return StartCoroutine(WaitForTime(184.65f)); //85

        #region Plasma
        SetToPlasmaScheme();
        OrbBlasting();
        HitCheckpoint();
        yield return StartCoroutine(WaitForTime(0.5f));
        Color32 Coloring = new Color32(181, 51, 137, 225);
        WarningRectangle(Coloring, new Vector2(200f, 5f), Vector2.zero, 2, 0.8f, 45f);
        Transform Thing1 = Square(Coloring, new Vector2(100f, 0f), 3);
        Size(Thing1, new Vector2(100f, 5f), 0.1f, false);
        CameraVibrator.Shake();
        yield return StartCoroutine(WaitForTime(0.25f));
        WarningRectangle(Coloring, new Vector2(200f, 5f), Vector2.zero, 2, 0.6f, 135f);
        Transform Thing2 = Square(Coloring, new Vector2(0f, 100f), 3);
        Size(Thing2, new Vector2(5f, 100f), 0.1f, false);
        CameraVibrator.Shake();
        yield return StartCoroutine(WaitForTime(0.5f));
        CameraVibrator.Shake();
        ChoppingBeam(Coloring, 45f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Coloring, 135f, 1f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(0.5f));
        Orbit(Thing1, 90f, 0.75f);
        Orbit(Thing2, 90f, 0.75f);
        yield return StartCoroutine(WaitForTime(0.75f));
        Orbit(Thing1, 180f, 0.75f);
        Orbit(Thing2, 180f, 0.75f);
        yield return StartCoroutine(WaitForTime(0.75f));
        List<float> Angles = new List<float>();
        List<Transform> Beams = new List<Transform>();
        for (int i = 0; i < 15; i++)
        {
            float Angle = UnityEngine.Random.Range(0f, 360f);
            Angles.Add(Angle);
            WarningRectangle(Coloring, new Vector2(1f, 200f), Vector2.zero, 2, 1f, Angle);
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        foreach (float Angle in Angles)
        {
            Transform Beam = Square(Coloring, new Vector2(1f, 0f), 2);
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
            Beams.Add(Beam);
            Size(Beam, new Vector2(1f, 200f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        foreach (Transform Beam in Beams)
        {
            Size(Beam, new Vector2(1f, 0f), 0.75f, true);
        }
        Beams.Clear();
        Angles.Clear();
        yield return StartCoroutine(WaitForTime(0.75f));
        Size(Thing1, new Vector2(0f, 0f), 0.5f, true);
        Size(Thing2, new Vector2(0f, 0f), 0.5f, true);
        yield return StartCoroutine(WaitForTime(0.75f));
        PlayerCrusher(Coloring, new Vector2(2.5f, 100f), 0f, 0.25f);
        yield return StartCoroutine(WaitForTime(0.25f));
        PlayerCrusher(Coloring, new Vector2(2.5f, 100f), 0f, 0.25f);
        yield return StartCoroutine(WaitForTime(0.25f));
        PlayerCrusher(Coloring, new Vector2(2.5f, 100f), 0f, 0.25f);
        yield return StartCoroutine(WaitForTime(0.75f));
        for (int i = 0; i < 15; i++)
        {
            float Angle = UnityEngine.Random.Range(0f, 360f);
            Angles.Add(Angle);
            WarningRectangle(Coloring, new Vector2(1f, 200f), Vector2.zero, 2, 1f, Angle);
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        CameraVibrator.Shake();
        foreach (float Angle in Angles)
        {
            Transform Beam = Square(Coloring, new Vector2(1f, 0f), 2);
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
            Beams.Add(Beam);
            Size(Beam, new Vector2(1f, 200f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        foreach (Transform Beam in Beams)
        {
            Size(Beam, new Vector2(1f, 0f), 0.75f, true);
        }
        Beams.Clear();
        WarningRectangle(Coloring, new Vector2(200f, 5f), Vector2.zero, 2, 0.8f, 45f);
        WarningRectangle(Coloring, new Vector2(200f, 5f), Vector2.zero, 2, 0.8f, 135f);
        WarningRectangle(Coloring, new Vector2(200f, 5f), Vector2.zero, 2, 0.8f, 0f);
        WarningRectangle(Coloring, new Vector2(200f, 5f), Vector2.zero, 2, 0.8f, 90f);
        yield return StartCoroutine(WaitForTime(0.75f));
        CameraVibrator.Shake();
        ChoppingBeam(Coloring, 45f, 0.75f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Coloring, 135f, 0.75f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Coloring, 0f, 0.75f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Coloring, 90f, 0.75f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(0.75f));
        List<Vector2> Positions2 = new List<Vector2>();
        List<Transform> Orbs = new List<Transform>();
        for (int i = 0; i < 10; i++)
        {
            Vector2 Position = new Vector2(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(-50f, 50f));
            Positions2.Add(Position);
            WarningOrb(Coloring, new Vector2(15f, 15f), Position, 2, 0.75f, 0f);
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        foreach (Vector2 Position in Positions2)
        {
            Transform NewOrb = Orb(Coloring, new Vector2(15f, 15f), 2);
            NewOrb.position = Position;
            Orbs.Add(NewOrb);
        }
        yield return StartCoroutine(WaitForTime(0.75f));
        foreach (Transform Orb in Orbs)
        {
            Size(Orb, new Vector2(30f, 30f), 2.25f, true);
        }
        yield return StartCoroutine(WaitForTime(2.25f));
        Flash(Color.white, 0.25f, 5);
        foreach (Transform Object in ProjectileStorage)
        {
            Destroy(Object.gameObject);
        }
        StopCoroutine(orbBlasting());
        #endregion

        //*/

        //SetToDefaultScheme();
        //yield return StartCoroutine(WaitForTime(199f)); //85

        #region Void II
        SetToVoidScheme();
        List<Transform> Rods = new List<Transform>();
        Transform Rod1 = Square(Color.red, new Vector2(0f, 100f), 3);
        Size(Rod1, new Vector2(5f, 100f), 0.25f, false);
        Rod1.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        Rods.Add(Rod1);
        WarningRectangle(Color.yellow, new Vector2(5f, 100f), Vector2.zero, 3, 0.3f, 90f);
        yield return StartCoroutine(WaitForTime(0.25f));
        Transform Rod2 = Square(Color.yellow, new Vector2(100f, 0f), 3);
        Size(Rod2, new Vector2(100f, 5f), 0.25f, false);
        Rods.Add(Rod2);
        yield return StartCoroutine(WaitForTime(0.5f));
        foreach (Transform Rod in Rods)
        {
            Orbit(Rod, 90f, 0.5f);
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0) {
                ChoppingBeam(Color.red, UnityEngine.Random.Range(0f, 360f), 0.25f, 0f, false, 2f);
            } else
            {
                ChoppingBeam(Color.yellow, UnityEngine.Random.Range(0f, 360f), 0.25f, 0f, false, 2f);
            }
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        yield return StartCoroutine(WaitForTime(0.5f));
        Size(Rod1, new Vector2(0f, 0f), 0.25f, true);
        Size(Rod2, new Vector2(0f, 0f), 0.25f, true);
        yield return StartCoroutine(WaitForTime(0.5f));
        List<float> Angles2 = new List<float>();
        List<Transform> Beams2 = new List<Transform>();
        for (int i = 0; i < 15; i++)
        {
            float Angle = UnityEngine.Random.Range(0f, 360f);
            Angles2.Add(Angle);
            if (i % 2 == 0)
            {
                WarningRectangle(Color.red, new Vector2(1f, 200f), Vector2.zero, 2, 1.2f, Angle);
            } else
            {
                WarningRectangle(Color.yellow, new Vector2(1f, 200f), Vector2.zero, 2, 1.2f, Angle);
            }
        }
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < Angles2.Count; i++)
        {
            Transform Beam = this.transform;
            if (i % 2 == 0)
            {
                Beam = Square(Color.red, new Vector2(1f, 0f), 2);
            } else
            {
                Beam = Square(Color.yellow, new Vector2(1f, 0f), 2);
            }
            Beam.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angles2[i]));
            Beams2.Add(Beam);
            Size(Beam, new Vector2(1f, 300f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(1f));
        foreach (Transform Beam in Beams2)
        {
            //Size(Beam, new Vector2(1f, 0f), 0.75f, true);
            Size(Beam, new Vector2(2f, 300f), 1f, false);
        }
        yield return StartCoroutine(WaitForTime(1f));
        foreach (Transform Beam in Beams2)
        {
            Size(Beam, new Vector2(2f, 0f), 0.75f, true);
        }
        Beams2.Clear();
        Angles2.Clear();
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0) {
                ChoppingBeam(Color.red, GetPlayerDirection(), 0.5f, 0.25f, true, 5f, 200f, 0f, 0f);
            } else
            {
                ChoppingBeam(Color.yellow, GetPlayerDirection(), 0.5f, 0.25f, true, 5f, 200f, 0f, 0f);
            }
            yield return StartCoroutine(WaitForTime(0.25f));
        }
        yield return StartCoroutine(WaitForTime(0.25f));
        Transform Slicer = Square(Color.red, new Vector2(3f, 200f), 3);
        for (int i = 0; i < 40; i++)
        {
            Transform SlicerPiece = Square(Color.yellow, new Vector2(5f, 2.5f), 3);         
            SlicerPiece.position = new Vector2(0f, -100f + i * 10);
            SlicerPiece.SetParent(Slicer);
        }
        Slicer.position = Vector2.zero;
        Orbit(Slicer, 360f, 2.5f);
        yield return StartCoroutine(WaitForTime(2.5f));
        Size(Slicer, new Vector2(3f, 0f), 0.1f, true);
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(Color.yellow, 0f, 0.5f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Color.red, 45f, 0.5f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Color.yellow, 90f, 0.5f, 0f, false, 5f, 200f, 0f, 0f);
        ChoppingBeam(Color.red, 135f, 0.5f, 0f, false, 5f, 200f, 0f, 0f);
        yield return StartCoroutine(WaitForTime(1f));
        for (int i = 0; i < 15; i++)
        {
            if (i % 2 == 0)
            {
                SpreadOrbPattern(Color.red, new Vector2(6f, 6f), UnityEngine.Random.Range(0f, 360f), 4f, 1, 1f);
            } else
            {
                SpreadOrbPattern(Color.yellow, new Vector2(6f, 6f), UnityEngine.Random.Range(0f, 360f), 4f, 1, 1f);
            }
            yield return StartCoroutine(WaitForTime(0.1f));
        }
        yield return StartCoroutine(WaitForTime(0.25f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(-50, 50)));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Color.yellow, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(-50, 50)));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Color.red, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(-50, 50)));
        yield return StartCoroutine(WaitForTime(0.5f));
        SpreadOrbExplosion(Color.yellow, new Vector2(5f, 5f), 0f, 3f, 18, 20f, new Vector2(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(-50, 50)));
        yield return StartCoroutine(WaitForTime(1f));
        ChoppingBeam(Color.red, 45f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 135f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.red, 225f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 315f, 0.25f, 0f, false, 4f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.red, 0f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 90f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.red, 180f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 270f, 0.25f, 0f, false, 4f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.red, 45f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 135f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.red, 225f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 315f, 0.25f, 0f, false, 4f);
        yield return StartCoroutine(WaitForTime(0.5f));
        ChoppingBeam(Color.red, 0f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 90f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.red, 180f, 0.25f, 0f, false, 4f);
        ChoppingBeam(Color.yellow, 270f, 0.25f, 0f, false, 4f);
        yield return StartCoroutine(WaitForTime(0.75f));
        WinGame();
        #endregion
    }

    public void Something(int Tester) {
		Debug.Log ("Test " + Tester.ToString());
	}

	#region Attack Streams

	#region Glowy
	public void EnergyEmmision() {
		StartCoroutine (energyEmmision ());
	}

	public void PlayerSmashing() {
		StartCoroutine (playerSmashing ());
	}

	public void Sweeping() {
		StartCoroutine (sweeping ());
	}

	public void BoxVacuum() {
		StartCoroutine (boxVacuum ());
	}

	public void CuttingBlasting() {
		StartCoroutine (cuttingBlasting ());
	}

	public IEnumerator energyEmmision() {
		for (int i = 0; i < 40; i++) {
			SpreadOrbPattern (new Color32 (120, 255, 90, 255), new Vector2 (5f, 5f), UnityEngine.Random.Range (0f, 360f), 2f, 1, 0f);
			yield return StartCoroutine(Wait (0.125f));
		}
	}

	public IEnumerator playerSmashing() {
		for (int i = 0; i < 26; i++) {
			PlayerCrusher (new Color32 (120, 255, 90, 255), new Vector2 (2.5f, 100f), 0f, 0.2f);
			yield return StartCoroutine (Wait (0.25f));
		}
		yield return null;
	}

	public IEnumerator sweeping() {
		LaserCutter (new Color32 (120, 255, 90, 255), 0f, 180f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), 0f, 90f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), 90f, 180f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), -90f, -180f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), 180f, -90f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), -90f, 0f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), 45f, 75f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), -90f, 180f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), -45f, 0f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
		LaserCutter (new Color32 (120, 255, 90, 255), 0f, 45f, 1.5f);
		yield return StartCoroutine (Wait (0.75f));
	}

	public IEnumerator boxVacuum() {
		for (int i = 0; i < 48; i++) {
			InverseSpreadSquarePattern (new Color32 (120, 255, 90, 255), new Vector2 (1f, 1f), UnityEngine.Random.Range (0f, 360f), 3f, 1, 0f);
			yield return StartCoroutine (Wait (0.125f));
		}
	}

	public IEnumerator cuttingBlasting() {
		for (int i = 0; i < 24; i++) {
			ChoppingBeam(new Color32 (120, 255, 90, 255), UnityEngine.Random.Range(0f, 360f), 0.5f, 0.3f);
			SpreadOrbPattern (new Color32 (120, 255, 90, 255), new Vector2 (3.5f, 3.5f), UnityEngine.Random.Range (0f, 360f), 2f, 1, 0f);
			yield return StartCoroutine(Wait(0.5f));
		}
	}
	#endregion

	#region Inferno
	public void InfernoSlashes() {
		StartCoroutine (infernoSlashes ());
	}

	public void DoubleBlasts() {
		StartCoroutine(doubleBlasts());
	}

	public void LineCutters() {
		StartCoroutine (lineCutters ());
	}

	public void SuckOrbs() {
		StartCoroutine (suckOrbs ());
	}

	public IEnumerator lineCutters() {
		for (int i = 0; i < 24; i++) {
			ChoppingBeam(Color.black, UnityEngine.Random.Range(0f, 360f), 0.5f, 0.3f);
			yield return StartCoroutine(Wait(0.5f));
		}
	}

	public IEnumerator suckOrbs() {
		for (int i = 0; i < 24; i++) {
			InverseSpreadOrbPattern (Color.black, new Vector2 (5f, 5f), UnityEngine.Random.Range(0f, 360f), 3f, 1, 10);
			yield return StartCoroutine(Wait(0.5f));
		}
	}

	public IEnumerator doubleBlasts() {
		for (int i = 0; i < 12; i++) {
			SpreadOrbPattern (Color.black, new Vector2 (5f, 5f), UnityEngine.Random.Range (0f, 360f), 2f, 2, 10);
			yield return StartCoroutine (Wait (0.7f));
		}
	}

	public IEnumerator infernoSlashes() {
        CameraVibrator.Shake();
		DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 0f, 180f, 7f, 9, 10);
		yield return StartCoroutine(Wait (1.75f));
        CameraVibrator.Shake();
        DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), -90f, 90f, 7f, 9, 10);
		Flash(Color.white, 0.1f, 1);
		yield return StartCoroutine(Wait (1.75f));
        CameraVibrator.Shake();
        DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 45f, 225f, 7f, 9, 10);
		Flash(Color.white, 0.1f, 1);
		yield return StartCoroutine(Wait (1.75f));
        CameraVibrator.Shake();
        DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 135f, 315f, 7f, 9, 10);
		Flash(Color.white, 0.1f, 1);
		yield return StartCoroutine(Wait (1.75f));
        CameraVibrator.Shake();
        DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), -45f, 45f, 7f, 4, 10);
		DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), -135f, 135f, 7f, 4, 10);
		Flash(Color.white, 0.1f, 1);
		yield return StartCoroutine(Wait (1.75f));
        CameraVibrator.Shake();
        DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 0f, 180f, 7f, 4, 10);
		DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), -90f, 90f, 7f, 4, 10);
		Flash(Color.white, 0.1f, 1);
		yield return StartCoroutine(Wait (1.75f));
        CameraVibrator.Shake();
        DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), -35f, -145f, 7f, 8, 10);
		DoubleSpreadOrbPattern(Color.black, new Vector2(5f, 5f), 35f, 145f, 7f, 8, 10);
		Flash(Color.white, 0.1f, 1);
		yield return StartCoroutine(Wait (2f));
		ScreenCover.gameObject.SetActive (false);
	}
    #endregion

    #region Void

    #endregion

    #region Inferno II
    public void Flashes()
    {
        StartCoroutine(flashes());
    }

    public IEnumerator flashes()
    {
        for (int i = 0; i < 13; i++)
        {
            Flash(Color.white, 0.1f, 0);
            yield return StartCoroutine(Wait(1f));
        }
    }
    #endregion

    #region Plasma
    public void OrbBlasting()
    {
        StartCoroutine(orbBlasting());
    }
    public IEnumerator orbBlasting()
    {
        for (int i = 0; i < 54; i++)
        {
            SpreadOrbPattern(new Color32(181, 51, 137, 225), new Vector2(2.5f, 2.5f), UnityEngine.Random.Range(0f, 360f), 1f, 1, 1f);
            yield return StartCoroutine(Wait(0.25f));
        }
    }
    #endregion

    #endregion

    #region Color Schemes
    public void SetToDefaultScheme() {
		ColorScheme DefaultScheme = new ColorScheme();
		DefaultScheme.Name = "Default Scheme";
		DefaultScheme.BackgroundColor = Color.black;
		DefaultScheme.PlayerColor = Color.black;
		DefaultScheme.LineColor = Color.black;
		DefaultScheme.CoreColor = Color.black;
		DefaultScheme.LargeRingColor = Color.black;
		DefaultScheme.SmallRingColor = Color.black;
		DefaultScheme.CenterCircle.Color1 = new Color32 (80, 120, 80, 255);
		DefaultScheme.CenterCircle.Color2 = new Color32 (40, 50, 35, 255);
		DefaultScheme.MiddleCircle.Color1 = new Color32 (55, 80, 55, 255);
		DefaultScheme.MiddleCircle.Color2 = new Color32 (65, 50, 50, 255);
		DefaultScheme.EnclosingCircle.Color1 = new Color32 (90, 50, 50, 255);
		DefaultScheme.EnclosingCircle.Color2 = new Color32 (80, 110, 80, 255);
		DefaultScheme.LoopingCircle.Color1 = new Color32 (70, 90, 70, 255);
		DefaultScheme.LoopingCircle.Color2 = new Color32 (50, 80, 50, 255);
        DefaultScheme.CoreVibrating = false;
        ChangeColors(DefaultScheme);
	}

	public void SetToInfernoScheme() {
		ColorScheme InfernoScheme = new ColorScheme();
		InfernoScheme.Name = "Inferno Scheme";
		InfernoScheme.BackgroundColor = Color.red;
		InfernoScheme.PlayerColor = Color.black;
		InfernoScheme.LineColor = Color.black;
		InfernoScheme.CoreColor = Color.black;
		InfernoScheme.LargeRingColor = Color.black;
		InfernoScheme.SmallRingColor = Color.black;
		InfernoScheme.CenterCircle.Color1 = new Color32 (255, 255, 0, 255);
		InfernoScheme.CenterCircle.Color2 = new Color32 (0, 255, 0, 255);
		InfernoScheme.MiddleCircle.Color1 = new Color32 (255, 0, 0, 255);
		InfernoScheme.MiddleCircle.Color2 = new Color32 (255, 255, 0, 255);
		InfernoScheme.EnclosingCircle.Color1 = new Color32 (255, 0, 200, 255);
		InfernoScheme.EnclosingCircle.Color2 = new Color32 (255, 135, 0, 255);
		InfernoScheme.LoopingCircle.Color1 = new Color32 (255, 255, 0, 255);
		InfernoScheme.LoopingCircle.Color2 = new Color32 (255, 0, 0, 255);
        InfernoScheme.CoreVibrating = true;
		ChangeColors (InfernoScheme);
	}

	public void SetToGlowyScheme() {
		ColorScheme GlowyScheme = new ColorScheme();
		GlowyScheme.Name = "Glowy Scheme";
		GlowyScheme.BackgroundColor = Color.black;
		GlowyScheme.PlayerColor = new Color32(120, 255, 90, 255);
		GlowyScheme.LineColor = Color.black;
		GlowyScheme.CoreColor = new Color32(120, 255, 90, 255);
		GlowyScheme.LargeRingColor = new Color32(120, 255, 90, 255);
		GlowyScheme.SmallRingColor = new Color32(120, 255, 90, 255);
		GlowyScheme.CenterCircle.Color1 = new Color32 (180, 50, 50, 255);
		GlowyScheme.CenterCircle.Color2 = new Color32 (40, 100, 40, 255);
		GlowyScheme.MiddleCircle.Color1 = new Color32 (20, 230, 30, 255);
		GlowyScheme.MiddleCircle.Color2 = new Color32 (30, 150, 40, 255);
		GlowyScheme.EnclosingCircle.Color1 = new Color32 (160, 70, 70, 255);
		GlowyScheme.EnclosingCircle.Color2 = new Color32 (0, 180, 20, 255);
		GlowyScheme.LoopingCircle.Color1 = new Color32 (0, 150, 0, 255);
		GlowyScheme.LoopingCircle.Color2 = new Color32 (40, 200, 40, 255);
        GlowyScheme.CoreVibrating = false;
        ChangeColors(GlowyScheme);
	}

	public void SetToVoidScheme() {
		ColorScheme VoidScheme = new ColorScheme();
		VoidScheme.Name = "Void Scheme";
		VoidScheme.BackgroundColor = Color.black;
		VoidScheme.PlayerColor = Color.black;
		VoidScheme.LineColor = Color.black;
		VoidScheme.CoreColor = Color.black;
		VoidScheme.LargeRingColor = Color.black;
		VoidScheme.SmallRingColor = Color.black;
		VoidScheme.CenterCircle.Color1 = Color.red;
		VoidScheme.CenterCircle.Color2 = Color.black;
		VoidScheme.MiddleCircle.Color1 = Color.yellow;
		VoidScheme.MiddleCircle.Color2 = Color.black;
		VoidScheme.EnclosingCircle.Color1 = Color.red;
		VoidScheme.EnclosingCircle.Color2 = Color.black;
		VoidScheme.LoopingCircle.Color1 = Color.red;
		VoidScheme.LoopingCircle.Color2 = Color.yellow;
        VoidScheme.CoreVibrating = true;
        ChangeColors(VoidScheme);
	}

    public void SetToDeepScheme()
    {
        //ColorScheme DeepScheme = new ColorScheme();
        ColorScheme DeepScheme = new ColorScheme();
        DeepScheme.Name = "Deep Scheme";
        DeepScheme.BackgroundColor = new Color32(15, 15, 15, 255);
        DeepScheme.PlayerColor = Color.black;
        DeepScheme.LineColor = Color.black;
        DeepScheme.CoreColor = Color.black;
        DeepScheme.LargeRingColor = Color.black;
        DeepScheme.SmallRingColor = Color.black;
        DeepScheme.CenterCircle.Color1 = new Color32(130, 0, 65, 255);
        DeepScheme.CenterCircle.Color2 = new Color32(130, 0, 190, 255);
        DeepScheme.MiddleCircle.Color1 = new Color32(25, 0, 190, 255);
        DeepScheme.MiddleCircle.Color2 = new Color32(130, 0, 65, 255);
        DeepScheme.EnclosingCircle.Color1 = new Color32(130, 0, 190, 255);
        DeepScheme.EnclosingCircle.Color2 = new Color32(25, 0, 190, 255);
        DeepScheme.LoopingCircle.Color1 = new Color32(25, 0, 190, 255);
        DeepScheme.LoopingCircle.Color2 = new Color32(130, 0, 65, 255);
        DeepScheme.CoreVibrating = false;
        ChangeColors(DeepScheme);
    }

    public void SetToPlasmaScheme()
    {
        ColorScheme PlasmaScheme = new ColorScheme();
        PlasmaScheme.Name = "Plasma Scheme";
        PlasmaScheme.BackgroundColor = Color.black;
        PlasmaScheme.PlayerColor = new Color32(181, 51, 137, 225);
        PlasmaScheme.LineColor = new Color32(181, 51, 137, 225);
        PlasmaScheme.CoreColor = new Color32(181, 51, 137, 225);
        PlasmaScheme.LargeRingColor = new Color32(181, 51, 137, 225);
        PlasmaScheme.SmallRingColor = new Color32(181, 51, 137, 225);
        PlasmaScheme.CenterCircle.Color1 = Color.clear;
        PlasmaScheme.CenterCircle.Color2 = Color.clear;
        PlasmaScheme.MiddleCircle.Color1 = Color.clear;
        PlasmaScheme.MiddleCircle.Color2 = Color.clear;
        PlasmaScheme.EnclosingCircle.Color1 = Color.clear;
        PlasmaScheme.EnclosingCircle.Color2 = Color.clear;
        PlasmaScheme.LoopingCircle.Color1 = Color.clear;
        PlasmaScheme.LoopingCircle.Color2 = Color.clear;
        PlasmaScheme.CoreVibrating = false;
        ChangeColors(PlasmaScheme);
    }
	#endregion
}
