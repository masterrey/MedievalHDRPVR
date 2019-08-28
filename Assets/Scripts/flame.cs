using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
    public float factor;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        InvokeRepeating("Flame", 0, 0.1f);
    }

    // Update is called once per frame
    void Flame()
    {
        transform.position=new Vector3(startpos.x+Random.Range(-factor, factor),
            startpos.y + Random.Range(-factor, factor),
            startpos.z + Random.Range(-factor, factor));
    }
}
