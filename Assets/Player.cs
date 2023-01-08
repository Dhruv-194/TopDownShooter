using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f; ///[Searilized] used to show that this is public and we want to directly update/edit it from the Unity Editor
    private Rigidbody2D rb; 
    private float mx;
    private Vector2 mousePos;

    public float playerMaxHealth = 100f;

      [SerializeField] private Slider playerHealthSlider;

    Enemy target;


    //Gun variables 
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)] [SerializeField] public float fireRate = 0.5f; //controlling the firerate of the bullet so that the user doesnt spam
    
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealthSlider.maxValue = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxis("Horizontal"); //keyboard controls (left or right)
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x-transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0,0,angle);

        if(Input.GetMouseButtonDown(0)&&fireTimer<=0f){
            Shoot();
            fireTimer = fireRate;
        }else{
            fireTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(mx,0).normalized * speed;
    }

    private void Shoot(){
        Instantiate(bullet, firingPoint.position, firingPoint.rotation);
    }

     private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Enemy")){
           playerMaxHealth = playerMaxHealth - 20f;
            Destroy(other.gameObject);

            if(playerMaxHealth<=0f){
                playerHealthSlider.value = 0f;
                 Destroy(gameObject);
             //   target.target = null;
            }
            
}
     }

     private void OnGUI(){
    float t = Time.deltaTime / 1f;
        playerHealthSlider.value = Mathf.Lerp(playerHealthSlider.value, playerMaxHealth, t);
    }
}
