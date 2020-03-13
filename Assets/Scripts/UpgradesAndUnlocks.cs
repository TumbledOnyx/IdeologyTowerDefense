using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesAndUnlocks : MonoBehaviour
{
    //Singleton Pattern from http://thedebuglog.com/2016/02/17/why-you-should-start-using-singletons-in-unity/

    public bool AccelerationistUnlocked;
    public bool AnCapUnlocked;
    public bool AnComUnlocked;
    public bool AnMonarchistUnlocked;
    public bool AnPrimUnlocked;
    public bool AnSyndUnlocked;
    public bool ClassicalLiberalUnlocked;           //Stores unlocked status for all towers
    public bool CommunistUnlocked;
    public bool DemSocUnlocked;
    public bool FascistUnlocked;
    public bool MutualistUnlocked;
    public bool NazBolUnlocked;
    public bool NaziUnlocked;
    public bool PlatformistUnlocked;
    public bool PosadistUnlocked;

    public int AccelerationistCost;
    public int AnCapCost;
    public int AnComCost;
    public int AnMonarchistCost;
    public int AnPrimCost;
    public int AnSyndCost;
    public int ClassicalLiberalCost;
    public int CommunistCost;                    //Stores cost stat for all towers
    public int DemSocCost;
    public int FascistCost;
    public int MutualistCost;
    public int NazBolCost;
    public int NaziCost;
    public int PlatformistCost;
    public int PosadistCost;

    public int AccelerationistHealth;
    public int AnCapHealth;
    public int AnComHealth;
    public int AnMonarchistHealth;
    public int AnPrimHealth;
    public int AnSyndHealth;
    public int ClassicalLiberalHealth;
    public int CommunistHealth;               //Stores health stat for all towers
    public int DemSocHealth;
    public int FascistHealth;
    public int MutualistHealth;
    public int NazBolHealth;
    public int NaziHealth;
    public int PlatformistHealth;
    public int PosadistHealth;

    public int AnMonarchistAttackDamage;
    public int AnPrimAttackDamage;
    public int ClassicalLiberalAttackDamage;
    public int CommunistAttackDamage;
    public int DemSocAttackDamage;           //Stores attack damage for all aplicable towers
    public int FascistAttackDamage;
    public int NazBolAttackDamage;
    public int NaziAttackDamage;

    public float AnComSpeed;
    public float AnMonarchistSpeed;
    public float AnPrimSpeed;
    public float ClassicalLiberalSpeed;         //Stores attack speed for all aplicable towers
    public float CommunistSpeed;
    public float DemSocSpeed;
    public float FascistSpeed;
    public float NazBolSpeed;

    public int AccelerationistRange;
    public int AnComRange;
    public int AnMonarchistRange;
    public int AnPrimRange;
    public int AnSyndRange;
    public int ClassicalLiberalRange;
    public int CommunistRange;               //Stores range for all applicable towers
    public int FascistRange;
    public int MutualistRange;
    public int NazBolRange;
    public int NaziRange;
    public int PlatformistRange;
    public int PosadistRange;

    public int score;

    void Awake()            //Part of Singleton Pattern
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static UpgradesAndUnlocks Instance { get; private set; }     //Part of Singleton Pattern
}