using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardVaules = new int[10];
    
    void Start()
    {
        
    }

    void GetCardValues()
    {
        int num = 0;
        
        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
        }

    }
}
