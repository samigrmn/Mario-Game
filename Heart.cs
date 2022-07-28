using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            if(collision.gameObject.GetComponent<PlayerController>().life<3)
            {
                collision.gameObject.GetComponent<PlayerController>().life++;
                collision.gameObject.GetComponent<PlayerController>().updateLifeText();


                Destroy(gameObject);
            }
        }
    }
}
