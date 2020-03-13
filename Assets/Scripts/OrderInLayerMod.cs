using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayerMod : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Path";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
