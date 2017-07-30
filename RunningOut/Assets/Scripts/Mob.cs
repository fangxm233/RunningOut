using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public List<Vector3> start;
    public List<Vector3> end;
    public Tween tween;

	// Use this for initialization
	//void Start () {}
	
	// Update is called once per frame
	//void Update () {}
    public void GameStart(int level)
    {
        tween.Move(gameObject, 20, end[level], start[level], 600);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            Player.player.Die();
        }
    }
}
