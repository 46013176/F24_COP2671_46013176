using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestOpenSound : MonoBehaviour
{
    AudioSource source;
    BoxCollider collision;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        collision = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.Play();
        }
    }
}
