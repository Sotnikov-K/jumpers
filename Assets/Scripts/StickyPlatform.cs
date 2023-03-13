using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   
    
    
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //OnCollisionEnter2D отличается от OnTriggerEnter2D - онколижн от сопракосновнеия колизии , онтрегерд если галочка трегер включена

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
