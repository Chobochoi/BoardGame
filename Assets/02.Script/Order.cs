using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] Renderer[] backRenderers;
    [SerializeField] Renderer[] middleRenderers;
    [SerializeField] string sortingLayerName;
    int originOrder;

    public void Start()
    {
        SetOrder(0);
    }

    public void SetOriginOrder(int originOrder)
    {
        this.originOrder = originOrder;
        SetOrder(originOrder);
    }

    /// <summary>
    /// 카드 등장시 맨 앞으로 오게 하기 위함
    /// </summary>
    /// <param name="isMostFront"></param>
    public void SetMostFrontOrder(bool isMostFront)
    {
        SetOrder(isMostFront ? 100 : originOrder);
    }

    public void SetOrder(int order)
    {
        // 카드와 카드가 겹치지 않게 하기 위해 10을 곱해준다
        int mulOrder = order * 10;

        foreach (var renderer in backRenderers)
        {
            renderer.sortingLayerName = sortingLayerName;
            renderer.sortingOrder = mulOrder;
        }

        foreach (var renderer in middleRenderers)
        {
            renderer.sortingLayerName = sortingLayerName;
            // back 보다는 한칸 더 위에 보이게
            renderer.sortingOrder = mulOrder + 1;
        }

    }
}
