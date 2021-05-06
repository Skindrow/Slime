using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDO : MonoBehaviour
{


    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DamageObject")
        {
            Destroy(collision.gameObject);
        }
    }
}
