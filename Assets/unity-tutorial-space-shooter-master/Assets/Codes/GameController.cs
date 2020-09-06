using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 randomPosition;
    public float StartedWait;
    public float createdWait;    
    public float loopWait;
    int score;
    public Text textScore;
    public Text textFinished;
    bool gameFinisController = false;
    bool retryStartController = false;
    void Start()
    {
        score = 0;
        textScore.text = "Score: " + score;
        StartCoroutine(Created());
        
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && retryStartController)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator Created()
    {
        yield return new WaitForSeconds(StartedWait);

        while (true)
        {
            for(int i = 0; i<10; i++)
            {
                Vector3 vector3 = new Vector3(Random.Range(-randomPosition.x, randomPosition.x), 0, randomPosition.z);
                Instantiate(asteroid, vector3, Quaternion.identity);
                yield return new WaitForSeconds(createdWait);
            }
            yield return new WaitForSeconds(loopWait);
            if (gameFinisController)
            {
                break;
            }
        }
    }
    public void ScoreIncrease(int comingScore)
    {
        score += comingScore;
        textScore.text = "Score: " + score;
    }
    public void GameFinished()
    {
        gameFinisController = true;
        textFinished.text = "Oyun bitti.\n\nYeniden başlatmak için 'R' tuşuna basınız. \n\n\nScore: " + score;
        retryStartController = true;
    }

}
