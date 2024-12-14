using UnityEngine;

public class Coin : MonoBehaviour
{
    private int value;

    void Start()
    {
        value = Random.Range(1, 11);
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 100f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            MoneyManager.gainMoney(other.gameObject, value);

            if (other.CompareTag("Enemy"))
            {
                other.GetComponentInChildren<GunBelt>().CreateWeapon();          
            }

            Statics.coinCount--;
            Destroy(gameObject);
        }
    }
}
