using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class Cylinder : MonoBehaviour
	{
	public GameObject obj;
	int downFlg = -1;
	Vector3 inpVec = new Vector3();
	public float x;

		void Start ()
		{
		}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			inpVec = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0)) {
			Vector3 vect = Input.mousePosition;
			obj.transform.Rotate(new Vector3 (0f, 0f, (vect.x - inpVec.x) * x));
		}
	}
}
