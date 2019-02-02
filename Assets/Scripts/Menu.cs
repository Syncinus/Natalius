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
        GameSettings.GameSpeed = float.Parse(GameSpeed.text);
        SceneManager.LoadScene(LevelIndex);
        GameSettings.InvincibleMode = false;
    }

    public void OnStartPressedInvincible(int LevelIndex)
    {
        GameSettings.GameSpeed = float.Parse(GameSpeed.text);
        SceneManager.LoadScene(LevelIndex);
        GameSettings.InvincibleMode = true;
    }
	
}
