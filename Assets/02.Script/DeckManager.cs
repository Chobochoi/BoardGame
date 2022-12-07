using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [SerializeField] public Button plusCardBtn;
    [SerializeField] public Button coin1Btn;
    [SerializeField] public Button coin2Btn;
    [SerializeField] public Button coin3Btn;
    [SerializeField] public Button coin4Btn;
    [SerializeField] public Button coin5Btn;
    [SerializeField] public Button allInBtn;
    [SerializeField] public Button giveUpBtn;
    
    void Start()
    {
        plusCardBtn.onClick.AddListener(() => plusClick());
        coin1Btn.onClick.AddListener(() => coinClick());
        coin2Btn.onClick.AddListener(() => coinClick());
        coin3Btn.onClick.AddListener(() => coinClick());
        coin4Btn.onClick.AddListener(() => coinClick());
        coin5Btn.onClick.AddListener(() => coinClick());
        allInBtn.onClick.AddListener(() => coinClick());
        giveUpBtn.onClick.AddListener(() => giveUpClick());
    }

    void plusClick()
    {
        
    }

    void coinClick()
    {

    }

    void giveUpClick()
    {

    }

    void Update()
    {
        
    }    
}
