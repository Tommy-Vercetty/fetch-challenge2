using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    /* CHANGE 1:
    Originally, our 'leftLimit' variable was set to '30'. The problem with this is, is that when we launch the game
    and spawn a dog, the dog's 'x-coordinate or x-position is moving to negative infinity. This means that the condition
    of the dog de-spawning at 30 is impossible to be met. Therefore we start by setting our de-spawn WALL at -30. SECONDLY,
    we also want to make sure that the dog's position is set to 'SMALLER THAN' our newly set 'leftLimit' variable as otherwise
    we wouldn't be able to meet that condition
    */
    private float leftLimit = -30;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 

        /* CHANGE 2:
        Because the ball is falling in the y-coordinate and is falling downwards, its y-position is decreasing and going into
        the negatives infinitely unless we de-spawn it. In order to do that the problem was that the ball was only going to be
        destroyed if the 'z' position of the ball was SMALLER THAN the bottom limit. The problem is that while the 'z' position
        slightly changes it is never going to satisfy the 'bottomLimit' condition of -5. Therefore, we just change from '.z' to .y'
        */

        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
