using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public CardData_SO cardData;
    public GameObject attackTarget;
    public Rigidbody2D rigidbody2D;

    public Vector2 direction;

    public int id;

    protected virtual void Awake()
    {
        if (AttackManager.Instance.monsters.Count > 0)
        {
            attackTarget = AttackManager.Instance.monsters[0];
        }

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        if (attackTarget != null)
        {
            direction = (attackTarget.transform.position - transform.position).normalized;
        }
        transform.right = direction;
    }

    protected virtual void FixedUpdate()
    {
        rigidbody2D.velocity = direction * cardData.tempCharacterData.moveSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
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
