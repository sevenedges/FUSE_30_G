using UnityEngine;
using System.Collections;
public class B : MonoBehaviour {
	Vector3 vec;
	Vector4 ves;

	void Start () {
		vec = new Vector3 (0f, 0f, 0.3f);
		ves = new Vector4 (0f, 0f, -0.3f);
	}

	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (vec);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (ves);
		}
	}
}