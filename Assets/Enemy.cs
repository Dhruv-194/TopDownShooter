using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform target; 
    public float speed = 3f;
    public float roateSpeed = 0.25f;
    public float enemyMaxHealth = 100f;
   // public float playerMaxHealth = 100f;

    private float ehealth = 0f;

  //  private float phealth = 0f;

   // [SerializeField] private Slider enemyHealthSlider;

private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ehealth = enemyMaxHealth;
       // enemyHealthSlider.maxValue = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the target
        if(!target){
            GetTarget();
        }
     //Roate towards the target 
     else{
        RotateTowardsTarget();
     }  
    }

    void FixedUpdate(){
        //Move forwards to the target
        rb.velocity = transform.up * speed; 
    }

    private void GetTarget(){
        if(GameObject.FindGameObjectWithTag("Player")){
        target =  GameObject.FindGameObjectWithTag("Player").transform;

        }
    }

   private void RotateTowardsTarget(){
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, roateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other){
        // if(other.gameObject.CompareTag("Player")){
        //    playerMaxHealth = playerMaxHealth - 20f;
        //     Destroy(gameObject);

        //     if(playerMaxHealth<=0f){
        //          Destroy(other.gameObject);
        //         target = null;
        //     }
            
            
           
        // } else 
        if((other.gameObject.CompareTag("Bullet"))){
            ehealth = ehealth- 50f;
             if(ehealth<=0f){
            Destroy(other.gameObject);
            Destroy(gameObject);
             }
        }
    }

//    private void OnGUI(){
//     float t = Time.deltaTime / 1f;
//         enemyHealthSlider.value = Mathf.Lerp(enemyHealthSlider.value, ehealth, t);
//     }
}
