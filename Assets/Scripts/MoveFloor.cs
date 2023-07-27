using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    //�@�ړ��̉�
    [SerializeField]
    private AudioClip _moveSound;
    //�@AudioSource
    [SerializeField]
    private AudioSource _audioSource;
    //�@�ړ�������I�u�W�F�N�g
    [SerializeField]
    private GameObject _targetObject;
    //�@��
    [SerializeField]
    private GameObject _ball;
    //�@�ړ�������W
    [SerializeField]
    private Transform _targetTransform;
    //�@�ړ����x
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

            //�@�����~�߂�
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            
            //�@�΂˂̉�
            _audioSource.clip = _moveSound;
            _audioSource.Play();

            //�@�ړ�
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

        _targetObject.transform.position = targetPosition; // �⊮�̌덷�C��
        transform.DetachChildren();

        //�@�U��q�֐��Ăяo��
        _swing.StartHitBall();
    }
}
