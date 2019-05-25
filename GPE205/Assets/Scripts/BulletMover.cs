using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    //Setting references to access other properties and methods
    public TankData data;
    public Transform tf;
    public Shoot shoot;
    public Timer timer;
    //These are properties used in this script
    public float destroyDuration;
    public float bulletSpeed;
    //Find objects and instaniate the bullet
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
        //destroyDuration is set to shotsPerSecond
        destroyDuration = data.shotsPerSecond;
    }

    // Update is called once per frame
    //Check to see if the bullet needs destoryed or needs to move
    void Update()
    {
        DestroyDuration(destroyDuration);
        Move();
    }
    /*Move allows the bullet to move by grabbing the transform
    translating it and applying a speed and time concept to move the bullet forward*/
    public void Move()
    {
        tf.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
    /*This is where the bullet has a Destroy method
    by checking to see if the timer has reached a certain time
    and if so it resets the timer along with destroying the object*/
    public void DestroyDuration(float seconds)
    {
        timer.StartTimer();
        if (timer.currentTime > seconds)
        {
            timer.ResetTime();
            Destroy(this.gameObject);
        }
    }
    /*If the bullet is destroy take away the instance of
    it that was created*/
    private void OnDestroy()
    {
        GameManager.instance.bulletInstance--;
    }
    //If the bullet hits a collider tagged with rock destroy the bullet
    private void OnTriggerEnter (Collider rock)
    {
        if (rock.gameObject.tag == "Rock")
            Destroy(this.gameObject);
    }
}
