using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public LayerMask layermask;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))       //Thanks to various online sources for this raycast code, which took me a solid three hours to get working
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layermask);
            if (hit.collider != null)
            {
                if (hit.transform.GetComponent<Tower>() != null)
                {
                    hit.collider.GetComponent<Tower>().OnClick();
                }
            }
        }
    }
}
