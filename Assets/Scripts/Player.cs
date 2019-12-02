using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Serializable]
    public class PlayerData
    {
        public float currentHealth = 100.0f;
        public float currentHunger = 100.0f;

        [Tooltip("Number of seconds before hunger increases by 1")]
        public float hungerDecayRate = 5.0f;

        [Tooltip("Number of seconds before health decreases when hunger is 0")]
        public float healthDecayRate = 10.0f;

        [Tooltip("Number of seconds before health increases when hunger is 0")]
        public float healthIncreaseRate = 2.5f;
    };

    [SerializeField]
    public PlayerData playerData = new PlayerData();

    private GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("UpdateValues", 1.0f, 1.0f);
    }

    public void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.tag.Equals("Food"))
        {           
            //increment hunger
            playerData.currentHunger += collision.collider.gameObject.GetComponent<Food>().hungerGain;
            if (playerData.currentHunger > 100)
                playerData.currentHunger = 100;

            gameManager.currentFoodFlakes--;

            //eating the food so remove the piece of food
            Destroy(collision.collider.gameObject);
        }
    }

    private void UpdateValues()
    {
        //potential for floating point issues below

        if (playerData.currentHealth <= 0)
        {
            //death / gameover
            Debug.Log("Died!");
            CancelInvoke();

            return;
        }

        playerData.currentHunger -= playerData.hungerDecayRate;

        if (playerData.currentHunger > 0 && playerData.currentHealth < 100)
        {
            //increase health
            playerData.currentHealth += playerData.healthIncreaseRate;
        } else if(playerData.currentHunger <= 0)
        {
            playerData.currentHunger = 0.0f;
            //decrease health
            playerData.currentHealth -= playerData.healthDecayRate;
        }

        if (playerData.currentHealth < 0)
            playerData.currentHealth = 0;
    }
}
