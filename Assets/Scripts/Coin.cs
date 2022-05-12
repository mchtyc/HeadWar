using UnityEngine;

public class Coin : MonoBehaviour
{
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(1, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 2.5f);
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
