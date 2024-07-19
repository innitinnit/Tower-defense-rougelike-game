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

    // ����// ǹе������η����ӵ���+1���˺�-20%
    public void Buff1(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(1);
        
        damage *= temp.BuffPoint;
        
        // ���η����ӵ���+1��cardmanager��
    }

    // ����
    public void Buff2(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(2);
        // ǹе��������ӵ��˺�+60%
        damage *= temp.BuffPoint;
    }

    // ����
    public void Buff3(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(3);
        // ǹе������ⷢ��һ���ӵ����˺�-30%
        damage *= temp.BuffPoint;
        // ��������߼������ⷢ��һ���ӵ�
    }

    // ��ͨ
    public void Buff4(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(4);
        // ǹе��������ӵ��˺�+30%����͸+1
        damage *= temp.BuffPoint;
        // ��������߼�����͸+1
    }

    // �ɵ���ɢ
    public void Buff5()
    {
        // ǹе����ӵ����й������ѳ�2���μ��ӵ�
        // ��������߼����ӵ����к���ѳ�2���μ��ӵ�
    }

    // ����
    public void Buff6()
    {
        // ǹе����ӵ����й����ը
        // ��������߼����ӵ����к�ը
    }

    // ��͸
    public void Buff7()
    {
        // ǹе����ӵ��ɹᴩ���й���
        // ��������߼����ӵ��ɹᴩ���й���
    }

    // ����ɵ�
    public void Buff8()
    {
        // ǹе����ӵ�����ȼ����
        // ��������߼����ӵ�����ȼ����
    }

    // �ɵ��Ľ�
    public void Buff9()
    {
        // ǹе����ӵ����к�,ÿ�������Ĵμ��ӵ�����4��������
        // ��������߼���ÿ�������Ĵμ��ӵ���4��������
    }

    // �μ��ɵ�����
    public void Buff10(float damage)
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(10);
        // ǹе����μ��ӵ��˺�+100%
        damage *= temp.BuffPoint;
    }

    // ��ɢ�ɵ�����
    public void Buff11(float damage)
    {
        // ǹе�������ɢ�������ӵ��˺�+100%
        //characterData.attackDamage *= 2f;
    }

    // ��ը��ɢ
    public void Buff12()
    {
        // ǹе����ӵ���ը��Χ+80%
        // ��������߼����ӵ���ը��Χ+80%
    }

    // ��������
    public void Buff13()
    {
        // ǹе����ӵ���ը�˺�+80%
        //characterData.attackDamage *= 1.8f;
    }

    // �μ�����
    public void Buff14()
    {
        // ǹе����μ��ӵ����й����ը
        // ��������߼����μ��ӵ����й����ը
    }

    // �ɵ��籩
    public void Buff15()
    {
        var tables = new Tables(LoadTable);
        Gunshot temp = tables.TbGunshot.Get(15);
        // ǹе������ι������ʱ��-30%
        CharacterSOTrans.Instance.characterDatas[1].attackCooling *= temp.BuffPoint;
    }

    private JSONNode LoadTable(string table_name)
    {
        var textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>($"Assets/LubanGen/json/{table_name}.json");
        return JSON.Parse(textAsset.text);
    }
}
