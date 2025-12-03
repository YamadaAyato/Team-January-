using DG.Tweening;
using UnityEngine;

/// <summary>
/// プレイヤーの動作管理
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの動く速さ
    /// </summary>
    [SerializeField] float _moveForce;

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="moveInputValue"></param>
    public void Move(Vector2 moveInputValue)
    {
        transform.DOBlendableMoveBy(new Vector3(moveInputValue.x, 0, moveInputValue.y) * _moveForce, 1f);
        Debug.Log(transform.position);
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    public void Attack()
    {
        Debug.Log("Attack!");
    }
}
