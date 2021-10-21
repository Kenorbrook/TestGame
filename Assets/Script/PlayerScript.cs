using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   public int gravity= -1;
   public float speed= 1;
    static PlayerScript Player = null;
    private void Update()
    {
        transform.position += new Vector3(0, speed*gravity*Time.deltaTime, 0);
        
    }

    private void Start()
    {
        if (Player == null)
        { 
            Player = this; 
        }
        else 
        { 
            Destroy(Player.gameObject);
            Player = this;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Block")
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().LoseGame();
            gravity = 0;
        }
    }
}
