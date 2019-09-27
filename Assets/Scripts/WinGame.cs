using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoseGame", 90);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("intro");
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            SceneManager.LoadScene("Win");
        }
    }

    void LoseGame()
    {
        SceneManager.LoadScene("Lose");
    }
}
