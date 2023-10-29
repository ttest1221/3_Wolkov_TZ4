using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Car" || collision.transform.tag == "Money")
            Destroy(collision.gameObject);
    }
}
