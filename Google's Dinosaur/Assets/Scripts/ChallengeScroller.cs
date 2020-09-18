using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeScroller : MonoBehaviour
{
    //array to mimic sequence of challenges
    public GameObject[] challenges;
    public float scrollSpeed = 10f;
    
    //starting deploying point
    public Transform challengeSpawnPoint;


    int index;

    public float counter = 0f;


    // Speed variables :
    public float accelerationTime = 6;
    private float minSpeed=8.85f;
    private float time;
    float maxSpeed = 30f;




    void GenerateChallenges()
    {
        index = Random.Range(0, challenges.Length); //needs to be called in start/awake

        //Debug.Log(index);

        
        //MIDDLE BIRD
        if (index == 4)
            challengeSpawnPoint.position = new Vector3(challengeSpawnPoint.position.x, -1.83f, challengeSpawnPoint.position.z);
        
        //TOP BIRD
        else if (index==5)
            challengeSpawnPoint.position = new Vector3(challengeSpawnPoint.position.x, 2f, challengeSpawnPoint.position.z);       

        //CACTI
        else
            challengeSpawnPoint.position = new Vector3(challengeSpawnPoint.position.x, -2.58f, challengeSpawnPoint.position.z);




        GameObject newChallenge = Instantiate(challenges[index], challengeSpawnPoint.position, Quaternion.identity);   //(Range, Position, Quaternion)  Quaternion.identity no rotation    }
        newChallenge.transform.parent = transform;
        counter = 2f; //time gap
    }
    
    
    void ScrollChallenge(GameObject currentChallenge)
    {
        currentChallenge.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        scrollSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
        time += Time.deltaTime;

    }
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        GenerateChallenges();
        
    }

    // Update is called once per frame
    void Update()
    {       
        
        if (counter <= 0)
        {
            GenerateChallenges();
        }

        else
        {
            counter -= Time.deltaTime;
        }

        GameObject CurrentChild;
        for (int i=0; i < transform.childCount; i++)
        {
            CurrentChild = transform.GetChild(i).gameObject;
            ScrollChallenge(CurrentChild);

            
            //Destroy object once it goes out of frame

            if (CurrentChild.transform.position.x<=-10f)
            {
                Destroy(CurrentChild);
            }
        }
    
    
    
    }





    


}
