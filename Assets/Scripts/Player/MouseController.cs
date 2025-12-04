using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マウス操作の管理をするコンポーネント
/// </summary>
public class MouseController : MonoBehaviour
{
    [SerializeField] private Image _targetPosition;
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// ポインターの色を変える処理
    /// </summary>
    /// <param name="isEnemyTarget"></param>
    public void ColorChange(bool isEnemyTarget)
    {
        if (isEnemyTarget)
            _targetPosition.color = Color.red;
        else
            _targetPosition.color = Color.white;
    }


}
