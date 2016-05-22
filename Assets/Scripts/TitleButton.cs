using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void toTitle()
	{
		SceneManager.LoadScene ("Title");//タイトル画面へ移動
	}
}
