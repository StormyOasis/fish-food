using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float hungerGain = 5f;
    private float flakeTTL = 5f;
    private float currentAge = 0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        hungerGain = Random.Range(1, 6);
        flakeTTL = Random.Range(30f, 75f);
}

    // Update is called once per frame
    void Update()
    {
        currentAge += Time.deltaTime;
        if(currentAge >= flakeTTL)
        {
            gameManager.currentFoodFlakes--;
            Destroy(gameObject);
        }
    }
}
