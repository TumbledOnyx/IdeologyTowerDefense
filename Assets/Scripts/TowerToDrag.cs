using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerToDrag : MonoBehaviour
{
    public string TowerType;

    public GameObject textPrefab;
    public GameObject selectedPrefab;


    private GameObject selected;
    private GameObject textBox;

    private bool Unlocked;


    void Start()
    {
        GatherImage();
        if (Unlocked == false)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

    }


    void OnMouseEnter()
    {
        if (Unlocked == true)
        {
            float xCoord = transform.position.x;
            float yCoord = transform.position.y;
            xCoord += (float)3.3;
            Vector2 coordXY = new Vector2(xCoord, yCoord);
            GameObject canvas = GameObject.Find("Canvas");
            textBox = Instantiate(textPrefab, canvas.transform);
            textBox.transform.position = coordXY;
            DetermineText();
        }
    }

    public void OnClick()
    {
        if (Unlocked == true)
        {
            Destroy(selected);
            GameObject canvas = GameObject.Find("Canvas");
            selected = Instantiate(selectedPrefab, canvas.transform);
            selected.GetComponent<TowerSelected>().TowerType = TowerType;
        }
    }

    private void OnMouseExit()
    {
        Destroy(textBox);
    }

    void DetermineText()
    {
        switch (TowerType)
        {
            case "Accelerationist":
                textBox.GetComponentInChildren<Text>().text = "The Accelerationist tower costs " + UpgradesAndUnlocks.Instance.AccelerationistCost + " cash, and speeds up towers within it's range";
                break;
            case "AnCap":
                textBox.GetComponentInChildren<Text>().text = "The Anarcho Capitalist tower costs " + UpgradesAndUnlocks.Instance.AnCapCost + " cash, and increases end of round cash.";
                break;
            case "AnCom":
                textBox.GetComponentInChildren<Text>().text = "The Anarcho Communist tower costs " + UpgradesAndUnlocks.Instance.AnComCost + " cash, and slows down nearby centrists.";
                break;
            case "AnMonarchist":
                textBox.GetComponentInChildren<Text>().text = "The Anarcho Monarchist tower costs " + UpgradesAndUnlocks.Instance.AnMonarchistCost + " cash, and buffs a random tower each wave and shoots a piercing exploding projectile.";
                break;
            case "AnPrim":
                textBox.GetComponentInChildren<Text>().text = "The Anarcho Primitivist tower costs " + UpgradesAndUnlocks.Instance.AnPrimCost + " cash, and throws piercing spears.";
                break;
            case "AnSynd":
                textBox.GetComponentInChildren<Text>().text = "The Anarcho Syndicalist tower costs " + UpgradesAndUnlocks.Instance.AnSyndCost + " cash, and creates unions between towers, increasing attack damage.";
                break;
            case "ClassicalLiberal":
                textBox.GetComponentInChildren<Text>().text = "The Classical Liberal tower costs " + UpgradesAndUnlocks.Instance.ClassicalLiberalCost + " cash, and shoots a medium damage splash attack.";
                break;
            case "Communist":
                textBox.GetComponentInChildren<Text>().text = "The Communist tower costs " + UpgradesAndUnlocks.Instance.CommunistCost + " cash, and has medium damage, speed, and health.";
                break;
            case "DemSoc":
                textBox.GetComponentInChildren<Text>().text = "The Democratic Socialist tower costs " + UpgradesAndUnlocks.Instance.DemSocCost + " cash, and has a long range sniper attack.";
                break;
            case "Fascist":
                textBox.GetComponentInChildren<Text>().text = "The Fascist tower costs " + UpgradesAndUnlocks.Instance.FascistCost + " cash, and has a slow shooting poison attack.";
                break;
            case "Mutualist":
                textBox.GetComponentInChildren<Text>().text = "The Mutualist tower costs " + UpgradesAndUnlocks.Instance.MutualistCost + " cash, and shields nearby towers from centrist attacks.";
                break;
            case "NazBol":
                textBox.GetComponentInChildren<Text>().text = "The National Bolshevik tower costs " + UpgradesAndUnlocks.Instance.NazBolCost + " cash, and has a sweeping scythe attack.";
                break;
            case "Nazi":
                textBox.GetComponentInChildren<Text>().text = "The Nazi tower costs " + UpgradesAndUnlocks.Instance.NaziCost + " cash, and has a flamethrower attack.";
                break;
            case "Platformist":
                textBox.GetComponentInChildren<Text>().text = "The Platformist tower costs " + UpgradesAndUnlocks.Instance.PlatformistCost + " cash, and boosts the range of nearby towers.";
                break;
            case "Posadist":
                textBox.GetComponentInChildren<Text>().text = "The Posadist tower costs " + UpgradesAndUnlocks.Instance.PosadistCost + " cash, and creates UFOs that heal towers, the base, and collect money.";
                break;
            default:
                textBox.GetComponentInChildren<Text>().text = "ERROR";
                break;
        }
    }

    void GatherImage()
    {
        Image image = GetComponent<Image>();
        if (TowerType == "Accelerationist" && UpgradesAndUnlocks.Instance.AccelerationistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Accelerationist");
            Unlocked = true;
        }
        else if (TowerType == "AnCap" && UpgradesAndUnlocks.Instance.AnCapUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Capitalist"); 
            Unlocked = true;
        }
        else if (TowerType == "AnCom" && UpgradesAndUnlocks.Instance.AnComUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Communist");
            Unlocked = true;
        }
        else if (TowerType == "AnMonarchist" && UpgradesAndUnlocks.Instance.AnMonarchistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Monarchist");
            Unlocked = true;
        }
        else if (TowerType == "AnPrim" && UpgradesAndUnlocks.Instance.AnPrimUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Primitivist");
            Unlocked = true;
        }
        else if (TowerType == "AnSynd" && UpgradesAndUnlocks.Instance.AnSyndUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Anarcho Syndaclist");
            Unlocked = true;
        }
        else if (TowerType == "ClassicalLiberal" && UpgradesAndUnlocks.Instance.ClassicalLiberalUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Classical Liberal");
            Unlocked = true;
        }
        else if (TowerType == "Communist" && UpgradesAndUnlocks.Instance.CommunistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Communist");
            Unlocked = true;
        }
        else if (TowerType == "DemSoc" && UpgradesAndUnlocks.Instance.DemSocUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Democratic Socialist");
            Unlocked = true;
        }
        else if (TowerType == "Fascist" && UpgradesAndUnlocks.Instance.FascistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Fascist");
            Unlocked = true;
        }
        else if (TowerType == "Mutualist" && UpgradesAndUnlocks.Instance.MutualistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Mutualist");
            Unlocked = true;
        }
        else if (TowerType == "NazBol" && UpgradesAndUnlocks.Instance.NazBolUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/NazBol");
            Unlocked = true;
        }
        else if (TowerType == "Nazi" && UpgradesAndUnlocks.Instance.NaziUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Nazi");
            Unlocked = true;
        }
        else if (TowerType == "Platformist" && UpgradesAndUnlocks.Instance.PlatformistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Platformist");
            Unlocked = true;
        }
        else if (TowerType == "Posadist" && UpgradesAndUnlocks.Instance.PosadistUnlocked == true)
        {
            image.sprite = Resources.Load<Sprite>("Sprites/Towers/TowerPNGs/Posadist");
            Unlocked = true;
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("Sprites/UI/locked");
            Unlocked = false;
        }
    }

}