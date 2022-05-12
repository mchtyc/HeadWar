using UnityEngine;

public static class Statics
{
    public static int coinCount;

    public static float Hit(int id, float health, float att, float defense)
    {
        if (att > defense)
        {
            health = health - (att - defense);
            if (health < 0)
            {
                health = 0;
            }
        }

        return health;
    }

    public static bool isPlayer(GameObject g)
    {
        if (g != null)
        {
            if (g.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static bool isEnemy(GameObject g)
    {
        if (g != null)
        {
            if (g.CompareTag("Enemy"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static void EnemyStats(bool isZero, out float HP, out float def, out float att, out int wCount, out float point)
    {
        if (isZero)
        {
            HP = 100f;
            def = 5f;
            att = 20;
            wCount = 0;
            point = 0;
        }
        else
        {
            HP = Random.Range(1, 11) * 20;
            def = Random.Range(1, 11);
            att = Random.Range(1, 11) * 10;
            wCount = Random.Range(0, 2);
            point = ((float)wCount * 30) + (def * 10) + HP + att;
        }
       
    }
}
