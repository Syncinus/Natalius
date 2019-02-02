using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Text HitText;
    public float Speed = 2.5f;
	public float Health = 5f;
    public float TimesHit = 0f;
    public Transform Core;
    public Transform OrbStorage;
    public Transform Healthbar;
    public bool IsOriginal = true;
	public bool Invincible = false;

	public static float Degrees = 0f;
    [HideInInspector] public Transform Original;

    List<GameObject> MirrorPlayers = new List<GameObject>();
    float DoubleClickRight = 0.0f;
    float CooldownRight = 0.0f;
    float DoubleClickLeft = 0.0f;
    float CooldownLeft = 0.0f;

    float CooldownSwitch = 0.0f;

    public void Awake()
    {
        if (GameSettings.InvincibleMode == true)
        {
            Invincible = true;
        }
    }

    public void SetPlayerCount(PlayerCount Count)
    {
        if (Count == PlayerCount.One)
        {
            DestroyMirrors();
        }

        if (Count == PlayerCount.Two)
        {
            DestroyMirrors();
            Vector3 CurrentRot = transform.rotation.eulerAngles;
            Quaternion MirrorRotation = Quaternion.Euler(new Vector3(0f, 0f, CurrentRot.z + 180f));
            GameObject Mirror = Instantiate(gameObject, -transform.position, MirrorRotation);
            Mirror.GetComponent<PlayerController>().IsOriginal = false;
            Mirror.GetComponent<PlayerController>().Original = this.transform;
            MirrorPlayers.Add(Mirror);
        }
    }

    private void DestroyMirrors()
    {
        foreach (GameObject Player in MirrorPlayers)
        {
            //Destroy(Player);
            Size(Player.transform, new Vector2(0, 0), 1f, true);
            //MirrorPlayers.Remove(Player);
        }
        MirrorPlayers.Clear();
    }

    private void Rotate(float Angle)
    {
         transform.RotateAround(Core.position, new Vector3(0f, 0f, -1f), Angle * GameSettings.GameSpeed);
        if (IsOriginal == true)
        {
            Degrees += Angle * GameSettings.GameSpeed;
        }   
    }

    bool Flash = false;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetMouseButtonDown(2))
        {
            if (Time.time > CooldownSwitch)
            {
                CooldownSwitch = (Time.time + 0.5f) / GameSettings.GameSpeed;
                Rotate(180 / GameSettings.GameSpeed);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < DoubleClickLeft && Time.time > CooldownLeft)
            {
                Rotate((Speed * 10) / GameSettings.GameSpeed);
                CooldownLeft = (Time.time + 0.25f) / GameSettings.GameSpeed;
            }
            DoubleClickLeft = (Time.time + 0.15f) / GameSettings.GameSpeed;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time < DoubleClickRight && Time.time > CooldownRight)
            {
                Rotate((-Speed * 10) / GameSettings.GameSpeed);
                CooldownRight = (Time.time + 0.25f) / GameSettings.GameSpeed;
            }
            DoubleClickRight = (Time.time + 0.15f) / GameSettings.GameSpeed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetMouseButton(0))
        {
            Rotate(Speed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetMouseButton(1))
        {
            Rotate(-Speed);
        }
        if (Invincible == true)
        {
            transform.GetComponent<Renderer>().enabled = Flash;
            Flash = !Flash;
        } else
        {
            transform.GetComponent<Renderer>().enabled = true;
        }
        //transform.Find("Health").transform.localScale = new Vector3(0.7f / 
        if (IsOriginal == true)
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    SetPlayerCount(PlayerCount.One);
            //}
			//if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//	SetPlayerCount (PlayerCount.Two);
			//}
            if (Health <= 0)
            {
                //Size(Original, new Vector2(0, 0), 0.5f, false);
                //Size(this.transform, new Vector2(0, 0), 0.5f, false);
                //yield return new WaitForSeconds(1.0f);
                Scene Level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(Level.name);
            }
        } else
        {
            if (Original.GetComponent<PlayerController>().Health <= 0)
            {
                //Size(Original, new Vector2(0, 0), 0.5f, false);
                //Size(this.transform, new Vector2(0, 0), 0.5f, false);
                //yield return new WaitForSeconds(1.0f);
                Scene Level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(Level.name);
            }
        }
    }

	private void OnTriggerEnter2D(Collider2D Collider)
    {
        StartCoroutine(GetHit(Collider));
    }

    private IEnumerator GetHit(Collider2D Collider)
    {
        if (Invincible == false)
        {
            Invincible = true;
            foreach (GameObject Player in MirrorPlayers)
            {
                if (Player != null)
                {
                    Player.GetComponent<PlayerController>().Invincible = true;
                }
            }

            if (this.IsOriginal == true)
            {
                Invincible = true;
                foreach (GameObject Mirror in MirrorPlayers)
                {
                    if (Mirror != null)
                    {
                        Mirror.GetComponent<PlayerController>().Invincible = true;
                    }                 
                }
                ++TimesHit;
                --Health;
                HitText.text = "Times Hit: " + TimesHit;
                //Destroy(Healthbar.GetChild(0).gameObject);
                if (Healthbar.childCount != 0)
                {
                    foreach (Transform Child in Healthbar)
                    {
                        if (Child.gameObject.activeSelf == true)
                        {
                            Size(Child, new Vector2(0, 0), 0.25f, true);
                            yield return new WaitForSeconds(0.3f);
                            break;
                        }
                    }
                    //Destroy(Healthbar.GetChild(0).gameObject);
                }
                UndoFade();
                if (Health <= 0)
                {
                    //Size(this.transform, new Vector2(0, 0), 0.5f, false);
                    //yield return new WaitForSeconds(1.0f);
                    Scene Level = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(Level.name);
                }
            } else
            {
                Original.GetComponent<PlayerController>().Invincible = true;
                foreach (GameObject Mirror in Original.GetComponent<PlayerController>().MirrorPlayers)
                {
                    Mirror.GetComponent<PlayerController>().Invincible = true;
                }
                --Original.GetComponent<PlayerController>().Health;
                ++Original.GetComponent<PlayerController>().TimesHit;
                HitText.text = "Times Hit: " + Original.GetComponent<PlayerController>().TimesHit;
                if (Healthbar.childCount != 0)
                {
                    Size(Healthbar.GetChild(0), new Vector2(0, 0), 0.25f, true);
                    yield return new WaitForSeconds(0.3f);
                    //Destroy(Healthbar.GetChild(0).gameObject);
                }
                Original.GetComponent<PlayerController>().UndoFade();
                if (Original.GetComponent<PlayerController>().Health <= 0)
                {
                    //Size(Original, new Vector2(0, 0), 0.5f, false);
                    //Size(this.transform, new Vector2(0, 0), 0.5f, false);
                    //yield return new WaitForSeconds(1.0f);
                    Scene Level = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(Level.name);
                }
            }
        }
    }


    public void Size(Transform Object, Vector2 EndSize, float ChangeTime, bool DestroyObject)
    {
        StartCoroutine(ChangeSizeOverTime(Object, EndSize, ChangeTime, DestroyObject));
    }
    private IEnumerator ChangeSizeOverTime(Transform Object, Vector2 EndSize, float ChangeTime, bool DestroyObject)
    {
        Vector2 StartSize = Object.localScale;
        Vector2 CurrentSize = StartSize;
        float Timer = 0.0f;
        if (ChangeTime > 0f)
        {
            do
            {
                CurrentSize = Vector2.Lerp(StartSize, EndSize, Timer / ChangeTime);
                Object.localScale = CurrentSize;
                Timer += Time.deltaTime;
                yield return null;
            } while (Timer < ChangeTime);
        }
        else
        {
            Object.localScale = EndSize;
            yield return null;
        }

        if (DestroyObject == true)
        {
            //Destroy(Object.gameObject);
            Object.gameObject.SetActive(false);
        }
    }

    public void UndoFade()
    {
        StartCoroutine(undoFade());
    }

    private IEnumerator undoFade()
    {
        yield return new WaitForSeconds(1.0f);
        if (IsOriginal == true)
        {
            Invincible = false;
            foreach (GameObject Mirror in MirrorPlayers)
            {
                if (Mirror != null)
                {
                    Mirror.GetComponent<PlayerController>().Invincible = false;
                }   
            }
        } else
        {
            Original.GetComponent<PlayerController>().Invincible = false;
            foreach (GameObject Mirror in Original.GetComponent<PlayerController>().MirrorPlayers)
            {
                Mirror.GetComponent<PlayerController>().Invincible = false;
            }
        }
    }
}

public enum PlayerCount { One, Two }
