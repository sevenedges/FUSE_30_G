using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	public float speed;
	public float destroytime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroytime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed * Time.deltaTime, speed * Time.deltaTime, 0);
	}
	void OnCollisionEnter (Collision other)
	{
		SceneManager.LoadScene ("Title");
	
	}
}
