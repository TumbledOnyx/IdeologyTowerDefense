using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapSelectBox : MonoBehaviour
{
    public Image image;

    public string ImageType;

    public Sprite CommunistMap;
    public Sprite FascistMap;
    public Sprite AnComMap;
    public Sprite AnCapMap;


    void Start()
    {
        image = GetComponent<Image>();
    }
    public void ChangeMap(string MapChoice)
    {
        if (MapChoice == "Communist")
        {
            image.sprite = CommunistMap;
            ImageType = "Communist";
        }
        if (MapChoice == "Fascist")
        {
            image.sprite = FascistMap;
            ImageType = "Fascist";
        }
        if (MapChoice == "AnCom")
        {
            image.sprite = AnComMap;
            ImageType = "AnCom";
        }
        if (MapChoice == "AnCap")
        {
            image.sprite = AnCapMap;
            ImageType = "AnCap";
        }
    }
    public void OnClick()
    {
        if (ImageType == "Communist")
        {
            SceneManager.LoadScene("AuthleftMap");
        }
        if (ImageType == "Fascist")
        {

        }
        if (ImageType == "AnCom")
        {

        }
        if (ImageType == "AnCap")
        {

        }
    }
}
