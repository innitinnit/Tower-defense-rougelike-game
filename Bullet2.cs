using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : Bullet
{
    public GameObject explosionVfx;
    public GameObject hitVfx;//新建一个承载粒子效果的GameObject

    protected override void Start()
    {
        base.Start();

        AudioManager.Instance.bullet2Audio.Play();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            var targetCharacterData = collision.GetComponent<Monster>();
            if (!targetCharacterData.isDead)
            {
                targetCharacterData.characterData.TakeDamage(cardData.tempCharacterData, targetCharacterData.tempCharacterData);
                //Instantiate(explosionVfx, targetCharacterData.transform.position, Quaternion.identity);
            }
            Instantiate(hitVfx, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}
