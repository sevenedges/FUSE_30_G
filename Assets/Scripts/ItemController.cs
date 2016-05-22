using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemController : MonoBehaviour {

    public GameController gameController;

    List<GameObject> items;

    public float hitDist;

    public GameObject scoreUp;
    public Vector3 positionVanish;

    public float popTime;
    public float popTimeMax;
    public int pops;
    public int popsMax;

    // Use this for initialization
    void Start () {
        items = new List<GameObject>();
        popTime = 0f;
        pops = 0;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("a"))
        {
            //CreateItem();
            PopupItem();
        }
        popTime += Time.deltaTime;
        if (popTime > popTimeMax)
        {
            if (pops > popsMax)
            {
                gameController.ResultScreen();
            }
            else
            {
                PopupItem();
                popTime = 0f;
                popTimeMax -= 0.05f;
                pops++;
                // go to Result
                if (pops > popsMax)
                {
                    popTimeMax = 6f;
                }
            }
        }

    }

    void PopupItem()
    {
        GameObject item = (GameObject)Instantiate(scoreUp, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
        item.GetComponent<item>()._verocity = Random.Range(6f, 10f);
        items.Add(item);
    }

    public void MoveAll(float t, float d)
    {
        Vector3 p = gameController.transformCharacter.position;
        for (int i=items.Count-1; i>=0; i--)
        {
            GameObject item = items[i];
            //item.GetComponent<Transform>().position += item.GetComponent<item>().speed * t;
            Vector3 v = new Vector3(-d * t * 0.5f, item.GetComponent<item>()._verocity * t, 0f);
            //Vector3 v = new Vector3(-d, item.GetComponent<item>().speed.y * t, 0f);
            item.GetComponent<Transform>().position += v;
            if (item.GetComponent<Transform>().position.x < positionVanish.x
             || item.GetComponent<Transform>().position.y < positionVanish.y)
            {
                Destroy(item);
                items.Remove(item);
            }
            if ( Vector3.Distance( item.GetComponent<Transform>().position, p ) < hitDist)
            {
                gameController.addScore();
                Destroy(item);
                items.Remove(item);
            }
        }
	}

    float GetNeedSpeed()
    {
        float v = gameController.ScrollSpeed * Random.Range(0.8f, 1.2f);
        if (v > gameController.ScrollSpeedMax) v = gameController.ScrollSpeedMax;
        if (v < gameController.ScrollSpeedMin) v = gameController.ScrollSpeedMin;
        //
        v = gameController.ScrollSpeed;
        return v;
    }
    void CreateItem ()
    {
        float needSpeed = GetNeedSpeed();
                
        float dx = gameController.transformItemController.position.x - gameController.transformCharacter.position.x;
        float dy = gameController.transformItemController.position.y - gameController.transformCharacter.position.y;
        float t = dx / gameController.ScrollSpeed;
        float v = dy / t;
        v = v * Random.Range(1f, 1.5f);
        dy = v * t;
        GameObject item = (GameObject)Instantiate(scoreUp, gameController.transformCharacter.position, GetComponent<Transform>().rotation);
        item.GetComponent<item>().speed.x = 0f; // -dx / t;
        item.GetComponent<item>().speed.y = -v;
        item.GetComponent<item>().speed.z = 0f;
        item.GetComponent<Transform>().position += new Vector3(dx, dy, 0f);
        items.Add(item);
    }

}
