using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {         
            GameManager.globalColisionAttack = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.globalColisionAttack = true;
        }
    }

  
}
