using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Keys
{
    public KeyCode jump;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;
    public KeyCode run;
    public KeyCode down;
    public KeyCode rope;
}

public class PlayerMoving : MonoBehaviour {

    public float speed;
    public float run_speed;
    public float jump_speed;
    public float climb_speed;
    public Rigidbody2D rig;
    public BoxCollider2D up_boundary;
    public BoxCollider2D down_boundary;
    public Player player;
    public GameObject rope_top;
    public GameObject rope;
    public Keys keys;

    bool on_floor;
    float now_speed;
    // Use this for initialization
    void Start ()
    {
        player = Player.player;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameManager.game_manager.started) return;
        CheckSpace();
        PlayerAction();
    }

    void FixedUpdate()
    {
        if (!GameManager.game_manager.started) return;
        PlayerMove();
    }

    void PlayerAction()
    {
        if (Input.GetKeyDown(keys.rope))
        {
            if (!player.UseRope()) return;
            GameObject n = Instantiate(rope_top);
            n.GetComponent<Tween>().Move(n, 0.5f, new Vector3(transform.position.x, player.camera_y[player.now_level] + 2.35f, n.transform.position.z), transform.position + new Vector3(0, 0, 0.5f), 20);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(keys.up))
        {
            rig.velocity = new Vector2(rig.velocity.x, climb_speed);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKey(keys.up))
        {
            rig.velocity = new Vector2(rig.velocity.x, climb_speed);
        }
    }


    void PlayerMove()
    {
        bool is_moved = false;
        if (Input.GetKey(keys.run))
        {
            now_speed = run_speed;
        }
        else
        {
            now_speed = speed;
        }
        if (Input.GetKey(keys.left))
        {
            rig.velocity = new Vector2(-now_speed, rig.velocity.y);
            is_moved = true;
        }
        if (Input.GetKey(keys.right))
        {
            rig.velocity = new Vector2(now_speed, rig.velocity.y);
            is_moved = true;
        }
        if (Input.GetKey(keys.jump) && on_floor)
        {
            rig.velocity = new Vector2(rig.velocity.x, jump_speed);
        }
        if (!is_moved)
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
    }

    void CheckSpace()
    {
        //Vector2 fwd = transform.TransformDirection(Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), new Vector2(transform.position.x, transform.position.y - 2), 0.25f);
        if (!hit)
            hit = Physics2D.Raycast(new Vector2(transform.position.x - 0.2f, transform.position.y - 0.5f), new Vector2(transform.position.x - 0.2f, transform.position.y - 2), 0.25f);
        if (!hit)
            hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.025f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.025f, transform.position.y - 2), 0.25f);
        if (hit)
        {
            if(hit.transform.name == "Player")
            {
                on_floor = false;
                return;
            }
            if (hit.transform.tag == "rope")
            {
                on_floor = false;
                return;
            }
            on_floor = true;
        }
        else
        {
            on_floor = false;
        }
    }
}
