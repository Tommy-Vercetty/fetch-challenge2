using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomBall();
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        /* CHANGE 3:
        The same blue-coloured ball was being spawned. This is because, while all the types of balls were in the array, only the ball
        in the Array Index[0] was being spawned. Therefore, there was no way for the red or green ones to be spwaned. To solve this,
        we want to traverse through the array randomly, and not output a specific ball. We use the Random.Range to range the ball
        spawning from the First Ball Type found at position 0, to the last one using the array.Length. This is better as if the size
        of the array was to change, we don't have to change that parameter from 2 to 3, in the case of one more type of ball being added
        */
        // instantiate ball at random spawn location
        int ballNumber = Random.Range(0, ballPrefabs.Length);

        Instantiate(ballPrefabs[ballNumber], spawnPos, ballPrefabs[ballNumber].transform.rotation);

        /* BONUS CHANGE 4:
        Previously, the interval between each ball spawning had been set to 4 seconds as stored by the 'spawnInterval' variable
        at the top. This variable was then repeatedly used when using the 'InvokeRepeating' function in C#. In order to customise
        the time interval in-between balls spawning, we use a different function called 'Invoke' and we use it in our 'SpawnRandomBall()'
        method. We then set a RANDOM interval in seconds (We use floats, as we don't want the balls to be limited to 1, 2, 3 seconds but
        can spawn at E.x. 4.5 seconds, 1.3 seconds etc.) for the balls to spawn in.
        */
        Invoke("SpawnRandomBall", Random.Range(1f, 5f));
    }

}
