using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject belongTo;
    private int id; 
    private float HP;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Statics.isPlayer(belongTo))
        {
            id = belongTo.GetComponent<Player>().id;
            HP = belongTo.GetComponent<Player>().HP;
        }
        else
        {
            id = belongTo.GetComponent<Enemy>().id;
            HP = belongTo.GetComponent<Enemy>().HP;
        }
        transform.localScale = new Vector2(1f, 1f);
        GameEvents.current.OnDamage += onDamageTake;
    }

    private void onDamageTake(int id, float health)
    {
        if (id == this.id)
        {
            float scale = health / HP;
            transform.localScale = new Vector2(scale, transform.localScale.y);
        }
    }

    private void OnDisable()
    {
        GameEvents.current.OnDamage -= onDamageTake;
    }
}
