using System.Collections.Generic;
using UnityEngine;

public class GunBelt : MonoBehaviour
{
	public GameObject Gun, belongTo;
    public List<Transform> enemiesInRange = new List<Transform>();
    public int gunCost;

    private List<GameObject> guns = new List<GameObject>();
    
    void Start(){
        gunCost = 5;
    }

    public Transform pickTarget()
    {
        if (guns.Count != 0)
        {
            int r = Random.Range(0, guns.Count);
            Gun gun = guns[r].GetComponent<Gun>();
            if (gun.target != null)
            {
                return gun.target;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public void CreateWeapon()
    {        
        if (guns.Count < 8) // 8 is max number of gun
        {
            if (MoneyManager.spentMoney(belongTo, gunCost))
            {
                gunCost *= 2;
                int count = guns.Count;
                for (int i = 0; i < (count + 1); i++)
                {
                    float step = 360 / (guns.Count + 1);
                    if (i != guns.Count)
                    {
                        guns[i].transform.position = PointInCircle(1.7f, (float)i * step);
                    }
                    else
                    {
                        GameObject g = (GameObject)Instantiate(Gun, PointInCircle(1.7f, (float)i * step), Quaternion.identity, transform);
                        g.GetComponent<Gun>().belongTo = transform.parent.gameObject;
                        guns.Add(g);
                    }
                }
            }
        }
    }

    private Vector3 PointInCircle(float radius, float angle){//Finding points around a circle
		float rad = angle * Mathf.Deg2Rad;
		Vector3 pos = transform.right * Mathf.Sin (rad) + transform.up * Mathf.Cos (rad);
		return transform.position + pos * radius;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            if (other.name != belongTo.name)
            {
                enemiesInRange.Add(other.gameObject.transform); 
            }

            if (other.CompareTag("Enemy"))
            {
                //Debug.Log("ID: " + belongTo.GetComponent<Enemy>().name + "\n" + "EnemiesInRange: " + enemiesInRange.Count);
            }else if (other.CompareTag("Player"))
            {
                //Debug.Log("ID: " + belongTo.GetComponent<Player>().name + "\n" + "EnemiesInRange: " + enemiesInRange.Count);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (enemiesInRange[i] == other.gameObject.transform)
                {
                    enemiesInRange.RemoveAt(i);

                    if (other.CompareTag("Enemy"))
                    {
                        //Debug.Log("ID: " + belongTo.GetComponent<Enemy>().name + "\n" + "EnemiesInRange: " + enemiesInRange.Count);
                    }
                    else if (other.CompareTag("Player"))
                    {
                        //Debug.Log("ID: " + belongTo.GetComponent<Player>().name + "\n" + "EnemiesInRange: " + enemiesInRange.Count);
                    }
                }
            }
        }
    }
}
