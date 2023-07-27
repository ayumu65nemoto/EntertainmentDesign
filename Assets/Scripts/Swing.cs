using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    //�@��]�̒��S
    [SerializeField]
    private GameObject _targetObject;
    //�@��]�̎�
    [SerializeField]
    private Vector3 _rotateAxis = Vector3.left;
    //�@��]�̑��x
    private float _rotateSpeed = 500f;

    public void StartHitBall()
    {
        StartCoroutine(HitBallCoroutine());
    }

    private IEnumerator HitBallCoroutine()
    {
        yield return new WaitForSeconds(1f); // 2�b�҂�

        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * 7.0f;

            // ��]����
            transform.RotateAround(_targetObject.transform.position, _rotateAxis, _rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
