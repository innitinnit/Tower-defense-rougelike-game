using cfg;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunSkillBuff : Singleton<GunSkillBuff>
{
    

    private void Start()
    {
        
        
    }

    // 齐射// 枪械射击单次发射子弹数+1，伤害-20%
    public void Buff1(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(1);
        
        damage *= temp.BuffPoint;
        
        // 单次发射子弹数+1在cardmanager里
    }

    // 增幅
    public void Buff2(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(2);
        // 枪械射击单发子弹伤害+60%
        damage *= temp.BuffPoint;
    }

    // 连发
    public void Buff3(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(3);
        // 枪械射击额外发射一次子弹，伤害-30%
        damage *= temp.BuffPoint;
        // 这里添加逻辑：额外发射一次子弹
    }

    // 贯通
    public void Buff4(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(4);
        // 枪械射击单发子弹伤害+30%，穿透+1
        damage *= temp.BuffPoint;
        // 这里添加逻辑：穿透+1
    }

    // 飞弹扩散
    public void Buff5()
    {
        // 枪械射击子弹命中怪物后分裂出2个次级子弹
        // 这里添加逻辑：子弹命中后分裂出2个次级子弹
    }

    // 爆破
    public void Buff6()
    {
        // 枪械射击子弹命中怪物后爆炸
        // 这里添加逻辑：子弹命中后爆炸
    }

    // 穿透
    public void Buff7()
    {
        // 枪械射击子弹可贯穿所有怪物
        // 这里添加逻辑：子弹可贯穿所有怪物
    }

    // 火焰飞弹
    public void Buff8()
    {
        // 枪械射击子弹可引燃怪物
        // 这里添加逻辑：子弹可引燃怪物
    }

    // 飞弹四溅
    public void Buff9()
    {
        // 枪械射击子弹命中后,每个产生的次级子弹将向4个方向发射
        // 这里添加逻辑：每个产生的次级子弹向4个方向发射
    }

    // 次级飞弹增幅
    public void Buff10(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(10);
        // 枪械射击次级子弹伤害+100%
        damage *= temp.BuffPoint;
    }

    // 扩散飞弹增幅
    public void Buff11(float damage)
    {
        // 枪械射击因扩散产生的子弹伤害+100%
        //characterData.attackDamage *= 2f;
    }

    // 爆炸扩散
    public void Buff12()
    {
        // 枪械射击子弹爆炸范围+80%
        // 这里添加逻辑：子弹爆炸范围+80%
    }

    // 爆破增幅
    public void Buff13()
    {
        // 枪械射击子弹爆炸伤害+80%
        //characterData.attackDamage *= 1.8f;
    }

    // 次级爆破
    public void Buff14()
    {
        // 枪械射击次级子弹命中怪物后爆炸
        // 这里添加逻辑：次级子弹命中怪物后爆炸
    }

    // 飞弹风暴
    public void Buff15()
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(15);
        // 枪械射击两次攻击间隔时间-30%
        CharacterSOTrans.Instance.characterDatas[1].attackCooling *= temp.BuffPoint;
    }

    private JSONNode LoadTable(string table_name)
    {
        var textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>($"Assets/LubanGen/json/{table_name}.json");
        return JSON.Parse(textAsset.text);
    }
}
