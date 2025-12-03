using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [Header("攻撃時の処理")]
    [SerializeField]private UnityEvent _attack;

    /// <summary>
    /// 攻撃
    /// </summary>
    public void Attack()
    {
        Debug.Log("Attack!");
        //Attackの時の処理を書く（画面が揺れるなど）
        _attack.Invoke();
    }
}
