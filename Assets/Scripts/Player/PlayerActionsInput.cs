using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの入力管理
/// </summary>
public class PlayerActionsInput : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] MouseController _mouseController;
    private PlayerActions _playerActions;

    /// <summary>
    /// Rayの長さ
    /// </summary>
    [SerializeField] float _rangeDistance;
    /// <summary>
    /// エネミーのレイヤー
    /// </summary>
    [SerializeField] LayerMask _enemyLayer;
    /// <summary>
    /// キーのコールバックを入れる
    /// </summary>
    private Vector2 _moveInputValue;
    /// <summary>
    /// エネミーにRayが当たっているかの判定
    /// </summary>
    private bool _isEnemyTarget;

    private void OnEnable()
    {
        //初期化
        _playerActions = new PlayerActions();
        _playerActions.Enable();
        //イベント登録
        _playerActions.PlayerMove.Move.started += HandleMove;
        _playerActions.PlayerMove.Attack.performed += HandleAttack;
    }
    private void OnDisable()
    {
        _playerActions.PlayerMove.Move.started -= HandleMove;
        _playerActions.PlayerMove.Attack.performed -= HandleAttack;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        _isEnemyTarget = Physics.Raycast(ray, out hit, _rangeDistance, _enemyLayer);
        _mouseController.ColorChange(_isEnemyTarget);
    }

    /// <summary>
    /// 移動したときの値の記録
    /// </summary>
    /// <param name="context"></param>
    private void HandleMove(InputAction.CallbackContext context)
    {
        _moveInputValue = context.ReadValue<Vector2>();
        _playerMove.Move(_moveInputValue);
    }

    /// <summary>
    /// 攻撃した時の値の記録
    /// </summary>
    /// <param name="context"></param>
    private void HandleAttack(InputAction.CallbackContext context)
    {
        if (!_isEnemyTarget) return;
        _playerMove.Attack();
    }
}
