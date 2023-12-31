using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    //　回転の中心
    [SerializeField]
    private GameObject _targetObject;
    //　回転の軸
    [SerializeField]
    private Vector3 _rotateAxis = Vector3.left;
    //　回転の速度
    private float _rotateSpeed = 500f;

    public void StartHitBall()
    {
        StartCoroutine(HitBallCoroutine());
    }

    private IEnumerator HitBallCoroutine()
    {
        yield return new WaitForSeconds(1f); // 2秒待つ

        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * 7.0f;

            // 回転処理
            transform.RotateAround(_targetObject.transform.position, _rotateAxis, _rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
