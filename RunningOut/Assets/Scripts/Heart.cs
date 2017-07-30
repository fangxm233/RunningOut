using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.player.GetHeart();
        Destroy(gameObject);
    }
}
