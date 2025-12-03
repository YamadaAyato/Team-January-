using DG.Tweening;
using UnityEngine;

/// <summary>
/// プレイヤーの動作管理
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [Header("プレイヤーの動く速さ")]
    [SerializeField]private float _moveForce;

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="moveInputValue"></param>
    public void Move(Vector2 moveInputValue)
    {
        transform.DOBlendableMoveBy(new Vector3(moveInputValue.x, 0, moveInputValue.y) * _moveForce, 1f);
        Debug.Log(transform.position);
    }
}
