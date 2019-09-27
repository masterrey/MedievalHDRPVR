using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinemaExit : MonoBehaviour
{
    public VideoPlayer vplayer;
    

    // Start is called before the first frame update
    void Start()
    {
        if(vplayer)
        vplayer.loopPointReached += EndReached;

    

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("intro");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scape01");


        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("intro");
    }

    void DelayPlay()
    {
       

    }
}
