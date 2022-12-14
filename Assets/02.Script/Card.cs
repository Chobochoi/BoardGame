using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] SpriteRenderer charactor;
    [SerializeField] TMP_Text numTMP;    
    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    public Item item;
    bool isFront;
    // 카드의 원본크기 위치 그대로 하기 위해서 할당
    public PRS originPRS;
    
    public void Setup(Item item, bool isFront)
    {
        this.item = item;
        this.isFront = isFront;

        if (this.isFront)
        {
            charactor.sprite = this.item.sprite;
            numTMP.text = this.item.num.ToString();
        }

        else
        {
            card.sprite = cardBack;
            numTMP.text = "";
        }
    }

    public void MoveTransform(PRS prs, bool useDotween, float dotweenTime = 0)
    {
        // dotween이 true면 dotween으로 부드럽게 움직이게 하기 transform. 해보면 여러종류가 많음 (구글 참조)
        if (useDotween)
        {
            transform.DOMove(prs.pos, dotweenTime);
            transform.DORotateQuaternion(prs.rot, dotweenTime);
            transform.DOScale(prs.scale, dotweenTime);
        }
        else
        {
            transform.position = prs.pos;
            transform.rotation = prs.rot;
            transform.localScale = prs.scale;
        }
    }
}
