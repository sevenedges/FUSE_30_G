using UnityEngine;
using System.Collections;

public class PopLogo : MonoBehaviour {

    private Vector3 o;
    private float t;

	// Use this for initialization
	void Start () {
        o = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime * 2f;
        GetComponent<Transform>().position = o + new Vector3(0f, 1f, 0f) * Mathf.Sin(t) * 0.8f;
    }
}
