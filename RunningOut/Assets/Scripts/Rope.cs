using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.player.GetRope();
        Destroy(gameObject);
    }
}
