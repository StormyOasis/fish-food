using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;    

    public int maxFoodFlakes = 5;
    public int currentFoodFlakes = 0;
    public float timeBetweenFlakes = 5f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentFoodFlakes < maxFoodFlakes)
        {
            Invoke("spawnFlake", timeBetweenFlakes);
        }
    }


    private void spawnFlake()
    {
        if (currentFoodFlakes < maxFoodFlakes)
        {
            //spawn
            //instantiate at random position
            Vector3 sartPosition = new Vector3(Random.Range(0, 50), 20, Random.Range(0, 128));
            Instantiate(foodPrefab, sartPosition, Quaternion.identity);

            currentFoodFlakes++;
        }
    }
}
