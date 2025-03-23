using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if(transform.position.y <= -height)
        {
            transform.position += new Vector3(0, height * 2, 0);
        }
    }
}
