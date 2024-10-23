using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    int chestCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        LootBox box = FindAnyObjectByType<LootBox>();
        if (box) box.OnBoxOpen += CounterIncrement;
    }

    private void CounterIncrement(GameObject[] obj)
    {
        chestCounter++;
        if(chestCounter == 1)
        {
            Debug.Log("You Win");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
