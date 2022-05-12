using UnityEngine;

public class Player : Abilities
{
    public static Vector3 currentPos;
    public static int playerMoney, playerPoints;

    private GunBelt playerBelt;
    private GameManager GManager;

    // Start is called before the first frame update
    void Start()
    {
        id = 1;
        playerMoney = 0;
        playerPoints = 0;
        maxSpeed = 75;
        playerBelt = GetComponentInChildren<GunBelt>();
        HP = health = 100;
        attack = 50;
        defense = 10;
        GManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        currentPos = transform.position;

        if (Input.GetKeyDown(KeyCode.G))
        {
            CreateWeapon();
        }
    }

    public void CreateWeapon()
    {
        playerBelt.CreateWeapon();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health = Statics.Hit(id, health, other.gameObject.GetComponent<Bullet>().attack, defense);
            GameEvents.current.Damage(id, health);
            if (health <= 0)
            {
                GManager.ToggleGameOverScreen(true);
            }
        }
    }
}
