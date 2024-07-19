using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class PlayerData : Singleton<PlayerData>
{
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int coin = 0;
    [SerializeField] private int diamond = 0;
    [SerializeField] private int unlockStageEasy = 1;
    [SerializeField] private int unlockStageHard = 1;
    [SerializeField] private int stamina = 1000;
    [SerializeField] private int maxStamina = 2000;
    [SerializeField] private string lastClaimDate = "yyyy-MM-dd";
    [SerializeField] private string lastSignInDate = "";

    public InputField logInputField;

    private void Start()
    {
        UpdateLogInputField();
    }

    override protected void Awake()
    {
        base.Awake();
        Load();

    }

    private void UpdateLogInputField()
    {
        string logMessage = "";
        logMessage += "��ҵȼ���" + playerLevel + "\n";
        logMessage += "��ҽ�ң�" + coin + "\n";
        logMessage += "�����ʯ��" + diamond + "\n";
        logMessage += "��ҽ����ؿ���ţ���ģʽ����" + unlockStageEasy + "\n";
        logMessage += "��ҽ����ؿ���ţ�����ģʽ����" + unlockStageHard + "\n";
        logMessage += "�������������" + stamina + "\n";
        logMessage += "������������" + maxStamina + "\n";
        logMessage += "����ϴλ��ÿ�ս��������ڣ�" + lastClaimDate + "\n";
        logMessage += "����ϴλ��100���������ڣ�" + lastSignInDate + "\n";

        if (logInputField != null)
        {
            logInputField.text = logMessage;
            logInputField.interactable = true; // ȷ�� InputField �ɽ���
            logInputField.readOnly = true; // ʹ��ֻ����������ѡ��͸���
        }
        else
        {
            Debug.LogWarning("logInputField is not assigned in the inspector.");
        }
    }

    void PrintPlayerData()
    {
        Debug.Log("��ҵȼ���" + playerLevel);
        Debug.Log("��ҽ�ң�" + coin);
        Debug.Log("�����ʯ��" + diamond);
        Debug.Log("��ҽ����ؿ���ţ���ģʽ����" + unlockStageEasy);
        Debug.Log("��ҽ����ؿ���ţ�����ģʽ����" + unlockStageHard);
        Debug.Log("�������������" + stamina);
        Debug.Log("������������" + maxStamina);
        Debug.Log("����ϴλ��ÿ�ս��������ڣ�" + lastClaimDate);
        Debug.Log("����ϴλ��100���������ڣ�" + lastSignInDate);
    }

    

    public void Save()
    {
        SaveByPlayerPrefs();
        SaveByWXStorage();
    }

    public void Load()
    {
        LoadFromPlayerPrefs();
        LoadFromWXStorage();
        PrintPlayerData();
    }

    void SaveByWXStorage()
    {
        WX.StorageSetIntSync("PlayerLevel", playerLevel);
        WX.StorageSetIntSync("PlayerCoin", coin);
        WX.StorageSetIntSync("PlayerDiamond", diamond);
        WX.StorageSetIntSync("PlayerUnlockStageEasy", unlockStageEasy);
        WX.StorageSetIntSync("PlayerUnlockStageHard", unlockStageHard);
        WX.StorageSetIntSync("PlayerStamina", stamina);
        WX.StorageSetIntSync("PlayerMaxStamina", maxStamina);
        WX.StorageSetStringSync("PlayerLastClaimDate", lastClaimDate);
        WX.StorageSetStringSync("PlayerSignInDate", lastSignInDate);
    }

    void SaveByPlayerPrefs()
    {
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
        PlayerPrefs.SetInt("PlayerCoin", coin);
        PlayerPrefs.SetInt("PlayerDiamond", diamond);
        PlayerPrefs.SetInt("PlayerUnlockStageEasy", unlockStageEasy);
        PlayerPrefs.SetInt("PlayerUnlockStageHard", unlockStageHard);
        PlayerPrefs.SetInt("PlayerStamina", stamina);
        PlayerPrefs.SetInt("PlayerMaxStamina", maxStamina);
        PlayerPrefs.SetString("PlayerLastClaimDate", lastClaimDate);      
        PlayerPrefs.SetString("PlayerSignInDate", lastSignInDate);
        PlayerPrefs.Save();
    }

    void LoadFromWXStorage()
    {
        playerLevel = WX.StorageGetIntSync("PlayerLevel", 1);
        coin = WX.StorageGetIntSync("PlayerCoin", 0);
        diamond = WX.StorageGetIntSync("PlayerDiamond", 0);
        unlockStageEasy = WX.StorageGetIntSync("PlayerUnlockStageEasy", 1);
        unlockStageHard = WX.StorageGetIntSync("PlayerUnlockStageHard", 1);
        stamina = WX.StorageGetIntSync("PlayerStamina", 1000);
        maxStamina = WX.StorageGetIntSync("PlayerMaxStamina", 2000);
        lastClaimDate = WX.StorageGetStringSync("PlayerLastClaimDate", "yyyy-MM-dd");
        lastSignInDate = WX.StorageGetStringSync("PlayerSignInDate", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));

    }

    void LoadFromPlayerPrefs()
    {
        
        playerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);

        coin = PlayerPrefs.GetInt("PlayerCoin", 0);
    
        diamond = PlayerPrefs.GetInt("PlayerDiamond", 0);

        unlockStageEasy = PlayerPrefs.GetInt("PlayerUnlockStageEasy", 1);

        unlockStageHard = PlayerPrefs.GetInt("PlayerUnlockStageHard", 1);
  
        stamina = PlayerPrefs.GetInt("PlayerStamina", 1000);
  
        maxStamina = PlayerPrefs.GetInt("PlayerMaxStamina", 2000);
 
        lastClaimDate = PlayerPrefs.GetString("PlayerLastClaimDate", "yyyy-MM-dd");
  
        lastSignInDate = PlayerPrefs.GetString("PlayerSignInDate", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));
    }

    public string GetLastClaimDate()
    {
        string t = WX.StorageGetStringSync("PlayerLastClaimDate", "yyyy-MM-dd");
        t = lastClaimDate;
        return t;
    }
    public void SetLastClaimDate(string date)
    {
        lastClaimDate = date;
        PlayerPrefs.SetString("PlayerLastClaimDate", lastClaimDate);
        WX.StorageSetStringSync("PlayerLastClaimDate", lastClaimDate);

    }

    public string GetLastSignInDate()
    {
        string t = WX.StorageGetStringSync("PlayerSignInDate", DateTime.UtcNow.Date.ToString("yyyy-MM-dd"));
        t = lastSignInDate;
        return t;
    }
    public void SetLastSignInDate(string date)
    {
        lastSignInDate = date;
        PlayerPrefs.SetString("PlayerSignInDate", lastSignInDate);
        WX.StorageSetStringSync("PlayerSignInDate", lastSignInDate);

    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }
    public void SetPlayerLevel(int num)
    {
        playerLevel += num;
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
        WX.StorageSetIntSync("PlayerLevel", playerLevel);

    }

    public int GetCoin()
    {
        return coin;
    }
    public void SetCoin(int num)
    {
        coin += num;
        PlayerPrefs.SetInt("PlayerCoin", coin);
        WX.StorageSetIntSync("PlayerCoin", coin);

    }

    public int GetDia()
    {
        return diamond;
    }
    public void SetDia(int num)
    {
        diamond += num;
        PlayerPrefs.SetInt("PlayerDiamond", diamond);
        WX.StorageSetIntSync("PlayerDiamond", diamond);

    }

    public int GetUnlockStageEasy()
    {
        return unlockStageEasy;
    }
    public void SetUnlockStageEasy(int num)
    {
        unlockStageEasy = num;
        PlayerPrefs.SetInt("PlayerUnlockStageEasy", unlockStageEasy);
        WX.StorageSetIntSync("PlayerUnlockStageEasy", unlockStageEasy);

    }

    public int GetUnlockStageHard()
    {
        return unlockStageHard;
    }
    public void SetUnlockStageHard(int num)
    {
        unlockStageEasy = num;
        PlayerPrefs.SetInt("PlayerUnlockStageHard", unlockStageHard);
        WX.StorageSetIntSync("PlayerUnlockStageHard", unlockStageHard);

    }

    public int GetMaxStamina()
    {
        int t = maxStamina;
        t = WX.StorageGetIntSync("PlayerMaxStamina", 2000);
        
        return t;
    }

    public int GetStamina()
    {
        int t = WX.StorageGetIntSync("PlayerStamina", 50);
        t = stamina;
        return t;
    }
    public void SetStamina(int num)
    {
        stamina += num;
        PlayerPrefs.SetInt("PlayerStamina", stamina);
        WX.StorageSetIntSync("PlayerStamina", stamina);
        StaminaManager.Instance.stamina = stamina;
    }

}
