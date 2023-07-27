using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    //　移動の音
    [SerializeField]
    private AudioClip _moveSound;
    //　AudioSource
    [SerializeField]
    private AudioSource _audioSource;
    //　移動させるオブジェクト
    [SerializeField]
    private GameObject _targetObject;
    //　球
    [SerializeField]
    private GameObject _ball;
    //　移動する座標
    [SerializeField]
    private Transform _targetTransform;
    //　移動速度
    [SerializeField]
    private float _moveSpeed = 2.0f;
    // Swing
    [SerializeField]
    private Swing _swing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _ball = collision.gameObject;
            _ball.transform.SetParent(transform);

            //　球を止める
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            
            //　ばねの音
            _audioSource.clip = _moveSound;
            _audioSource.Play();

            //　移動
            StartCoroutine(MoveToTarget());
        }
    }

    IEnumerator MoveToTarget()
    {
        Vector3 startPosition = _targetObject.transform.position;
        Vector3 targetPosition = _targetTransform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * _moveSpeed;
            _targetObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            yield return null;
        }

        _targetObject.transform.position = targetPosition; // 補完の誤差修正
        transform.DetachChildren();

        //　振り子関数呼び出し
        _swing.StartHitBall();
    }
}
