using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("LoseGame", 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            StartCoroutine(LoadScene("intro"));
          
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
           
            StartCoroutine(LoadScene("Win"));
           
        }
    }

    void LoseGame()
    {
       
        StartCoroutine(LoadScene("lose"));
    }

    IEnumerator LoadScene(string level)
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(level);
    }

}
