using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public TankData data;
    public Transform tf;
    public Shoot shoot;
    public Timer timer;
    public float destroyDuration;
    public float bulletSpeed;
    private void Awake()
    {
        shoot = FindObjectOfType<Shoot>();
        timer = FindObjectOfType<Timer>();
        data = FindObjectOfType<TankData>();
        GameManager.instance.bulletInstance++;
    }
    // Start is called before the first frame update
    void Start()
    {
        destroyDuration = data.shotsPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyDuration(destroyDuration);
        Move();
    }
    public void Move()
    {
        tf.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
    public void DestroyDuration(float seconds)
    {
        timer.StartTimer();
        if (timer.currentTime > seconds)
        {
            timer.ResetTime();
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        GameManager.instance.bulletInstance--;
    }
    private void OnCollisionStay(Collision rock)
    {
        Debug.Log(rock.gameObject);
        if (rock.gameObject.tag == "Rock")
            Destroy(this.gameObject);
    }
}
