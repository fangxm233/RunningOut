using UnityEngine;

public class Tween : MonoBehaviour {

    GameObject o;
    int count;
    int now_count;
    float time;
    public bool is_moving;
    Vector3 distance;

    public void Move(GameObject o, float time, Vector3 to)
    {
        Reset();
        this.o = o;
        this.time = time / 10;
        count = 10;
        now_count = 0;
        is_moving = true;
        distance = CalculateDistance(o.transform.position, to, 10);
        InvokeRepeating("Move", 0, this.time);
    }
    public void Move(GameObject o, float time, Vector3 to, int count)
    {
        Reset();
        this.o = o;
        this.time = time / count;
        this.count = count;
        now_count = 0;
        is_moving = true;
        distance = CalculateDistance(o.transform.position, to, count);
        InvokeRepeating("Move", 0, this.time);
    }
    public void Move(GameObject o, float time, Vector3 to, Vector3 from)
    {
        Reset();
        this.o = o;
        this.time = time / 10;
        count = 10;
        now_count = 0;
        is_moving = true;
        this.o.transform.position = from;
        distance = CalculateDistance(o.transform.position, to, 10);
        InvokeRepeating("Move", 0, this.time);
    }
    public void Move(GameObject o, float time, Vector3 to, Vector3 from, int count)
    {
        Reset();
        this.o = o;
        this.time = time / count;
        this.count = count;
        now_count = 0;
        is_moving = true;
        this.o.transform.position = from;
        distance = CalculateDistance(from, to, count);
        InvokeRepeating("Move", 0, this.time);
    }

    void Move()
    {
        o.transform.position += distance;
        now_count++;
        if(now_count == count)
        {
            Reset();
            CancelInvoke("Move");
        }
    }

    void Reset()
    {
        is_moving = false;
        o = null;
        count = 0;
        now_count = 0;
        time = 0;
        distance = new Vector3();
        try
        {
            CancelInvoke("Move");
        }
        catch (System.Exception){}
    }

    Vector3 CalculateDistance(Vector3 from, Vector3 to, int times)
    {
        Vector3 v = new Vector3((to.x - from.x) / times, (to.y - from.y) / times, (to.z - from.z) / times);
        return v;
    }
}
