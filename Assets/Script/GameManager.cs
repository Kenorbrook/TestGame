using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject Wall;
    static Coroutine MovingWall;
    static Coroutine Acc;
    int tryCount = 0;
    DateTime start;
    MovingMap movingMap;
    GameObject Player;
    SpawnBlock Sb;
   public static float speed = 1f;
   [SerializeField] GameObject LostPanel;
    static public bool isGamePaused=false;
    // Start is called before the first frame update
    void Start()
    {
        Sb = GameObject.Find("Blocks").GetComponent<SpawnBlock>();
       Wall = GameObject.FindGameObjectWithTag("Wall");
       movingMap = new MovingMap();
        StartGame();
    }

    public void StartGame()
    {
        if(Difficult.diffNow== Difficult.diff.Easy)
        {
            speed = 1f;

        }
        else if(Difficult.diffNow == Difficult.diff.Normal)
        {
            speed = 2f;
        }
        else if(Difficult.diffNow == Difficult.diff.Hard)
        {
            speed = 3f;
        }
        start = DateTime.Now;
        MovingWall = StartCoroutine(movingMap.MoveBackGround(Wall, speed, Sb));
       Acc= StartCoroutine(AcceleratePleyer());
        Player = (GameObject)Instantiate(Resources.Load("Player") );
        Player.GetComponent<Rigidbody2D>().inertia = 0;
        tryCount++;
        isGamePaused = false;
    }

    public void LoseGame()
    {
        LostPanel.SetActive(true);
        var text = LostPanel.GetComponentsInChildren<Text>();
        TimeSpan tp = DateTime.Now - start;
        string min = tp.Minutes > 0 ? tp.Minutes.ToString()+":"+tp.Seconds : $"{tp.Seconds}с";
        text[1].text = $"Ваше время: {min}";
        text[2].text = $"Попыток: {tryCount}";
        isGamePaused = true;
        StopCoroutine(MovingWall);
        StopCoroutine(Acc);
    }

    IEnumerator AcceleratePleyer()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)Difficult.diffNow);
            Player.GetComponent<PlayerScript>().speed += 0.5f;
        }
    }

    public void ChangeGravity(Image image)
    {
        Player.GetComponent<PlayerScript>().gravity= -Player.GetComponent<PlayerScript>().gravity;


    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.SetActive(false);
        }
    }


}
