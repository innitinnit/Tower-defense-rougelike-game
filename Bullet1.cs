using cfg;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet1 : Bullet
{
    public GameObject explosionVfx;
    public GameObject hitVfx;//新建一个承载粒子效果的GameObject
    public CharacterData_SO explosion1;
    
    private Tables tables;
    //private Vector3 exploScale;

    protected override void Start()
    {
        base.Start();
        tables = new Tables(LoadTable);
        AudioManager.Instance.bullet1Audio.Play();
        Vector3 exploScale = explosionVfx.transform.localScale;
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
            GameObject instantiatedBro = Instantiate(hitVfx, transform.position, transform.rotation);

            
            if(Mage1.Instance.noDestroy)
                Destroy(gameObject);
            //if(Mage1.Instance.exploDamageUp)
            //{
            //    Gunshot temp = tables.TbGunshot.Get(13);
            //    explosion1.attackDamage *= temp.BuffPoint;
            //}
            //if (Mage1.Instance.exploScaleUp)
            //{
            //    Gunshot temp = tables.TbGunshot.Get(12);
                
            //    explosionVfx.transform.localScale *= temp.BuffPoint;
            //}


            if (Mage1.Instance.hasExplosion)
                Instantiate(explosionVfx, targetCharacterData.transform.position, Quaternion.identity);



        }
    }

    private JSONNode LoadTable(string table_name)
    {
        var textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>($"Assets/LubanGen/json/{table_name}.json");
        return JSON.Parse(textAsset.text);
    }

}
