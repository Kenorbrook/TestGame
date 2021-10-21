using System.Collections;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
   public Transform[] Blocks;

    private void Start()
    {
        Blocks = GetComponentsInChildren<Transform>();
        for(int i = 1; i < Blocks.Length; i++)
        {
            Blocks[i].gameObject.SetActive(false);
        }
    }

    public void Spawn()
    {
        for(int i=1; i < Blocks.Length; i++)
        {
            if (!Blocks[i].gameObject.activeSelf)
            {
                Blocks[i].gameObject.SetActive(true);
                Blocks[i].position = new Vector3(10f, Random.Range(-1,2),0);
                StartCoroutine(MoveBlock(Blocks[i]));
                break;
            }
        }
    }


    IEnumerator MoveBlock(Transform Go)
    {
        while (Go.gameObject.activeSelf && !GameManager.isGamePaused)
        {
            Go.position +=new Vector3(-1 * Time.deltaTime*GameManager.speed, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        if (GameManager.isGamePaused)
        {
            for (int i = 1; i < Blocks.Length; i++)
            {
                Blocks[i].gameObject.SetActive(false);
            }
        }
    }
}
