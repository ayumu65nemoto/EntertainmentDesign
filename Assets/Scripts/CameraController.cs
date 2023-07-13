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
            // ターゲットオブジェクトの位置を追従
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            // 任意の回転処理を追加する場合は以下に記述
        }
    }
}
