using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObjectInteract : MonoBehaviour
{

    Text numKeys, numSKeys, numCloak, numGold, gemOvers;
    Canvas gameCanvas, menuCanvas;
    private string inventory;
    private Collider2D mobjectCollider;
    private int numItem = 0;
     

    private void Start()
    {
        numKeys = GameObject.Find("numKeys").GetComponent<Text>();
        numSKeys = GameObject.Find("numSKeys").GetComponent<Text>();
        numCloak = GameObject.Find("Cloak").GetComponent<Text>();
        numGold = GameObject.Find("numGold").GetComponent<Text>();
        gemOvers = GameObject.Find("GemOver").GetComponent<Text>();
        gameCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        menuCanvas = GameObject.Find("finish").GetComponent<Canvas>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "key")
        {
            numKeys.text = (int.Parse(numKeys.text) + 1).ToString();
            
         
        }
        if (collision.gameObject.tag == "door")
        {
            if (int.Parse(numKeys.text) > 0)
            {
                numKeys.text = (int.Parse(numKeys.text) - 1).ToString();
            }
            else
            {
                mobjectCollider = collision.gameObject.GetComponent<Collider2D>();
                mobjectCollider.isTrigger = false;
                StartCoroutine("Delay");
            }

        }
        if (collision.gameObject.tag == "skey")
        {
            numSKeys.text = (int.Parse(numSKeys.text) + 1).ToString();

        }
        if ( collision.gameObject.tag == "sdoor")
        {
            if (int.Parse(numSKeys.text) > 0)
            {
                numSKeys.text = (int.Parse(numSKeys.text) - 1).ToString();
            }
            else
            {
                mobjectCollider = collision.gameObject.GetComponent<Collider2D>();
                mobjectCollider.isTrigger = false;
                StartCoroutine("Delay");
                Debug.Log("non");
            }


        }
        if (collision.gameObject.tag == "cloak")
        {
            numCloak.text = (int.Parse(numCloak.text) + 1).ToString();

        }
        if (collision.gameObject.tag == "dragon")
        {
            if (int.Parse(numCloak.text) > 0)
            {
                numCloak.text = (int.Parse(numCloak.text) - 1).ToString();
            }
            else
            {
                mobjectCollider = collision.gameObject.GetComponent<Collider2D>();
                mobjectCollider.isTrigger = false;
                StartCoroutine("Delay");
            }

        }

        if (collision.gameObject.tag == "snake")
        {
            StartCoroutine("Death");

        }
        if (collision.gameObject.tag == "300g")
        {
            numGold.text = (int.Parse(numGold.text) + 300).ToString();

        }
        if (collision.gameObject.tag == "200g")
        {
            numGold.text = (int.Parse(numGold.text) + 200).ToString();

        }
        if (collision.gameObject.tag == "chest")
        {
            if (int.Parse(numGold.text) == 500)
            {
                numGold.text = (int.Parse(numGold.text) - 500).ToString();
            }
            else
            {
                mobjectCollider = collision.gameObject.GetComponent<Collider2D>();
                mobjectCollider.isTrigger = false;
                StartCoroutine("Delay");
            }

        }

        if (collision.gameObject.tag == "end")
        {
            gameCanvas.enabled = false;
            menuCanvas.enabled = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mobjectCollider = collision.gameObject.GetComponent<Collider2D>();
        mobjectCollider.isTrigger = false;
      
    }
  public  IEnumerator Death()
    {
        gemOvers.text = "You got et by snek";
        yield return new WaitForSecondsRealtime(2);
        Restart();
    }
  
    public IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(2);
        mobjectCollider.isTrigger = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
        gameCanvas.enabled = true;
        menuCanvas.enabled = false;
    }
}
