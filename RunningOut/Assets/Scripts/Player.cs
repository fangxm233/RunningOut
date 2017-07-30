using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int rope_count;
    public int health_count;
    public int now_level = 1;

    public float pressure;
    public float max_ressure;
    public float pressure_count_sec;

    public float spring_speed;
    public float avoid_damage_time;

    public Rigidbody2D rig;
    public static Player player;

    public Mob mob;

    public Image pressure_i;
    public Text brain_count_ui;
    public Text heart_count_ui;
    public Text rope_count_ui;

    public List<Vector3> levels;
    public List<Vector3> mob_position;
    public List<float> camera_y;

    bool in_avoid;
    void Awake()
    {
        player = this;
    }

    // Use this for initialization
    void Start ()
    {
        transform.position = levels[now_level] + new Vector3(0, 0, transform.position.z);
        //Boundaries.transform.position = new Vector3(0, camera_y[now_level] - 2.6f, Boundaries.transform.position.z);
        Camera.main.transform.position = new Vector3(0, camera_y[now_level], Camera.main.transform.position.z);
        InvokeRepeating("LosePower", 1, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        RefreshUI();
	}

    void RefreshUI()
    {
        heart_count_ui.text = health_count.ToString();
        brain_count_ui.text = pressure.ToString();
        rope_count_ui.text = rope_count.ToString();
    }

    public void GetRope()
    {
        rope_count++;
    }
    public bool UseRope()
    {
        if (rope_count <= 0)
        {
            return false; 
        }
        rope_count--;
        return true;
    }

    public void GetHeart()
    {
        health_count++;
    }

    void FixedUpdate()
    {
        //if (pressure_i.color.a != pressure * 2)
        //    pressure_i.color = new Color(pressure_i.color.r, pressure_i.color.g, pressure_i.color.b, Mathf.Lerp(pressure * 2, pressure_i.color.a * 200.0f, 0.96f) / 200);
    }

    public void NextLevel()
    {
        now_level++;
        if (now_level == levels.Count)
        {
            Victory();
            return;
        }
        transform.position = levels[now_level] + new Vector3(0, 0, transform.position.z);
        //Boundaries.transform.position = new Vector3(0, camera_y[now_level] - 2.6f, Boundaries.transform.position.z);
        Camera.main.transform.position = new Vector3(0, camera_y[now_level], Camera.main.transform.position.z);
        GameManager.game_manager.started = false;
        UIManager.ui_maneger.NextLevel(now_level);
    }

    void Victory()
    {
        GameManager.game_manager.started = false;
        UIManager.ui_maneger.Won();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        UIManager.ui_maneger.Die();
    }
    public void GetDamage()
    {
        if (in_avoid) return;
        health_count--;
        if(health_count <= 0)
        {
            Die();
            return;
        }
        in_avoid = true;
        Invoke("ChangeFlag", avoid_damage_time);
    }

    void ChangeFlag()
    {
        in_avoid = false;
    }

    void LosePower()
    {
        if (!GameManager.game_manager.started) return;
        pressure -= pressure_count_sec;
        if (pressure <= 0)
        {
            Die();
        }
    }

    public void GetPower(float f)
    {
        pressure += f;
        if (pressure >= max_ressure)
        {
            pressure = max_ressure;
        }
    }
    public void LosePower(float f)
    {
        pressure -= f;
        if(pressure <= 0)
        {
            pressure = 0;
            Die();
        }
    }
    public void SetPower(float f)
    {
        pressure = f;
        if (pressure <= 0)
        {
            Die();
        }
        if (pressure >= max_ressure)
        {
            pressure = max_ressure;
        }
    }

}
