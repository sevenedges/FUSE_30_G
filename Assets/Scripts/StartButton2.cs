using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButtonDown(0)) {//マウスの左クリックを行った時
			SceneManager.LoadScene ("Game");//ゲーム画面へ移動
		}
	
	}*/
	public void toGame()
	{
		SceneManager.LoadScene ("Game");//ゲーム画面へ移動
	}
}
