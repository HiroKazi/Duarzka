using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DUAR : MonoBehaviour
{
    public GameObject Ledak;
    public GameObject player_ledak;
    public int scoreValue;
    private GameController gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag != "batas")
        {
            Instantiate(Ledak, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
        
        if (other.tag == "Player")
        {
            Instantiate(player_ledak, other.transform.position, other.transform.rotation);
            gameController.LessScore(scoreValue);
            gameController.GameOver();
            
        }
        

        
    }

}
