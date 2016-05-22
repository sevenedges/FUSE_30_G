using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour
{
    public GameController gameController;

    public BG[] bg;

    private float speedMin;
    private float speedMax;
    private float speedMid;

    [System.Serializable]
    public class BG
    {
        public Renderer renderer;
        public float rate;
        public float x;
        public float w;
    }

    public void Scroll(float d)
    {
        for(int i=0; i<bg.Length; i++)
        {
            bg[i].x += (d * bg[i].rate / bg[i].w);
            if (bg[i].x > 1f) bg[i].x -= 1f;
            if (bg[i].x < 0f) bg[i].x += 1f;
            bg[i].renderer.material.SetTextureOffset("_MainTex", new Vector2(bg[i].x, 0));
        }
    }

    // Use this for initialization
    void Start()
    {
        speedMin = gameController.ScrollSpeedMin;
        speedMax = gameController.ScrollSpeedMax;
        speedMid = (speedMin + speedMax) / 2;
    }

    // Update is called once per frame
    void Update()
    {
    }

}
