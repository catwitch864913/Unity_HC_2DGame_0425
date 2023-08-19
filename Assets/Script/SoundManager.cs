using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("升級")]
    public AudioClip soundLvUp;
    [Header("升級技能")]
    public AudioClip soundSkillLvUp;
    [Header("玩家受傷")]
    public AudioClip soundPlayerHurt;
    [Header("玩家死亡")]
    public AudioClip soundPlayerDead;
    [Header("史萊姆受傷")]
    public AudioClip soundSlimeHurt;
    [Header("幽靈受傷")]
    public AudioClip soundGhostHurt;
    [Header("怪物死亡")]
    public AudioClip soundEnemyDead;
    [Header("丟斧頭")]
    public AudioClip soundFireApex;

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }
}