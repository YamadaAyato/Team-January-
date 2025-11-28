using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("敵の名前")]
    public string EnemyName;

    [Header("最大HP")]
    public int MAXHP;

    [Header("攻撃力")]
    public int ATK;

    [Header("移動速度")]
    public float MOVESPEED;

    [Header("攻撃間隔")]
    public float ATTACKINTERVAL;

    [Header("倒した時のスコア")]
    public int SCORE;
}
