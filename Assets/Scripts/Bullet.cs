using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float bulletSpeed = 10;
    public float attack;
    
    public Transform target;
    public GameObject belongTo;

    private Vector3 dir;

    private void Start()
    {
        Destroy(gameObject, 2f);

        if (belongTo.CompareTag("Player"))
        {
            attack = belongTo.GetComponent<Player>().attack;
        }
        else
        {
            attack = belongTo.GetComponent<Enemy>().attack;
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (target != null) {
			dir = target.position - transform.position;
			dir = dir.normalized;
			transform.position += dir * bulletSpeed * Time.deltaTime;
		} else {
			Destroy (gameObject);
		}
    }

	void OnTriggerEnter2D(Collider2D other){
        if (belongTo != other.gameObject)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Player"))
            {
                Enemy e;
                if (other.CompareTag("Enemy"))
                {
                    if (Statics.isPlayer(belongTo))
                    {
                        Player.playerPoints += 10;
                    }
                    else if (Statics.isEnemy(belongTo))
                    {
                        e = belongTo.GetComponent<Enemy>();
                        e.point += 10;
                    }
                }
                else if (other.CompareTag("Player"))
                {
                    e = belongTo.GetComponent<Enemy>();
                    e.point += 10;
                }

                Destroy(gameObject); 
            }
        }
    }
}
