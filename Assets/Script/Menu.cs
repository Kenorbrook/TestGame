using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    AsyncOperation async;
    Image BlackPan;

    private void Start()
    {
        BlackPan = GameObject.Find("BlackPan").GetComponent<Image>();
        BlackPan.gameObject.SetActive(false);
    
    }
    public void StartButt()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        BlackPan.gameObject.SetActive(true);
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {
        float alpha = BlackPan.color.a;
        while (BlackPan.color.a <0.9)
        {
          
            BlackPan.color = new Color(BlackPan.color.r, BlackPan.color.g, BlackPan.color.b, alpha);
            alpha += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;

    }
    
}
