using UnityEngine;

/// <summary>
/// 車が前進する処理
/// </summary>
public class CarMove : MonoBehaviour
{
    /// <summary>
    /// 到着地点
    /// </summary>
    [SerializeField] Vector3 _targetPosition;
    /// <summary>
    /// 車の動く速さ
    /// </summary>
    [SerializeField] float _moveSpeed;
   
    /// <summary>
    /// スタートのタイミングでtrueに切り替える
    /// </summary>
    bool _isMoving;

    private void Update()
    {
        //if (!_isMoving) return;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}

