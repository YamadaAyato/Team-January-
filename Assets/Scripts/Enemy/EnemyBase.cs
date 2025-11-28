using UnityEngine;

/// <summary>
///         敵の基底クラス
/// </summary>
public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("敵のデータ")] protected EnemyData _enemyData;

    protected int _currentHP;

    protected virtual void Start()
    {
        _currentHP = _enemyData.MAXHP;
    }

    /// <summary>
    ///         ダメージを受ける処理
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Die();
        }
    }

    /// <summary>
    ///         死亡時の処理
    /// </summary>
    protected virtual void Die()
    {
        // 敵が倒されたときの処理（例：スコア加算、エフェクト再生など）
        Destroy(gameObject);
    }
}
