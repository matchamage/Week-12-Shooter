using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Big : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime * 7f);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
