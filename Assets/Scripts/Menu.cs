using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Text GameSpeed;
    public Button Start;

    public void OnStartPressed(int LevelIndex)
    {
        GameSettings.InvincibleMode = false;
        GameSettings.GameSpeed = float.Parse(GameSpeed.text);
        SceneManager.LoadScene(LevelIndex);
    }

    public void OnStartPressedInvincible(int LevelIndex)
    {
        GameSettings.InvincibleMode = true;
        GameSettings.GameSpeed = float.Parse(GameSpeed.text);
        SceneManager.LoadScene(LevelIndex);
    }
	
}
