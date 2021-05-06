using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
}
