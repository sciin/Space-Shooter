using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    GameObject gameController;
    GameController controller;
    void Start()
    { 
        gameController = GameObject.FindGameObjectWithTag("GameController");
        controller = gameController.GetComponent<GameController>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "boundary")
        {
            Destroy(other.gameObject);
            Destroy(gameObject); 
            Instantiate(explosion, transform.position, transform.rotation);
            controller.ScoreIncrease(10);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            controller.GameFinished();
        }
        
    }
}
