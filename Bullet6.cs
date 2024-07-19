using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet6 : Bullet
{
    protected override void Start()
    {
        AudioManager.Instance.bullet5Audio.Play();
    }

    

  

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            var targetCharacterData = collision.GetComponent<Monster>();
            if (!targetCharacterData.isDead)
            {
                targetCharacterData.characterData.TakeDamage(cardData.tempCharacterData, targetCharacterData.tempCharacterData);
            }


            


            Destroy(gameObject);
        }
    }
}
