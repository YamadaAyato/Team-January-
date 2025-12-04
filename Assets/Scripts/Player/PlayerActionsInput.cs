using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの入力管理
/// </summary>
public class PlayerActionsInput : MonoBehaviour
{
    [Header("PlayerMove")]
    [SerializeField] private PlayerMove _playerMove;
    [Header("MouseController")]
    [SerializeField] MouseController _mouseController;
    [Header("PlayerAttack")]
    [SerializeField] private PlayerAttack _playerAttack;
    [Header("PlayerActions")]
    [SerializeField] private PlayerActions _playerActions;
    [Header("Rayの長さ")]
    [SerializeField] private float _rangeDistance;
    [Header("エネミーのレイヤー")]
    [SerializeField] private LayerMask _enemyLayer;

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
       
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;
        _isEnemyTarget = Physics.Raycast(ray, out hit, _rangeDistance, _enemyLayer);
        _mouseController.ColorChange(_isEnemyTarget);

        Debug.Log(_isEnemyTarget);
        Debug.DrawRay(ray.origin, ray.direction * _rangeDistance, Color.red);
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
        _playerAttack.Attack();
    }
}
