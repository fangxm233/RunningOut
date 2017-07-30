using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Mob mob;
    bool started;
    bool died;
    bool won;

    public static UIManager ui_maneger;
    public GameObject beginning_words;
    public GameObject next_words;
    public GameObject lose_words;
    public GameObject won_words;

    int now_level = 1;

    private void Awake()
    {
        ui_maneger = this;
    }

    // Use this for initialization
    void Start ()
    {
        now_level = Player.player.now_level;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (started) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (died)
            {
                lose_words.SetActive(false);
                SceneManager.LoadScene("main");
            }
            if (!died && !won)
            {
                GameManager.game_manager.GameStart();
                mob.GameStart(now_level);
                beginning_words.SetActive(false);
                started = true;
                return;
            }
        }
	}

    public void NextLevel(int level)
    {
        beginning_words.SetActive(true);
        now_level = level;
        started = false;
    }

    public void Die()
    {
        died = true;
        started = false;
        lose_words.SetActive(true);
    }

    public void Won()
    {
        won = true;
        started = false;
        won_words.SetActive(true);
        Destroy(mob.gameObject);
    }
}
