using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCard : MonoBehaviour
{
    public float moveSpeed = 2f;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        //Destroy when offscreen
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
