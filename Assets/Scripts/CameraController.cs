using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //　プレイヤーたちを格納
    [SerializeField]
    private List<Transform> _targets = new List<Transform>();
    // カメラが追うプレイヤー
    private Transform _target;
    //　現在何番のプレイヤーを追っているか
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
            // ターゲットオブジェクトの位置を追従
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            // 任意の回転処理を追加する場合は以下に記述
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
