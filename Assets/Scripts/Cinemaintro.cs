using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cinemaintro : MonoBehaviour
{
    public VideoPlayer vplayer;
    public VideoClip videoloop;
    
    // Start is called before the first frame update
    void Start()
    {
        vplayer.loopPointReached += EndReached;

        Invoke("DelayPlay", 2);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vplayer.clip = videoloop;
        vplayer.isLooping = true;
        vplayer.Play();
        vplayer.loopPointReached -= EndReached;
    }

    void DelayPlay()
    {
        vplayer.Play();

    }
}
