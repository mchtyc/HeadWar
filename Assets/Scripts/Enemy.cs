using UnityEngine;
using System.Collections;

public class Enemy : Abilities
{
	private Vector2 targetDir, randomDir;
	private float t;
	private bool isRandDirDet;
    private GameManager GManager;

    public int speed, money;
    public float point;
    public bool isZero;
    public Rigidbody2D EnemyRB;
    public GunBelt enemyBelt;

    // Start is called before the first frame update
    void Start()
    {
        GManager = FindObjectOfType<GameManager>();
        int weaponCount;
                
		t = 0f;
		isRandDirDet = false;
        money = 0;
        id = gameObject.GetInstanceID() - 2 * gameObject.GetInstanceID();

        Statics.EnemyStats(isZero, out HP, out defense, out attack, out weaponCount, out point);
      
        CreateStartingWeapons(weaponCount);
        health = HP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		t += Time.deltaTime;

		if ((int)(t/5) % 2 == 0) {	//Follow a Random Target
            if (!isRandDirDet)
            {
                randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                randomDir.Normalize();
                isRandDirDet = true;
            }

            Transform e = enemyBelt.pickTarget();
            if (e != null)
            {
                targetDir = e.position - transform.position;
            }
            else
            {
                targetDir = randomDir;
            }

			//targetDir = Player.currentPos - transform.position;
            targetDir.Normalize();
            EnemyRB.AddForce(new Vector2(targetDir.x, targetDir.y)*speed*Time.fixedDeltaTime/10000);
			
		} else {
            EnemyRB.AddForce(randomDir * speed * Time.fixedDeltaTime / 10000);
            isRandDirDet = false;
		}
    }

    public void CreateStartingWeapons(int count)
    {
        GunBelt gunBelt = GetComponentInChildren<GunBelt>();

        for (int i = 0; i < count; i++)
        {
            gunBelt.CreateWeapon();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health = Statics.Hit(id, health, other.gameObject.GetComponent<Bullet>().attack, defense);
            GameEvents.current.Damage(id, health);
            GManager.Killable(gameObject, health);
        }
    }
}
