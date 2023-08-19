using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : DamageBasic
{
    [Header("���`�ƥ�")]
    [SerializeField] public UnityEvent onDead;

    private DataEnemy dataEnemy;
    public DamagePlayer damagePlayer;

    private void Start()
    {
        dataEnemy = (DataEnemy)data;
        damagePlayer = GameObject.Find("���Z").GetComponent<DamagePlayer>();
        if (name.Contains("Boss")) onDead.AddListener(() => damagePlayer.Win());
        //if(name.Contains("GhostBOSS"))onDead.AddListener(()=>damagePlayer.Win());
        //if (gameObject.tag == "Boss") onDead.AddListener(() => damagePlayer.Win());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("�Z��"))
        {
            float damage = collision.gameObject.GetComponent<Weapon>().attack;
            Damage(damage);
        }

    }
    protected override void Dead()
    {
        base.Dead();
        onDead.Invoke();
        Destroy(gameObject);

        //print("�H���ȡG" + Random.value);
        if (Random.value < dataEnemy.expProbability)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}
