using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemCollection : MonoBehaviour
{
    private int oranges = 0;
    public TextMeshProUGUI scoreText;

    public AudioSource collectionSound;
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.CompareTag("Orange"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            oranges++;
            scoreText.text = "Score: " + oranges;
        }
   }
}
