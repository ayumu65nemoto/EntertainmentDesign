using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            // �^�[�Q�b�g�I�u�W�F�N�g�̈ʒu��Ǐ]
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            // �C�ӂ̉�]������ǉ�����ꍇ�͈ȉ��ɋL�q
        }
    }
}
