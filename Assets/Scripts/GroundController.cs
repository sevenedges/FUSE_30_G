using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

    public float tiltMax;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Tilt(float r)
    {
        float angle = -tiltMax * r;
        GetComponent<Transform>().localEulerAngles = new Vector3(0f, 0f, angle);
    }
}
