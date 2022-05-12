using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform target;
    public float shootingRate = 1f;
    public GameObject Bullet;
    public float gunWeight;
    public GameObject belongTo;

    private GunBelt gunBelt;
    private Transform BulletHolder;

    void Start()
    {
        BulletHolder = GameObject.Find("Bullet Holder").transform;

        gunBelt = belongTo.GetComponentInChildren<GunBelt>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        StartCoroutine("Shooting");

        if (belongTo.CompareTag("Player"))
        {
            belongTo.GetComponent<Player>().maxSpeed -= gunWeight;
        }
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.5f);
        Bullet bulletComp;
        for (int i = 0; i <= 0;) {
            if (target != null) {
                GameObject b = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity, BulletHolder);
                bulletComp = b.GetComponent<Bullet>();
                bulletComp.target = target;
                bulletComp.belongTo = belongTo;
            }

            yield return new WaitForSeconds(shootingRate);
        }
    }

    private void UpdateTarget()
    {
        if (gunBelt.enemiesInRange != null)
        {
            float distance = Mathf.Infinity;

            foreach (Transform enemy in gunBelt.enemiesInRange)
            {
                if (enemy != null && enemy.gameObject != belongTo)
                {
                    float tempDistance = Vector3.Distance(transform.position, enemy.position);

                    if (tempDistance < distance)
                    {
                        distance = tempDistance;
                        target = enemy;
                    }
                }
            }
        }
        else {
            target = null;
        }
    }
}
