using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMaker : MonoBehaviour
{
    public GameObject myPrefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            Instantiate(myPrefab, new Vector3(40, 4, 0), Quaternion.identity);
            Destroy(gameObject);
        }

            
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
   

    // This script will simply instantiate the Prefab when the game starts.
   
}
        }
    

