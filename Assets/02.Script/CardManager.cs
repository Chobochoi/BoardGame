using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    /// <summary>
    /// CardManager를 싱글톤으로 만들어준다
    /// </summary>
    public static CardManager instance { get; private set; }
        
    private void Awake() => instance = this;

    [SerializeField] ItemSO itemSO;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] List<Card> myCards;
    [SerializeField] List<Card> otherCards;
    [SerializeField] Transform cardSpawnPoint;
    List<Item> itemBuffer;

    public Item PopItem()
    {
        // 다 뽑으면 다시 0부터
        if (itemBuffer.Count == 0)
        {
            SetupItemBuffer();
        }

        // 우리나 적이 카드를 뽑을 때 0번부터 100개까지 뽑는다.  
        Item item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }

    void SetupItemBuffer()
    {
        itemBuffer = new List<Item>();
        // 확률을 가진 아이템 리스트 들 중에서 100이 채워질때 까지 순차적으로 나옴
        for (int i = 0; i < itemSO.items.Length; i++)
        {
            Item item = itemSO.items[i];
            for (int j = 0; j < item.percent; j++)
            {
                itemBuffer.Add(item);
            }
        }

        // 아이템들이 순차적으로 나오면 안되기 때문에 랜덤하게 나오게 하기 위해서 랜덤 값을 부여함.
        for (int i = 0; i < itemBuffer.Count; i++)
        {
            int rand = Random.Range(i, itemBuffer.Count);
            Item temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }

    void Start()
    {
        SetupItemBuffer();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            AddCard(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            AddCard(false);
        }
    }

    void AddCard(bool isMine)
    {
        // card 스폰 시킬 위치
        var cardObject = Instantiate(cardPrefab, cardSpawnPoint.position, Utils.QI);
        // Getcomponent로 참조 한 뒤 Setup 해서 Popitem을 한다.
        // 자기 자신인지도 알려준다.
        var card = cardObject.GetComponent<Card>();
        card.Setup(PopItem(), isMine);
        // isMine이 true면 mycards에 Add, false면 othercards에 Add
        (isMine ? myCards : otherCards).Add(card);

        SetOriginOrder(isMine);
        CardAlignment(isMine);
    }
    
    void SetOriginOrder(bool isMine)
    {
        int count = isMine ? myCards.Count : otherCards.Count;
        // 타겟카드가 내 카드인지 적 카드인지 알아야 한다.
        for (int i = 0; i < count; i++)
        {
            var targetCard = isMine ? myCards[i] : otherCards[i];
            // Sorting Layer의 오리진오더를 채워준다. (정렬을 위함 큰 수가 맨위에 뜨게)
            targetCard?.GetComponent<Order>().SetOriginOrder(i);
        }
    }

    void CardAlignment(bool isMine)
    {
        // isMine이면 내 카드 정렬 아니면 otherCards 정렬
        var targetCards = isMine ? myCards : otherCards;
        for (int i = 0; i < targetCards.Count; i++)
        {
            var targetCard = targetCards[i];

            // 임시로 정해놓은 값
            targetCard.originPRS = new PRS(Vector3.zero, Utils.QI, Vector3.one * 1.9f);
            targetCard.MoveTransform(targetCard.originPRS, true, 0.7f);
        }
    }
}
