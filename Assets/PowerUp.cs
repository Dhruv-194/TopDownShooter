using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

     public Transform target1; 

      public float speed = 3f;

      private Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
         if(!target1){
            GetTarget();
        }
        
    }

      void FixedUpdate(){
        //Move forwards to the target
        rb.velocity = transform.up * -speed; 
    }


        private void GetTarget(){
        if(GameObject.FindGameObjectWithTag("Player")){
        target1 =  GameObject.FindGameObjectWithTag("Player").transform;

        }
    }

    private void OnCollisionEnter2D(Collision2D other){
         if((other.gameObject.CompareTag("Bullet"))){
           GameObject player = GameObject.FindGameObjectWithTag("Player");
             Player playerScript = player.GetComponent<Player>();
             if(playerScript){
                playerScript.fireRate = playerScript.fireRate * 0.4f;
             }
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("here");
         }
    }
}
