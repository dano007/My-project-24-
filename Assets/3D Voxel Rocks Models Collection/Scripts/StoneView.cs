using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneView : MonoBehaviour
{
    public static StoneView instance;
    public Material MatCurent;

    public Texture2D[] Textures;
    public GameObject[] Stones;
    public Text text;
    public float Speed;
    private int index;
   
   
    public void Spawn()
    {
        int ind=0;
        for(int x = 0; x <8;x++)
        {
            for (int y = 0; y < 10;y++)
            {
                if (ind< Stones.Length)
                {
                    GameObject clone = Stones[ind];
                    clone.transform.position = new Vector3(x * 4, 1, y * 4);
                    clone.AddComponent<RotationRock>();
                }
                ind++;
            }
        }
    } 
    //Next ship button
    public void Next()
    {
        

        if ((index+1)< Textures.Length)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        MatCurent.mainTexture = Textures[index];
       
        text.text = MatCurent.mainTexture.name;
       
          
    }
    //Previous ship button
    public void Previous()
    {
        if ((index + 1) < Textures.Length)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        MatCurent.mainTexture = Textures[index];

        text.text = MatCurent.mainTexture.name;
       
       
    }
    void Start()
    {
        instance = this;
        Spawn();
    }

   
}
