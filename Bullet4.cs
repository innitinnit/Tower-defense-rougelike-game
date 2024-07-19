using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : Bullet
{
    public GameObject hitVfx;//新建一个承载粒子效果的GameObject

    protected override void Start()
    {
        AudioManager.Instance.bullet4Audio.Play();
    }

    protected override void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, cardData.tempCharacterData.moveSpeed * Time.deltaTime);
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
            Instantiate(hitVfx, transform.position, transform.rotation);
        }
    }
}
