using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

    public Vector3 speed;

    public float _accel;
    public float _verocity;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        _verocity += _accel * Time.deltaTime;
	}
}
