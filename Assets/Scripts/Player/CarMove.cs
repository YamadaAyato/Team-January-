using UnityEngine;

/// <summary>
/// 車が前進する処理
/// </summary>
public class CarMove : MonoBehaviour
{
    [Header("到着地点")]
    [SerializeField]private Vector3 _targetPosition;
    [Header("車の動く速さ")]
    [SerializeField]private float _moveSpeed;
   
    /// <summary>
    /// スタートのタイミングでtrueに切り替える
    /// </summary>
   　private bool _isMoving;

    private void Update()
    {
        //if (!_isMoving) return;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}

