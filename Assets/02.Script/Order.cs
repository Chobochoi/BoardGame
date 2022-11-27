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
    /// ī�� ����� �� ������ ���� �ϱ� ����
    /// </summary>
    /// <param name="isMostFront"></param>
    public void SetMostFrontOrder(bool isMostFront)
    {
        SetOrder(isMostFront ? 100 : originOrder);
    }

    public void SetOrder(int order)
    {
        // ī��� ī�尡 ��ġ�� �ʰ� �ϱ� ���� 10�� �����ش�
        int mulOrder = order * 10;

        foreach (var renderer in backRenderers)
        {
            renderer.sortingLayerName = sortingLayerName;
            renderer.sortingOrder = mulOrder;
        }

        foreach (var renderer in middleRenderers)
        {
            renderer.sortingLayerName = sortingLayerName;
            // back ���ٴ� ��ĭ �� ���� ���̰�
            renderer.sortingOrder = mulOrder + 1;
        }

    }
}
