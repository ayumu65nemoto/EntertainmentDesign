using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //�@�v���C���[�������i�[
    [SerializeField]
    private List<Transform> _targets = new List<Transform>();
    // �J�������ǂ��v���C���[
    private Transform _target;
    //�@���݉��Ԃ̃v���C���[��ǂ��Ă��邩
    private int _nowPlayer;

    private void Start()
    {
        _target = _targets[0];
        _nowPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            // �^�[�Q�b�g�I�u�W�F�N�g�̈ʒu��Ǐ]
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            // �C�ӂ̉�]������ǉ�����ꍇ�͈ȉ��ɋL�q
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _nowPlayer++;

            if (_nowPlayer > _targets.Count - 1)
            {
                _nowPlayer = 0;
            }

            _target = _targets[_nowPlayer];
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _nowPlayer--;

            if (_nowPlayer < 0)
            {
                _nowPlayer = _targets.Count - 1;
            }

            _target = _targets[_nowPlayer];
        }
    }

    public void SetTarget()
    {
        _target = _targets[5];
    }
}
