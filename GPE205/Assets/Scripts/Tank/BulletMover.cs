using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMover : MonoBehaviour
{
    //Setting references to access other properties and methods
    public TankData data;
    public Transform tf;
    //These are properties used in this script
    public float destroyDuration;
    public float bulletSpeed;
    public GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        //destroyDuration is set to shotsPerSecond
        destroyDuration = data.shotsPerSecondCurrent;
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
        Destroy(this.gameObject, destroyDuration);
    }
    
    //If the bullet hits a collider tagged with rock destroy the bullet
    private void OnTriggerEnter(Collider collide)
    {
        if (collide.GetComponent<TankData>() != null)
        {
            collide.GetComponent<TankData>().health -= data.damage;
            //Play explosion noise when colliding with player or enemy
            AudioManager.mastersounds.Play("Explosion");
            if(collide.GetComponent<TankData>().health <= 0)
            {
                    //Add score to player one
                    if (GameManager.instance.P1 != null)
                    {
                        if (GameManager.instance.P1.GetComponent<Collider>() == owner.GetComponent<Collider>())
                        {
                            GameManager.instance.P1score += GameManager.instance.score;
                        } 
                    }
                    //Add score to player two
                    if (GameManager.instance.P2 != null)
                    {
                        if (GameManager.instance.P2.GetComponent<Collider>() == owner.GetComponent<Collider>())
                        {
                            GameManager.instance.P2score += GameManager.instance.score;
                        }  
                    }
		                
            }
        }
        Destroy(this.gameObject);
    }
}
