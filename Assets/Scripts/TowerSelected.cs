using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerSelected : MonoBehaviour
{
    public string TowerType;
    public int cost;
    public bool isPlacable;
    public bool isColliding;

    GameObject towerPrefab;

    GameObject tower;
    private int collidingBodyNum;

    void Start()
    {
        GatherImage();
        GatherCost();
        GatherPrefab();
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }


    void Update()
    {
        if (collidingBodyNum == 0 && GlobalVars.cash >= cost)
        {
            isPlacable = true;
        }
        else
        {
            isPlacable = false;
        }
        if (isPlacable == false)
        {
            GetComponent<Image>().color = new Color32(255, 100, 100, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
        if (Input.GetKeyDown("escape") || Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
        if (Input.GetMouseButton(0) && isPlacable == true)
        {
            GlobalVars.cash -= cost;
            GameObject canvas = GameObject.Find("Canvas");
            tower = Instantiate(towerPrefab);
            tower.transform.position = transform.position;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidingBodyNum += 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidingBodyNum -= 1;
    }

    void GatherCost()
    {
        switch (TowerType)
        {
            case "Accelerationist":
                cost = UpgradesAndUnlocks.Instance.AccelerationistCost;
                break;
            case "AnCap":
                cost = UpgradesAndUnlocks.Instance.AnCapCost;
                break;
            case "AnCom":
                cost = UpgradesAndUnlocks.Instance.AnComCost;
                break;
            case "AnMonarchist":
                cost = UpgradesAndUnlocks.Instance.AnMonarchistCost;
                break;
            case "AnPrim":
                cost = UpgradesAndUnlocks.Instance.AnPrimCost;
                break;
            case "AnSynd":
                cost = UpgradesAndUnlocks.Instance.AnSyndCost;
                break;
            case "ClassicalLiberal":
                cost = UpgradesAndUnlocks.Instance.ClassicalLiberalCost;
                break;
            case "Communist":
                cost = UpgradesAndUnlocks.Instance.CommunistCost;
                break;
            case "DemSoc":
                cost = UpgradesAndUnlocks.Instance.DemSocCost;
                break;
            case "Fascist":
                cost = UpgradesAndUnlocks.Instance.FascistCost;
                break;
            case "Mutualist":
                cost = UpgradesAndUnlocks.Instance.MutualistCost;
                break;
            case "NazBol":
                cost = UpgradesAndUnlocks.Instance.NazBolCost;
                break;
            case "Nazi":
                cost = UpgradesAndUnlocks.Instance.NaziCost;
                break;
            case "Platformist":
                cost = UpgradesAndUnlocks.Instance.PlatformistCost;
                break;
            case "Posadist":
                cost = UpgradesAndUnlocks.Instance.PosadistCost;
                break;
            default:
                break;
        }
    }

    void GatherImage()
    {
        Image image = GetComponent<Image>();
        if (TowerType == "Accelerationist" && UpgradesAndUnlocks.Instance.AccelerationistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Accelerationist");
        }
        else if (TowerType == "AnCap" && UpgradesAndUnlocks.Instance.AnCapUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Capitalist");
        }
        else if (TowerType == "AnCom" && UpgradesAndUnlocks.Instance.AnComUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Communist");
        }
        else if (TowerType == "AnMonarchist" && UpgradesAndUnlocks.Instance.AnMonarchistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Monarchist");
        }
        else if (TowerType == "AnPrim" && UpgradesAndUnlocks.Instance.AnPrimUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Primitivist");
        }
        else if (TowerType == "AnSynd" && UpgradesAndUnlocks.Instance.AnSyndUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Syndaclist");
        }
        else if (TowerType == "ClassicalLiberal" && UpgradesAndUnlocks.Instance.ClassicalLiberalUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Classical Liberal");
        }
        else if (TowerType == "Communist" && UpgradesAndUnlocks.Instance.CommunistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Communist");
        }
        else if (TowerType == "DemSoc" && UpgradesAndUnlocks.Instance.DemSocUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Democratic Socialist");
        }
        else if (TowerType == "Fascist" && UpgradesAndUnlocks.Instance.FascistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Fascist");

        }
        else if (TowerType == "Mutualist" && UpgradesAndUnlocks.Instance.MutualistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Mutualist");

        }
        else if (TowerType == "NazBol" && UpgradesAndUnlocks.Instance.NazBolUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/NazBol");
        }
        else if (TowerType == "Nazi" && UpgradesAndUnlocks.Instance.NaziUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Nazi");
        }
        else if (TowerType == "Platformist" && UpgradesAndUnlocks.Instance.PlatformistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Platformist");
        }
        else if (TowerType == "Posadist" && UpgradesAndUnlocks.Instance.PosadistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Posadist");
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("Sprites/UI/locked");
        }
    }

    void GatherPrefab()
    {
        if (TowerType == "Accelerationist" && UpgradesAndUnlocks.Instance.AccelerationistUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/Accelerationist");
        }
        else if (TowerType == "AnCap" && UpgradesAndUnlocks.Instance.AnCapUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/AnCap");
        }
        else if (TowerType == "AnCom" && UpgradesAndUnlocks.Instance.AnComUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/AnCom");
        }
        else if (TowerType == "AnMonarchist" && UpgradesAndUnlocks.Instance.AnMonarchistUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/AnMonarchist");
        }
        else if (TowerType == "AnPrim" && UpgradesAndUnlocks.Instance.AnPrimUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/AnPrim");
        }
        else if (TowerType == "AnSynd" && UpgradesAndUnlocks.Instance.AnSyndUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/AnSynd");
        }
        else if (TowerType == "ClassicalLiberal" && UpgradesAndUnlocks.Instance.ClassicalLiberalUnlocked == true)
        {

        }
        else if (TowerType == "Communist" && UpgradesAndUnlocks.Instance.CommunistUnlocked == true)
        {

        }
        else if (TowerType == "DemSoc" && UpgradesAndUnlocks.Instance.DemSocUnlocked == true)
        {
            towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/DemSoc");
        }
        else if (TowerType == "Fascist" && UpgradesAndUnlocks.Instance.FascistUnlocked == true)
        {

        }
        else if (TowerType == "Mutualist" && UpgradesAndUnlocks.Instance.MutualistUnlocked == true)
        {

        }
        else if (TowerType == "NazBol" && UpgradesAndUnlocks.Instance.NazBolUnlocked == true)
        {

        }
        else if (TowerType == "Nazi" && UpgradesAndUnlocks.Instance.NaziUnlocked == true)
        {

        }
        else if (TowerType == "Platformist" && UpgradesAndUnlocks.Instance.PlatformistUnlocked == true)
        {

        }
        else if (TowerType == "Posadist" && UpgradesAndUnlocks.Instance.PosadistUnlocked == true)
        {

        }
        else
        {

        }
    }
}
