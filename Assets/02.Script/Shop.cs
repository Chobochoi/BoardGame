using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public RectTransform uiGruop;
    public Animator anim;
    
    private Player enterPlayer;

    void Enter(Player player)
    {
        enterPlayer = player;
        uiGruop.anchoredPosition = Vector3.zero;
    }

    void Exit()
    {
        uiGruop.anchoredPosition = Vector3.down * 1000;
    }
}
