using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambilight : MonoBehaviour
{

   
    Material mymat;
    Rect rectReadPicture;
    public Texture2D texture;
    public RenderTexture renderTexture;
    int count_x = 8 * 10;
    int count_y = 8 * 10;
    // Start is called before the first frame update
    void Start()
    {

        texture = new Texture2D(count_x, count_y, TextureFormat.RGB24, false);

        Rect rectReadPicture = new Rect(0, 0, count_x, count_y);

        

        mymat = GetComponent<Renderer>().material;
        //mymat.SetColor("_EmissiveColor", Color.red);


    }
   
    
    
    // Update is called once per frame
    void Update()
    {
        RenderTexture.active = renderTexture;
        texture.ReadPixels(rectReadPicture, 0, 0);
       Color c= texture.GetPixel(0,0);
        mymat.SetColor("_EmissiveColor", c);


    }
}
