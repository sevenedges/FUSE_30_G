using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public BGController bgController;
    public ItemController itemController;
    public GroundController groundController;

    public Transform transformCharacter;
    public Transform transformItemController;

    public float ScrollSpeedMin;
    public float ScrollSpeedMax;
    public float ScrollSpeedMid;
    public float ScrollSpeed;

    private int score;
    public TextMesh scoreDigit;

    public Renderer result;

    private bool isDrag;
    private Vector3 oldpos;
    public Renderer nut;
    public float nut_u;
    private float drag_v;

    // Use this for initialization
    void Start () {
        ScrollSpeedMid = (ScrollSpeedMax + ScrollSpeedMin) / 2;
        ScrollSpeed = ScrollSpeedMid;
        score = 0;
        result.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        float t = Time.deltaTime;
        bgController.Scroll(t * ScrollSpeed);
        itemController.MoveAll(t, ScrollSpeed);

        // Control by Mouse Drag
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDrag = true;
                oldpos = Input.mousePosition;
                // Back to Title
                if (result.enabled)
                {
                    SceneManager.LoadScene("Title");
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDrag = false;
            }
            if (isDrag)
            {
                Vector3 newpos = Input.mousePosition;
                drag_v = newpos.x - oldpos.x;
                oldpos = newpos;
            }
            ScrollSpeed += drag_v * Time.deltaTime * 0.7f;
            nut_u -= drag_v * Time.deltaTime * 0.1f;
            nut.material.SetTextureOffset("_MainTex", new Vector2(nut_u, 0f));
            //
            drag_v *= 0.9f;
        }
        /*
        // Control by Arrow Keys
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ScrollSpeed -= 6f * t;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ScrollSpeed += 6f * t;
            }
        }
        */
        ScrollSpeed = Mathf.Max(ScrollSpeedMin, Mathf.Min(ScrollSpeedMax, ScrollSpeed));
        groundController.Tilt(ScrollSpeed / ScrollSpeedMid - 1f);

    }

    public void addScore()
    {
        score++;
        scoreDigit.text = score.ToString();
    }

    public void ResultScreen()
    {
        result.enabled = true;
    }
}
