 using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Unity.VectorGraphics;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System;
using System.Text;
using Lines;

public class Instance
{
    public Mesh mesh;
    public Unity.VectorGraphics.Shape path;
    public int id;
}
public class GameController : MonoBehaviour {
	#region Variables
	public float StartTime = 0.0f;
	public float CurrentTime;

	internal Transform ScreenCover;
	internal Transform BaseOrb;
	internal Transform BaseSquare;
	internal Transform ProjectileStorage;
	internal Transform LineStorage;
	internal Transform Rings;
	internal Transform Circles;
    internal Transform Healthbar;
    internal bool MusicCheck = false;
    internal GameObject YouWon;
    internal TextMeshProUGUI RankText;
    internal Vibrate CameraVibrator;

    private Unity.VectorGraphics.Scene scene;
    private List<Instance> instances = new List<Instance>();
    private VectorUtils.TessellationOptions options;
	#endregion

	#region Game Functions
	public static GameController Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of OrbShooter has been detected!");
            return;
        }
        CurrentTime = StartTime;
        Instance = this;
        options = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.05f,
            MaxTanAngleDeviation = 0.05f,
            SamplingStepSize = 0.01f
        };

        // First set the name of this object
        transform.name = "Core";
        // Setup the camera
        Transform View = Camera.main.transform;
        Camera.main.orthographic = false;
        Camera.main.renderingPath = RenderingPath.DeferredShading;
        Camera.main.fieldOfView = 160f;
        CameraVibrator = View.gameObject.AddComponent<Vibrate>();
        CameraVibrator.shake_decay = 0.004f;
        CameraVibrator.shake_intensity = 0.05f;
        // Now we create an object called arena to hold everything
        GameObject ArenaObject = new GameObject();
        Transform Arena = ArenaObject.transform;
        Arena.name = "Arena";
        // Next we set this as a child of arena and create visuals for our object
        transform.SetParent(Arena);
        GameObject VisualsObject = new GameObject();
        VisualsObject.AddComponent<SpriteRenderer>();
        Transform Visuals = VisualsObject.transform;
        Visuals.name = "Visuals";
        Visuals.SetParent(transform);
        Visuals.localScale = new Vector3(7.5f, 7.5f, 1f);
        Visuals.GetComponent<SpriteRenderer>().sortingOrder = 4;
        Visuals.GetComponent<SpriteRenderer>().sprite = Resources.Load<Transform>("Art/Customizable/Orb").GetComponent<SpriteRenderer>().sprite;
        Visuals.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Art/Materials/NewColor");
        Vibrate Vibrator = Visuals.gameObject.AddComponent<Vibrate>();
        Vibrator.shake_decay = 0f;
        Vibrator.shake_intensity = 0.3f;
        // Next we create our storages
        GameObject Storages = new GameObject();
        Storages.transform.name = "Storages";
        Storages.transform.SetParent(Arena);
        GameObject ProjectileStorageObject = new GameObject();
        ProjectileStorage = ProjectileStorageObject.transform;
        ProjectileStorage.SetParent(Storages.transform);
        ProjectileStorage.name = "ProjectileStorage";
        GameObject LineStorageObject = new GameObject();
        LineStorage = LineStorageObject.transform;
        LineStorage.SetParent(Storages.transform);
        LineGenerator Lines = LineStorage.gameObject.AddComponent<LineGenerator>();
        Lines.Core = transform;
        Lines.Line = Resources.Load<Transform>("Art/Customizable/Line");
        Lines.EffectStorage = LineStorage;
        Lines.Interval = 10;
        Lines.LineAngle = 1;
        // Now we setup the circle objects
        GameObject CirclesObject = new GameObject();
        Circles = CirclesObject.transform;
        Circles.transform.name = "Circles";
        Circles.SetParent(Arena);
        GameObject LoopingCircle = new GameObject();
        LoopingCircle.transform.name = "LoopingCircle";
        LoopingCircle.transform.SetParent(Circles);
        LoopingCircle.transform.localScale = new Vector3(102.1f, 102.1f, 1f);
        Looper LoopingCircleRotate = LoopingCircle.AddComponent<Looper>();
        LoopingCircleRotate.Angle = 5f;
        LoopingCircleRotate.Core = transform;
        Transform LoopingCircleColor1 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/LoopingRingC1"), LoopingCircle.transform);
        LoopingCircleColor1.name = "Color1";
        LoopingCircleColor1.GetComponent<SpriteRenderer>().sortingOrder = -1;
        Transform LoopingCircleColor2 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/LoopingRingC2"), LoopingCircle.transform);
        LoopingCircleColor2.name = "Color2";
        LoopingCircleColor2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GameObject EnclosingCircle = new GameObject();
        EnclosingCircle.transform.name = "EnclosingCircle";
        EnclosingCircle.transform.SetParent(Circles);
        EnclosingCircle.transform.localScale = new Vector3(76.10001f, 76.10001f, 1f);
        Looper EnclosingCircleRotate = EnclosingCircle.AddComponent<Looper>();
        EnclosingCircleRotate.Core = transform;
        EnclosingCircleRotate.Angle = 5f;
        Transform EnclosingCircleColor1 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/EnclosingRingC1"), EnclosingCircle.transform);
        EnclosingCircleColor1.name = "Color1";
        EnclosingCircleColor1.GetComponent<SpriteRenderer>().sortingOrder = -1;
        Transform EnclosingCircleColor2 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/EnclosingRingC2"), EnclosingCircle.transform);
        EnclosingCircleColor2.name = "Color2";
        EnclosingCircleColor2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GameObject MiddleCircle = new GameObject();
        MiddleCircle.transform.name = "MiddleCircle";
        MiddleCircle.transform.SetParent(Circles);
        MiddleCircle.transform.localScale = new Vector3(76.6f, 76.6f, 1f);
        Looper MiddleCircleRotate = MiddleCircle.AddComponent<Looper>();
        MiddleCircleRotate.Core = transform;
        MiddleCircleRotate.Angle = 5f;
        Transform MiddleCircleColor1 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/MiddleRingC1"), MiddleCircle.transform);
        MiddleCircleColor1.name = "Color1";
        MiddleCircleColor1.GetComponent<SpriteRenderer>().sortingOrder = -1;
        Transform MiddleCircleColor2 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/MiddleRingC2"), MiddleCircle.transform);
        MiddleCircleColor2.name = "Color2";
        MiddleCircleColor2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GameObject CenterCircle = new GameObject();
        CenterCircle.transform.name = "CenterCircle";
        CenterCircle.transform.SetParent(Circles);
        CenterCircle.transform.localScale = new Vector3(77.7f, 77.7f, 1f);
        Looper CenterCircleRotate = CenterCircle.AddComponent<Looper>();
        CenterCircleRotate.Core = transform;
        CenterCircleRotate.Angle = 5f;
        Transform CenterCircleColor1 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/CenterRingC1"), CenterCircle.transform);
        CenterCircleColor1.name = "Color1";
        CenterCircleColor1.GetComponent<SpriteRenderer>().sortingOrder = -1;
        Transform CenterCircleColor2 = Instantiate(Resources.Load<Transform>("Art/Customizable/Circles/CenterRingC2"), CenterCircle.transform);
        CenterCircleColor2.name = "Color2";
        CenterCircleColor2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        // Next we create the ring objects
        GameObject RingsObject = new GameObject();
        Rings = RingsObject.transform;
        Rings.name = "Rings";
        Rings.SetParent(Arena);
        Transform SmallRing = Instantiate(Resources.Load<Transform>("Art/Customizable/Rings/SmallRing"), Rings);
        SmallRing.name = "SmallRing";
        SmallRing.GetComponent<SpriteRenderer>().sortingOrder = 1;
        SmallRing.localScale = new Vector3(99.9f, 99.9f, 1f);
        Transform LargeRing = Instantiate(Resources.Load<Transform>("Art/Customizable/Rings/LargeRing"), Rings);
        LargeRing.name = "LargeRing";
        LargeRing.GetComponent<SpriteRenderer>().sortingOrder = 1;
        LargeRing.localScale = new Vector3(100f, 100f, 1f);
        // Now we set the base square and orb
        BaseSquare = Resources.Load<Transform>("Art/Customizable/Square");
        BaseOrb = Resources.Load<Transform>("Art/Customizable/Orb");
        // Now we set the cover object
        GameObject Cover = new GameObject();
        ScreenCover = Cover.transform;
        ScreenCover.SetParent(Arena);
        ScreenCover.localScale = new Vector3(1000f, 1000f, 1f);
        SpriteRenderer CoverRenderer = Cover.AddComponent<SpriteRenderer>();
        CoverRenderer.sortingOrder = 3;
        CoverRenderer.sprite = Resources.Load<Sprite>("Art/Cover");
        Cover.SetActive(false);
        // After that we set up the dotted line system
        GameObject DottedLineSystem = new GameObject();
        DottedLineSystem.transform.SetParent(Arena);
        DottedLine DotLine = DottedLineSystem.AddComponent<DottedLine>();
        DotLine.Dot = BaseOrb.GetComponent<SpriteRenderer>().sprite;
        DotLine.Mat = Resources.Load<Material>("Art/Materials/Dashed");
        DotLine.Size = 1;
        DotLine.Delta = 2;
        DotLine.Color = Color.clear;
        // Now we have to set up our healthbar
        GameObject HealthbarObject = new GameObject();
        Healthbar = HealthbarObject.transform;
        Healthbar.name = "Healthbar";
        Healthbar.position = new Vector3(-10f, 0f, 0f);
        Transform HealthPoint = Resources.Load<Transform>("Art/Customizable/Orb");
        for (int i = 0; i < 5; ++i)
        {
            Transform NewHealthPoint = Instantiate(HealthPoint, Healthbar);
            NewHealthPoint.position = new Vector3(40f + (7.5f * i), 50f, 0f);
            NewHealthPoint.localScale = new Vector3(5f, 5f, 1f);
            NewHealthPoint.GetComponent<SpriteRenderer>().sortingOrder = 5;
            NewHealthPoint.GetComponent<SpriteRenderer>().color = Color.white;
            NewHealthPoint.name = "Point";
        }
        // Now we have to generate the canvas
        GameObject CanvasObject = new GameObject("Canvas", typeof(RectTransform));
        RectTransform CanvasTransform = CanvasObject.GetComponent<RectTransform>();
        CanvasTransform.localPosition = new Vector3(512f, 384f, 0f);
        CanvasTransform.localScale = new Vector3(1f, 1f, 1f);
        CanvasTransform.anchoredPosition = new Vector2(512f, 384f);
        CanvasTransform.sizeDelta = new Vector2(1024f, 768f);
        CanvasTransform.pivot = new Vector2(0.5f, 0.5f);
        Canvas TheCanvas = CanvasTransform.gameObject.AddComponent<Canvas>();
        CanvasScaler TheCanvasScaler = CanvasTransform.gameObject.AddComponent<CanvasScaler>();
        GraphicRaycaster TheCanvasRaycaster = CanvasTransform.gameObject.AddComponent<GraphicRaycaster>();
        // Next we create the ui elements
        GameObject HitText = new GameObject("HitText", typeof(RectTransform));
        HitText.transform.SetParent(TheCanvas.transform);
        HitText.GetComponent<RectTransform>().localPosition = new Vector3(400f, 290f, 0f);
        HitText.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        HitText.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        HitText.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        HitText.GetComponent<RectTransform>().anchoredPosition = new Vector2(400f, 290f);
        HitText.GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 30f);
        HitText.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        Text TimesHit = HitText.AddComponent<Text>();
        TimesHit.text = "Times Hit: 0";
        TimesHit.alignment = TextAnchor.MiddleCenter;

        Transform CompletionDisplay = Instantiate(Resources.Load<Transform>("CompletionDisplay"));
        CompletionDisplay.transform.SetParent(TheCanvas.transform);
        YouWon = CompletionDisplay.gameObject;

        // Finally we set up our player
        Transform PlayerTrans = Resources.Load<Transform>("Art/Customizable/Player");
        Transform PlayerObject = Instantiate(PlayerTrans, new Vector3(0f, -43.6f, 0f), Quaternion.identity);
        PlayerObject.name = "Player";
        PlayerObject.localScale = new Vector3(5f, 5f, 1f);
        PlayerObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        Rigidbody2D PlayerRigid = PlayerObject.gameObject.AddComponent<Rigidbody2D>();
        PlayerRigid.bodyType = RigidbodyType2D.Kinematic;
        PlayerRigid.simulated = true;
        PlayerRigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        BoxCollider2D PlayerCollider = PlayerObject.gameObject.AddComponent<BoxCollider2D>();
        PlayerCollider.isTrigger = true;
        PlayerCollider.size = new Vector2(0.2f, 1.063909f);
        PlayerController Controller = PlayerObject.gameObject.AddComponent<PlayerController>();
        Controller.HitText = TimesHit;
        Controller.Healthbar = Healthbar;
        Controller.Core = transform;
        Controller.OrbStorage = ProjectileStorage;
        Controller.Speed = 2.5f;
        Controller.Health = 5f;
        Controller.TimesHit = 0;
        Controller.IsOriginal = true;
    }

	public void FixedUpdate() {
		if (CurrentTime < 0) {
			CurrentTime = 0;
		}
	}

    public void UpdateVectors()
    {
        List<Shape> shapes = new List<Shape>();
        foreach (Instance Inst in instances)
        {
            shapes.Add(Inst.path);
        }
        scene = new Unity.VectorGraphics.Scene()
        {
            Root = new SceneNode() { Shapes = shapes }
        };
        var geoms = VectorUtils.TessellateScene(scene, options);
        foreach (Instance Inst in instances)
        {
            VectorUtils.FillMesh(Inst.mesh, geoms, 1.0f);
        }
    }
	#endregion

	#region Objects
	public Transform Orb(Color Coloring, Vector2 Size, int Order, bool Damage = true) {
        
		Transform NewOrb = Instantiate (BaseOrb, new Vector2(0, 0), Quaternion.identity, ProjectileStorage);
		NewOrb.GetComponent<SpriteRenderer> ().color = Coloring;
		NewOrb.GetComponent<SpriteRenderer> ().sortingOrder = Order;
		NewOrb.localScale = Size;
        if (Damage == true)
        {
            BoxCollider2D BoxCol = NewOrb.gameObject.AddComponent<BoxCollider2D>();
            BoxCol.isTrigger = true;
            Rigidbody2D Rigid = NewOrb.gameObject.AddComponent<Rigidbody2D>();
            Rigid.isKinematic = true;
            Rigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
		return NewOrb;
        /*
        GameObject NewOrb = new GameObject();
        MeshRenderer Rend = NewOrb.AddComponent<MeshRenderer>();
        MeshFilter Filter = NewOrb.AddComponent<MeshFilter>();
        Instance Inst = new Instance();
        Inst.path = new Shape();
        VectorUtils.MakeEllipseShape(Inst.path, Vector2.zero, Size.x / 2, Size.y / 2);
        Inst.path.Fill = new SolidFill() { Color = Coloring };
        Inst.path.PathProps = new PathProperties();
        Inst.mesh = new Mesh();
        Filter.mesh = Inst.mesh;
        Rend.material = new Material(Shader.Find("Sprites/Default"));
        instances.Add(Inst);
        UpdateVectors();
        return NewOrb.transform;
        */
	}

	public Transform Square(Color Coloring, Vector2 Size, int Order, bool Damage = true) {
		Transform NewSquare = Instantiate (BaseSquare, new Vector2 (0, 0), Quaternion.identity, ProjectileStorage);
		NewSquare.GetComponent<SpriteRenderer> ().color = Coloring;
		NewSquare.GetComponent<SpriteRenderer> ().sortingOrder = Order;
		NewSquare.localScale = Size;
        if (Damage == true)
        {
            BoxCollider2D BoxCol = NewSquare.gameObject.AddComponent<BoxCollider2D>();
            BoxCol.isTrigger = true;
            Rigidbody2D Rigid = NewSquare.gameObject.AddComponent<Rigidbody2D>();
            Rigid.isKinematic = true;
            Rigid.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        return NewSquare;
	}
    #endregion

    #region Functions
    public void WarningArea(Color Coloring, float StartAngle, float EndAngle, float Lifetime, bool LerpRemove = false, bool LerpCreate = false)
    {
        StartCoroutine(ConeWarningArea(Coloring, StartAngle, EndAngle, Lifetime, LerpRemove, LerpCreate));
    }

    public void WinGame()
    {
        YouWon.SetActive(true);
        float Hits = Mathf.Floor(GameObject.Find("Player").GetComponent<PlayerController>().TimesHit / GameSettings.GameSpeed);
        this.GetComponent<SongRunner>().Source.volume = 0.25f;
        GameObject.Find("Player").GetComponent<PlayerController>().Speed = 0;
        if (Hits == 0 && GameSettings.GameSpeed >= 1)
        {
            RankText.text = "S";
            RankText.color = Color.red;
        }
        else if (Hits <= 2)
        {
            RankText.text = "A";
            RankText.color = Color.green;
        }
        else if (Hits <= 5)
        {
            RankText.text = "B";
            RankText.color = Color.magenta;
        }
        else if (Hits <= 7)
        {
            RankText.text = "C";
            RankText.color = Color.blue;
        }
        else if (Hits <= 12)
        {
            RankText.text = "D";
            RankText.color = Color.grey;
        }
        else if (Hits >= 13)
        {
            RankText.text = "F";
            RankText.color = Color.black;
        }
    }
	public void ChangeColors(ColorScheme Scheme) {
		Rings.transform.Find ("LargeRing").GetComponent<SpriteRenderer> ().color = Scheme.LargeRingColor;
		Rings.transform.Find ("SmallRing").GetComponent<SpriteRenderer> ().color = Scheme.SmallRingColor;

		foreach (Transform Circle in Circles) {
			if (Circle.name == "CenterCircle") {
				SetCircleColors (Scheme.CenterCircle.Color1, Scheme.CenterCircle.Color2, Circle);
			}
			if (Circle.name == "MiddleCircle") {
				SetCircleColors (Scheme.MiddleCircle.Color1, Scheme.MiddleCircle.Color2, Circle);
			}
			if (Circle.name == "EnclosingCircle") {
				SetCircleColors (Scheme.EnclosingCircle.Color1, Scheme.EnclosingCircle.Color2, Circle);
			}
			if (Circle.name == "LoopingCircle") {
				SetCircleColors (Scheme.LoopingCircle.Color1, Scheme.LoopingCircle.Color2, Circle);
			}
		}

		foreach (Transform Line in LineStorage) {
			Line.GetComponent<SpriteRenderer> ().color = Scheme.LineColor;
		}

		transform.Find("Visuals").GetComponent<SpriteRenderer>().color = Scheme.CoreColor;
		Camera.main.backgroundColor = Scheme.BackgroundColor;
		GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Scheme.PlayerColor;
        if (Scheme.CoreVibrating == true)
        {
            transform.Find("Visuals").GetComponent<Vibrate>().enabled = true;
            transform.Find("Visuals").GetComponent<Vibrate>().Shake();
        } else
        {
            transform.Find("Visuals").GetComponent<Vibrate>().enabled = false;
        }
    }

    public void WarningRectangle(Color32 Coloring, Vector2 Scale, Vector2 Position, int Order, float Lifetime, float Angle)
    {
        StartCoroutine(WarningRectangleShape(Coloring, Scale, Position, Order, Lifetime, Angle));
    }

    public void WarningOrb(Color32 Coloring, Vector2 Scale, Vector2 Position, int Order, float Lifetime, float Angle)
    {
        StartCoroutine(WarningOrbShape(Coloring, Scale, Position, Order, Lifetime, Angle));
    }

    public void OrbPattern(FormationPattern Pattern, Color32 Coloring, Vector2 Size, float Direction, float Speed) {
		foreach (float Angle in FormationPatternDirection(Direction, Pattern)) {
			Transform NewOrb = Orb (Coloring, Size, 2);
			Launch (NewOrb, Speed, Angle);
		}
	}

    public void OrbExplosion(FormationPattern Pattern, Color32 Coloring, Vector2 Size, float Direction, float Speed, Vector2 Position)
    {
        foreach (float Angle in FormationPatternDirection(Direction, Pattern))
        {
            Transform NewOrb = Orb(Coloring, Size, 2);
            NewOrb.position = Position;
            Launch(NewOrb, Speed, Angle);
        }
    }

	public void InverseOrbPattern(FormationPattern Pattern, Color32 Coloring, Vector2 Size, float Direction, float Speed) {
		foreach (float Angle in FormationPatternDirection(Direction, Pattern)) {
			Transform NewOrb = Orb (Coloring, Size, 2);
			NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));	
			NewOrb.Translate (Vector3.up * 50f, Space.Self);
			Launch (NewOrb, -Speed, Direction);
		}
	}

    public void InverseOrbExplosion(FormationPattern Pattern, Color32 Coloring, Vector2 Size, float Direction, float Speed, Vector2 Position)
    {
        foreach (float Angle in FormationPatternDirection(Direction, Pattern))
        {
            Transform NewOrb = Orb(Coloring, Size, 2);
            NewOrb.position = Position;
            NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));
            NewOrb.Translate(Vector3.up * 45f, Space.Self);
            Launch(NewOrb, -Speed, Angle);
        }
    }

    public void LaserCutter(Color32 Coloring, float StartDirection, float EndDirection, float OrbitTime, bool BerpInterpolation = false) {
		Transform Cutter = Square (Coloring, new Vector2 (1f, 100f), 2);
		Move (Cutter, new Vector2 (0f, 130f), 0f);
		Cutter.RotateAround (transform.position, new Vector3 (0f, 0f, -1f), StartDirection);
		Orbit (Cutter, EndDirection, Mathf.Clamp(OrbitTime - CurrentTime, 0f, 9001f), BerpInterpolation);
		Size (Cutter, new Vector2 (0f, 100f), Mathf.Clamp((OrbitTime) - CurrentTime, 0f, 9001f), true);
	}

	public void ChoppingBeam(Color32 Coloring, float Direction, float ActiveTime, float WarningTime, bool Lines = true, float SizeX = 1f, float SizeY = 100f, float PositionX = 0f, float PositionY = 130f) {
		StartCoroutine (ChoppingLaserBeam (Coloring, Direction, ActiveTime, WarningTime, Lines, SizeX, SizeY, PositionX, PositionY));
	}

	public void DoubleSpreadOrbPattern(Color32 Coloring, Vector2 Size, float Direction1, float Direction2, float Speed, int OrbCount, float Interval, float Delay = 0) {
		SpreadOrbPattern (Coloring, Size, Direction1, Speed, OrbCount, Interval, Delay);
		SpreadOrbPattern (Coloring, Size, Direction2, Speed, OrbCount, Interval, Delay);
	}

	public void SetPlayerCount(PlayerCount Count) {
		GameObject.Find ("Player").GetComponent<PlayerController> ().SetPlayerCount (Count);
	}

	public void PlayerCrusher(Color32 Coloring, Vector2 Size, float MoveTime, float SmashTime) {
		StartCoroutine (PlayerCrushingBox (Coloring, Size, MoveTime, SmashTime));
	}

	public void InverseSpreadOrbPattern (Color32 Coloring, Vector2 Size, float Direction, float Speed, int OrbCount, float Interval, float Delay = 0) {
        StartCoroutine(InverseOrbSpreadPattern(Coloring, Size, Direction, Speed, OrbCount, Interval, Delay));
	}

	public void InverseSpreadSquarePattern (Color32 Coloring, Vector2 Size, float Direction, float Speed, int OrbCount, float Interval) {
		if (OrbCount % 2 != 0) {
			int MiddleNumber = OrbCount / 2 + 1;
			int OrbsOnEachSide = MiddleNumber - 1;
			FormationPattern Pattern = new FormationPattern ();
			List<float> Angles = new List<float> ();
			for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1) {
				Angles.Add (i * Interval);
			}
			Pattern.Angles = Angles;
			foreach (float Angle in FormationPatternDirection(Direction, Pattern)) {
				Transform NewOrb = Square (Coloring, Size, 2);
				NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));
				NewOrb.transform.Translate (Vector3.up * 100, Space.Self);
				Launch (NewOrb, -Speed, Angle);
			}
		} else if (OrbCount % 2 == 0) {
			float HalfInterval = Interval / 2;
			float OrbsOnEachSide = OrbCount / 2;
			FormationPattern Pattern = new FormationPattern();
			List<float> Angles = new List<float>();
			for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1) {
				if (i < 0) {
					Angles.Add ((i * Interval) + HalfInterval);
				} else if (i > 0) {
					Angles.Add ((i * Interval) - HalfInterval);
				}
			}
			Pattern.Angles = Angles;
			foreach (float Angle in FormationPatternDirection(Direction, Pattern)) {
				Transform NewOrb = Square (Coloring, Size, 2);
				NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));	
				NewOrb.transform.Translate (Vector3.up * 100, Space.Self);
				Launch (NewOrb, -Speed, Angle);
			}
		}
	}

    public void SpreadOrbExplosion(Color32 Coloring, Vector2 Size, float Direction, float Speed, int OrbCount, float Interval, Vector2 Position)
    {
        if (OrbCount % 2 != 0)
        {
            int MiddleNumber = OrbCount / 2 + 1;
            int OrbsOnEachSide = MiddleNumber - 1;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                Angles.Add(i * Interval);
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2);
                NewOrb.position = Position;
                Launch(NewOrb, Speed, Angle);
            }
        }
        else if (OrbCount % 2 == 0)
        {
            float HalfInterval = Interval / 2;
            float OrbsOnEachSide = OrbCount / 2;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                if (i < 0)
                {
                    Angles.Add((i * Interval) + HalfInterval);
                }
                else if (i > 0)
                {
                    Angles.Add((i * Interval) - HalfInterval);
                }
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2);
                NewOrb.position = Position;
                Launch(NewOrb, Speed, Angle);
            }
        }
    }

    public void SpreadOrbPattern(Color32 Coloring, Vector2 Size, float Direction, float Speed, int OrbCount, float Interval, float Delay = 0) {
        StartCoroutine(OrbSpreadPattern(Coloring, Size, Direction, Speed, OrbCount, Interval, Delay));
	}

    public void SpreadWarnOrbPattern(Color32 Coloring, Vector2 Size, float Direction, int OrbCount, float Interval, float AliveTime)
    {
        if (OrbCount % 2 != 0)
        {
            int MiddleNumber = OrbCount / 2 + 1;
            int OrbsOnEachSide = MiddleNumber - 1;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                Angles.Add(i * Interval);
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2, false);
                NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Angle));
                NewOrb.Translate(Vector3.up * 43.5f, Space.Self);
                Destroy(NewOrb, AliveTime);

                //Launch(NewOrb, Speed, Angle);
            }
        }
        else if (OrbCount % 2 == 0)
        {
            float HalfInterval = Interval / 2;
            float OrbsOnEachSide = OrbCount / 2;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                if (i < 0)
                {
                    Angles.Add((i * Interval) + HalfInterval);
                }
                else if (i > 0)
                {
                    Angles.Add((i * Interval) - HalfInterval);
                }
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2, false);
                NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Angle));
                NewOrb.Translate(Vector3.up * 43.5f, Space.Self);
                Destroy(NewOrb, AliveTime);
                //Launch(NewOrb, Speed, Angle);
            }
        }
    }

    public void SpreadSquareExplosion(Color32 Coloring, Vector2 Size, float Direction, float Speed, int SquareCount, float Interval, Vector2 Position)
    {
        if (SquareCount % 2 != 0)
        {
            int MiddleNumber = SquareCount / 2 + 1;
            int SquaresOnEachSide = MiddleNumber - 1;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = SquaresOnEachSide; i <= SquaresOnEachSide; i += 1)
            {
                Angles.Add(i * Interval);
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewSquare = Square(Coloring, Size, 2);
                Launch(NewSquare, Speed, Angle);
            }
        }
        else if (SquareCount % 2 == 0)
        {
            float HalfInterval = Interval / 2;
            float SquaresOnEachSide = SquareCount / 2;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = SquaresOnEachSide; i <= SquaresOnEachSide; i += 1)
            {
                if (i < 0)
                {
                    Angles.Add((i * Interval) + HalfInterval);
                }
                else if (i > 0)
                {
                    Angles.Add((i * Interval) - HalfInterval);
                }
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewSquare = Square(Coloring, Size, 2);
                NewSquare.position = Position;
                Launch(NewSquare, Speed, Angle);
            }
        }
    }

    public void SpreadSquarePattern (Color32 Coloring, Vector2 Size, float Direction, float Speed, int SquareCount, float Interval) {
		if (SquareCount % 2 != 0) {
			int MiddleNumber = SquareCount / 2 + 1;
			int SquaresOnEachSide = MiddleNumber - 1;
			FormationPattern Pattern = new FormationPattern ();
			List<float> Angles = new List<float> ();
			for (float i = -SquaresOnEachSide; i <=SquaresOnEachSide; i += 1) {
				Angles.Add (i * Interval);
			}
			Pattern.Angles = Angles;
			foreach (float Angle in FormationPatternDirection(Direction, Pattern)) {
				Transform NewSquare = Square (Coloring, Size, 2);
				Launch (NewSquare, Speed, Angle);
			}
		} else if (SquareCount % 2 == 0) {
			float HalfInterval = Interval / 2;
			float SquaresOnEachSide = SquareCount / 2;
			FormationPattern Pattern = new FormationPattern();
			List<float> Angles = new List<float>();
			for (float i = -SquaresOnEachSide; i <= SquaresOnEachSide; i += 1) {
				if (i < 0) {
					Angles.Add ((i * Interval) + HalfInterval);
				} else if (i > 0) {
					Angles.Add ((i * Interval) - HalfInterval);
				}
			}
			Pattern.Angles = Angles;
			foreach (float Angle in FormationPatternDirection(Direction, Pattern)) {
				Transform NewSquare = Square (Coloring, Size, 2);
				Launch (NewSquare, Speed, Angle);
			}
		}
	}

	public void SetObjectColor(Transform Object, Color NewColor) {
		Object.GetComponent<SpriteRenderer> ().color = NewColor;
	}

	public void SetCircleColors(Color Color1, Color Color2, Transform Circle) {
		foreach (Transform CircleColor in Circle) {
			if (CircleColor.name == "Color1") {
                CircleColor.GetComponent<SpriteRenderer>().color = Color1;
			}
			if (CircleColor.name == "Color2") {
                CircleColor.GetComponent<SpriteRenderer>().color = Color2;
			}
		}
	}

    public void HitCheckpoint()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().Health = 5;
        foreach (Transform Obj in Healthbar)
        {
            Obj.gameObject.SetActive(true);
            Obj.transform.localScale = new Vector3(5, 5, 1);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

	public void Orbit(Transform Object, float EndAngle, float OrbitTime, bool BerpInterpolation = false) {
		StartCoroutine (OrbitOverTime (Object, Object.rotation.eulerAngles.z, EndAngle, OrbitTime, BerpInterpolation));
	}

	public void Move(Transform Object, Vector2 Position, float MoveTime) {
		StartCoroutine (MoveOverTime (Object, Position, MoveTime));
	}

	public void Size(Transform Object, Vector2 EndSize, float ChangeTime, bool DestroyObject) {
		StartCoroutine (ChangeSizeOverTime (Object, EndSize, ChangeTime, DestroyObject));
	}

	public void Flash(Color32 Coloring, float CoverTime, int Order) {
		StartCoroutine (ScreenFlash (Coloring, CoverTime, Order));
	}

	public void Smash(Transform Object, float MoveTime, float SmashTime) {
		StartCoroutine (SmashPlayer (Object, MoveTime, SmashTime));
	}

    public void ArenaSize(float CoverAmount, float ChangeTime1, float ChangeTime2, bool ShrinkVertical, Color ShrinkColor1, Color ShrinkColor2)
    {
        Transform Block1 = null;
        Transform Block2 = null;
        bool MoveFromCurrent = false;
        if (!this.transform.parent.Find("Block1"))
        {
            Block1 = Square(ShrinkColor1, new Vector2(100, 100), 3);
            Block2 = Square(ShrinkColor2, new Vector2(100, 100), 3);
            Block1.name = "Block1";
            Block2.name = "Block2";
            Block1.SetParent(this.transform.parent);
            Block2.SetParent(this.transform.parent);
            MoveFromCurrent = true;
        } else
        {
            Block1 = this.transform.parent.Find("Block1");
            Block2 = this.transform.parent.Find("Block2");
        }

        float NewPosition = 175f - (CoverAmount * 50);

        if (ShrinkVertical == false)
        {
            if (Block1.position.y != 0)
            {
                MoveFromCurrent = true;
            }
            if (MoveFromCurrent == true)
            {
                Block1.position = new Vector2(190f, 0f);
                Block2.position = new Vector2(-190f, 0f);
            }
            Move(Block1, new Vector2(NewPosition, 0), ChangeTime1);
            Move(Block2, new Vector2(-NewPosition, 0), ChangeTime2);
        } else
        {
            if (Block1.position.x != 0)
            {
                MoveFromCurrent = true;
            }
            if (MoveFromCurrent == true)
            {
                Block1.position = new Vector2(0f, 190f);
                Block2.position = new Vector2(0f, -190f);
            }
            Move(Block1, new Vector2(0, NewPosition), ChangeTime1);
            Move(Block2, new Vector2(0, -NewPosition), ChangeTime2);
        }
    }

    public void Launch(Transform Attack, float Speed, float Direction) {
		Projectile Proj = Attack.gameObject.GetComponent<Projectile> ();
		if (Proj == null) {
			Proj = Attack.gameObject.AddComponent<Projectile> ();
		}
		Proj.Direction = Direction;
		Proj.Speed = Speed * GameSettings.GameSpeed;
		Proj.PassedTime = CurrentTime;
	}
    #endregion

    #region Coroutines
    public IEnumerator ConeWarningArea(Color32 Coloring, float StartAngle, float EndAngle, float Lifetime, bool LerpRemove, bool LerpCreate)
    {
        GameObject Object = new GameObject();
        SpriteRenderer Rend = Object.AddComponent<SpriteRenderer>();
        //Instance Inst = new Instance();
        int Difference = Mathf.RoundToInt(Mathf.Abs(StartAngle - EndAngle));
        var path = new Shape()
        {
            Contours = new BezierContour[] { new BezierContour() { Segments = new BezierPathSegment[Difference + 1] } },
            Fill = new SolidFill() { Color = new Color32(Coloring.r, Coloring.g, Coloring.b, 128) },
            PathProps = new PathProperties()
            {
                Stroke = new Stroke() { Color = Color.clear }
            }
        };
        //Inst.mesh = new Mesh();
        //Filter.mesh = Inst.mesh;
        path.Contours[0].Segments[0].P0 = (Vector2)new Vector2(0f, 0f);
        GameObject Indication = new GameObject();
        for (int i = 0; i < Difference; ++i)
        {
            Indication.transform.position = new Vector2(0f, 50f);
            Indication.transform.RotateAround(transform.position, new Vector3(0f, 0f, -1f), StartAngle + i);
            path.Contours[0].Segments[i + 1].P0 = (Vector2)new Vector2(Indication.transform.position.x, Indication.transform.position.y);
            path.Contours[0].Segments[i + 1].P1 = (Vector2)new Vector2(Indication.transform.position.x, Indication.transform.position.y);
            path.Contours[0].Segments[i + 1].P2 = (Vector2)new Vector2(Indication.transform.position.x, Indication.transform.position.y);
        }
        Destroy(Indication);

        var _scene = new Unity.VectorGraphics.Scene()
        {
            Root = new SceneNode() { Shapes = new List<Shape>() { path } }
        };

        var geoms = VectorUtils.TessellateScene(_scene, options);
        Sprite s = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, false);

        Rend.sprite = s;
        Rend.material = new Material(Shader.Find("Unlit/Vector"));
        if (LerpCreate == true)
        {
            Object.transform.localScale = new Vector3(0f, 10f, 1f);
            Size(Object.transform, new Vector2(10f, 10f), 0.5f, false);
        }
        else
        {
            Object.transform.localScale = new Vector3(10f, 10f, 1f);
        }

        yield return StartCoroutine(Wait(Lifetime));
        if (LerpRemove == true)
        {
            Size(Object.transform, new Vector2(0f, 10f), 0.5f, true);
        }
        else
        {
            Destroy(Object);
        }
    }

    public IEnumerator OrbSpreadPattern(Color32 Coloring, Vector2 Size, float Direction, float Speed, int OrbCount, float Interval, float Delay)
    {
        if (OrbCount % 2 != 0)
        {
            int MiddleNumber = OrbCount / 2 + 1;
            int OrbsOnEachSide = MiddleNumber - 1;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                Angles.Add(i * Interval);
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2);
                Launch(NewOrb, Speed, Angle);
                if (Delay > 0)
                {
                    yield return StartCoroutine(Wait(Delay));
                }
            }
        }
        else if (OrbCount % 2 == 0)
        {
            float HalfInterval = Interval / 2;
            float OrbsOnEachSide = OrbCount / 2;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                if (i < 0)
                {
                    Angles.Add((i * Interval) + HalfInterval);
                }
                else if (i > 0)
                {
                    Angles.Add((i * Interval) - HalfInterval);
                }
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2);
                Launch(NewOrb, Speed, Angle);
                if (Delay > 0)
                {
                    yield return StartCoroutine(Wait(Delay));
                }
            }
        }
    }

    public IEnumerator InverseOrbSpreadPattern(Color32 Coloring, Vector2 Size, float Direction, float Speed, int OrbCount, float Interval, float Delay)
    {
        if (OrbCount % 2 != 0)
        {
            int MiddleNumber = OrbCount / 2 + 1;
            int OrbsOnEachSide = MiddleNumber - 1;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                Angles.Add(i * Interval);
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2);
                NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));
                NewOrb.transform.Translate(Vector3.up * 100, Space.Self);
                Launch(NewOrb, -Speed, Angle);
                if (Delay > 0)
                {
                    yield return StartCoroutine(Wait(Delay));
                }
            }
        }
        else if (OrbCount % 2 == 0)
        {
            float HalfInterval = Interval / 2;
            float OrbsOnEachSide = OrbCount / 2;
            FormationPattern Pattern = new FormationPattern();
            List<float> Angles = new List<float>();
            for (float i = -OrbsOnEachSide; i <= OrbsOnEachSide; i += 1)
            {
                if (i < 0)
                {
                    Angles.Add((i * Interval) + HalfInterval);
                }
                else if (i > 0)
                {
                    Angles.Add((i * Interval) - HalfInterval);
                }
            }
            Pattern.Angles = Angles;
            foreach (float Angle in FormationPatternDirection(Direction, Pattern))
            {
                Transform NewOrb = Orb(Coloring, Size, 2);
                NewOrb.rotation = Quaternion.Euler(new Vector3(0, 0, -Direction));
                NewOrb.transform.Translate(Vector3.up * 100, Space.Self);
                Launch(NewOrb, -Speed, Angle);
                if (Delay > 0)
                {
                    yield return StartCoroutine(Wait(Delay));
                }
            }
        }
    }
    public IEnumerator WaitForTime(float Delay) {
		float TrueDelay = Mathf.Clamp(Delay - CurrentTime, 0, 9000001);
		CurrentTime -= Delay;
        if (TrueDelay > 0)
        {
            float Timer = 0.0f;
            do
            {
                Timer += (Time.deltaTime * GameSettings.GameSpeed);
                yield return null;
            } while (Timer < TrueDelay);
        }
    }

	public IEnumerator Wait(float Delay) {
		float TrueDelay = Mathf.Clamp(Delay - CurrentTime, 0, 9000001);
        if (TrueDelay > 0)
        {
            float Timer = 0.0f;
            do
            {
                Timer += (Time.deltaTime * GameSettings.GameSpeed);
                yield return null;
            } while (Timer < TrueDelay);
        }
	}

	private IEnumerator PlayerCrushingBox(Color32 Coloring, Vector2 ObjectSize, float MoveTime, float SmashTime) {
		Transform NewBox = Square (Coloring, ObjectSize, 2);
		NewBox.position = new Vector2 (0f, ObjectSize.y * 1.8f);
		Smash (NewBox, MoveTime, SmashTime);
		yield return StartCoroutine (Wait (MoveTime + SmashTime));
		Size (NewBox, new Vector2 (0f, NewBox.transform.localScale.y), 0.5f, true);
	}
	private IEnumerator ChoppingLaserBeam(Color32 Coloring, float Direction, float ActiveTime, float WarningTime,  bool Lines, float SizeX, float SizeY, float PositionX, float PositionY) {
		Transform Beam = Square (Coloring, new Vector2 (SizeX, SizeY), 2);
        Beam.position = new Vector2(PositionX, PositionY);
        Beam.RotateAround(transform.position, new Vector3(0f, 0f, -1f), Direction);
        
		if (Lines == true) {
			DottedLine.Instance.DrawDottedLine (Vector2.zero, transform.position + (Beam.position * 30));
			DottedLine.Instance.Color = Coloring;
		}
		Beam.gameObject.SetActive (false);
		yield return StartCoroutine(Wait(WarningTime));
		DottedLine.Instance.Clean ();
        Beam.gameObject.SetActive (true);
        Size (Beam, new Vector2 (0f, SizeY), Mathf.Clamp (ActiveTime - CurrentTime, 0f, 9001f), true);
    }

    private IEnumerator SmashPlayer(Transform Object, float MoveTime, float SmashTime) {
        Orbit(Object, PlayerController.Degrees, MoveTime);
		yield return StartCoroutine (Wait (MoveTime));
		Move (Object, Object.transform.position + (Object.transform.up * -Object.transform.localScale.y), SmashTime);
	}

    private IEnumerator WarningRectangleShape(Color32 Coloring, Vector2 Scale, Vector2 Position, int Order, float Lifetime, float Angle)
    {
        Transform Warn = Square(new Color32(Coloring.r, Coloring.g, Coloring.b, 128), Vector2.zero, Order, false);
        Size(Warn, Scale * 0.99f, 0.25f, false);
        Warn.position = Position;
        Warn.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
        yield return StartCoroutine(Wait(Lifetime));
        Destroy(Warn.gameObject);
        //Size(Warn, new Vector2(0f, Scale.y), 0.1f, true);
    }

    private IEnumerator WarningOrbShape(Color32 Coloring, Vector2 Scale, Vector2 Position, int Order, float Lifetime, float Angle)
    {
        Transform Warn = Orb(new Color32(Coloring.r, Coloring.g, Coloring.b, 128), Vector2.zero, Order, false);
        Size(Warn, Scale * 0.99f, 0.25f, false);
        Warn.position = Position;
        Warn.rotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
        yield return StartCoroutine(Wait(Lifetime));
        Destroy(Warn.gameObject);
        //Size(Warn, new Vector2(0f, Scale.y), 0.1f, true);
    }

    private IEnumerator ScreenFlash(Color32 Coloring, float CoverTime, int Order) {
		ScreenCover.gameObject.SetActive (true);
		ScreenCover.GetComponent<SpriteRenderer> ().color = Coloring;
		ScreenCover.GetComponent<SpriteRenderer> ().sortingOrder = Order;
		yield return StartCoroutine (Wait (CoverTime));
		float FadeTime = CoverTime / 0.5f;
		float Timer = 0.0f;
		Color32 FadedColor = Coloring;
		FadedColor.a = 0;
		do {
			ScreenCover.GetComponent<SpriteRenderer> ().color = Color.Lerp (Coloring, FadedColor, Timer / FadeTime);
			Timer += Time.deltaTime;
			yield return null;
		} while (Timer < FadeTime);
		ScreenCover.gameObject.SetActive (false);
	}

	private IEnumerator MoveOverTime(Transform Object, Vector2 Position, float MoveTime) {
		Vector2 StartPosition = Object.position;
		Vector2 CurrentPosition = StartPosition;
		float Timer = 0.0f;
		if (MoveTime > 0f) {
			do {
                //CurrentPosition = Berp(StartPosition, Position, Timer / MoveTime);
				CurrentPosition = Vector2.Lerp (StartPosition, Position, Timer / MoveTime);
				Object.position = CurrentPosition;
				Timer += (Time.deltaTime * GameSettings.GameSpeed);
				yield return null;
			} while (Timer < MoveTime);
		} else {
			Object.position = Position;
			yield return null;
		}
	}

    private IEnumerator OrbitOverTime(Transform Object, float StartAngle, float EndAngle, float OrbitTime, bool BerpInterpolation) {
		float Step = 0.0f;
		float Rate = 1.0f / OrbitTime;
		float SmoothStep = 0.0f;
		float LastStep = 0.0f;
		while (Step < 1.0f) {
			Step += (Time.deltaTime * GameSettings.GameSpeed) * Rate;
            if (BerpInterpolation == true)
            {
                SmoothStep = Berp(0.0f, 1.0f, Step);
            } else
            {
                SmoothStep = Mathf.SmoothStep(0.0f, 1.0f, Step);
            }
			Object.RotateAround (transform.position, new Vector3 (0f, 0f, -1f), (EndAngle - StartAngle) * (SmoothStep - LastStep));
			LastStep = SmoothStep;
			yield return null;
		}

		if (Step > 1.0f) {
			Object.RotateAround (transform.position, new Vector3 (0f, 0f, -1f), EndAngle * (1.0f - LastStep));
		}
	}

	private IEnumerator ChangeSizeOverTime(Transform Object, Vector2 EndSize, float ChangeTime, bool DestroyObject) {
		Vector2 StartSize = Object.localScale;
		Vector2 CurrentSize = StartSize;
		float Timer = 0.0f;
		if (ChangeTime > 0f) {
			do {
                CurrentSize = Hermite(StartSize, EndSize, Timer / ChangeTime);
				//CurrentSize = Vector2.Lerp (StartSize, EndSize, Timer / ChangeTime);
				Object.localScale = CurrentSize;
				Timer += (Time.deltaTime * GameSettings.GameSpeed);
				yield return null;
			} while (Timer < ChangeTime);
		} else {
			Object.localScale = EndSize;
			yield return null;
		}

		if (DestroyObject == true) {
			Destroy (Object.gameObject);
		}
	}

    //public IEnumerator ShrinkArena()
    //{

    //}
    #endregion

    #region Methods
    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }

    public static Vector2 Hermite(Vector2 start, Vector2 end, float value)
    {
        return new Vector2(Hermite(start.x, end.x, value), Hermite(start.y, end.y, value));
    }
    public float Berp(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
        return start + (end - start) * value;
    }

    public Vector2 Berp(Vector2 start, Vector2 end, float value)
    {
        return new Vector2(Berp(start.x, end.x, value), Berp(start.y, end.y, value));
    }

    public float Bounce(float x)
    {
        return Mathf.Abs(Mathf.Sin(6.28f * (x + 1f) * (x + 1f)) * (1f - x));
    }

    public Vector2 Bounce(Vector2 vec)
    {
        return new Vector2(Bounce(vec.x), Bounce(vec.y));
    }

    public void EndCoroutine(IEnumerator Enumerator)
    {
        StopCoroutine(Enumerator);
    }
	public float GetPlayerDirection() {
        Vector3 Dir = GameObject.Find ("Player").transform.position - transform.position;
        float Angle = Vector3.Angle (Dir, Vector2.right);
        return Angle + 90f;
        //return PlayerController.Degrees - 90;
	}

	public List<float> FormationPatternDirection(float Direction, FormationPattern Pattern) {
		List<float> Directions = new List<float> ();
		foreach (float Angle in Pattern.Angles) {
			float NewDirection = Angle + Direction;
			Directions.Add (NewDirection);
		}
		return Directions;
	}
	#endregion
		
	#region Data Types
	[System.Serializable] public class ColorScheme
	{
		public string Name = "Scheme";
        public bool CoreVibrating = false;
		public Color BackgroundColor;
		public Color32 PlayerColor;
		public Color32 LineColor;
		public Color32 CoreColor;
		public Color32 LargeRingColor;
		public Color32 SmallRingColor;
		public ObjectColors CenterCircle = new ObjectColors(Color.black, Color.black);
		public ObjectColors MiddleCircle = new ObjectColors(Color.black, Color.black);
		public ObjectColors EnclosingCircle = new ObjectColors(Color.black, Color.black);
		public ObjectColors LoopingCircle = new ObjectColors(Color.black, Color.black);
	}

	[System.Serializable] public class ObjectColors
	{
		public ObjectColors(Color32 _Color1, Color32 _Color2) {
			Color1 = _Color1;
			Color2 = _Color2;
		}
		public Color32 Color1;
		public Color32 Color2;
	}

	[System.Serializable] public class FormationPattern {
		public List<float> Angles;
	}
	#endregion
}
