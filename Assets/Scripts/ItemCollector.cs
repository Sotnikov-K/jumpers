using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{

    private int cherries = 0;

    [SerializeField] private TextMeshProUGUI cherriesText;

    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Cherry")) 
        {
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log("Cherries : " + cherries);

            collectSoundEffect.Play();


            cherriesText.text = "cherries: " + cherries;
            //Debug.Log(cherries);

        }
    }
}
