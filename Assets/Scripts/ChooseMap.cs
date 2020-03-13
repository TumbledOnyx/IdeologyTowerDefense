using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMap : MonoBehaviour
{
    public string MapType;
    public GameObject MapObject;
    public MapSelectBox mapselectbox;

    public void OnClick()
    {
        MapObject = GameObject.Find("Map");
        mapselectbox = MapObject.GetComponent<MapSelectBox>();
        mapselectbox.ChangeMap(MapType);
    }
}
