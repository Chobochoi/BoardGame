using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class UniTaskTest : MonoBehaviour
{
    private IEnumerator CoTest()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Co 1초지남");
    }

    private async UniTaskVoid TaskTest()
    {
        //DelayType.UnscaledDeltaTime Timescale 값이 0이 되어도 계속 진행합니다.
        await UniTask.Delay(TimeSpan.FromSeconds(1f), DelayType.UnscaledDeltaTime);
        Debug.Log("Task 1초지남");
    }

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(CoTest());

        // Void를 사용하면 Forget을 붙이라고 문서에 나와있습니다.
        TaskTest().Forget();
    }

    //public int count;

    //private IEnumerator CoTest()
    //{
    //    yield return new WaitUntil(() => count == 3);
    //    Debug.Log("Co 3이 되었다.");        
    //}

    //private async UniTaskVoid TaskTest()
    //{
    //    await UniTask.WaitUntil(() => count == 3);
    //    Debug.Log("Task 3이 되었다.");
    //}

    //private void Start()    {      

    //    TaskTest().Forget();
    //}

    // 인터넷 이미지 가져오기

    //private const string Apple = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Red_Apple.jpg/1130px-Red_Apple.jpg";
    //public RawImage profileImg;

    //private IEnumerator CoTest(UnityAction<Texture2D> action)
    //{
    //    UnityWebRequest request = UnityWebRequestTexture.GetTexture(Apple);
    //    yield return request.SendWebRequest();

    //    if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
    //    {
    //        // 에러처리를 합니다.
    //        Debug.LogError(request.error);
    //    }
    //    else
    //    {
    //        Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    //        action.Invoke(texture);
    //    }
    //}

    //private async UniTask<Texture2D> TestUni()
    //{
    //    UnityWebRequest request = UnityWebRequestTexture.GetTexture(Apple);
    //    await request.SendWebRequest();

    //    if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
    //    {
    //        Debug.LogError(request.error);
    //    }
    //    else
    //    {
    //        Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    //        return texture;
    //    }

    //    return null;
    //}


    //private async UniTaskVoid GetImage()
    //{
    //    Texture2D texture = await WaitGetWebTextureAsync();
    //    profileImg.texture = texture;
    //}

    //private Task<Texture2D> WaitGetWebTextureAsync()
    //{
    //    throw new NotImplementedException();
    //}

    //private void Start()
    //{
    //    GetImage().Forget();
    //}
}
