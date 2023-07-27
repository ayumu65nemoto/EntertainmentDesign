using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    //@‰ñ“]‚Ì’†S
    [SerializeField]
    private GameObject _targetObject;
    //@‰ñ“]‚Ì²
    [SerializeField]
    private Vector3 _rotateAxis = Vector3.left;
    //@‰ñ“]‚Ì‘¬“x
    private float _rotateSpeed = 500f;

    public void StartHitBall()
    {
        StartCoroutine(HitBallCoroutine());
    }

    private IEnumerator HitBallCoroutine()
    {
        yield return new WaitForSeconds(1f); // 2•b‘Ò‚Â

        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * 7.0f;

            // ‰ñ“]ˆ—
            transform.RotateAround(_targetObject.transform.position, _rotateAxis, _rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
