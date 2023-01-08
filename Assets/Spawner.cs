using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private GameObject[]  gameObjectsPrefabs;
    [SerializeField] private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerRepeat());
    }

    private IEnumerator SpawnerRepeat(){
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
    
        while(canSpawn){
            yield return wait;
                if(GameObject.FindGameObjectWithTag("Player")){
            int random = Random.Range(0, gameObjectsPrefabs.Length);
            GameObject gameObjectToSpawn = gameObjectsPrefabs[random];
            Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity);
        }
    }
    }
    // Update is called once per frame
}
