using UnityEngine;
using System.Collections;
using System;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Transform Target;
    [SerializeField] GameObject CoinAnimationPrefab;
    [SerializeField] Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    public void StartCoinMove(Vector3 _initial, Action onComplete)
    {
        Vector3 target = cam.ScreenToWorldPoint(new Vector3(Target.position.x, Target.position.y,cam.transform.position.z * -1));
        GameObject _coin = Instantiate(CoinAnimationPrefab,transform);
        StartCoroutine(moveCoin(_coin.transform, _initial, target, onComplete));
    }

    IEnumerator moveCoin(Transform obj,Vector3 startPosition,Vector3 EndPosition , Action onComplete) 
    {
        float time = 0;
        while (time < 1)
        {
            time += Speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPosition, EndPosition, time);
            yield return new WaitForEndOfFrame();
        }
        onComplete.Invoke();
        //Destroy(obj.gameObject);
    }
    

    
}
