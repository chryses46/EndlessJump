using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class DeathZone : MonoBehaviour
{
    public Text gameOverText;


    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverText.gameObject.SetActive(true);
        Debug.Log(collision.gameObject.name);
    }
}
