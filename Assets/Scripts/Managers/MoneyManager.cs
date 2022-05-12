using UnityEngine;

public static class MoneyManager
{
    public static bool spentMoney(GameObject body, int cost)
    {
        if (isGunAffordable(body, cost))
        {
            if (Statics.isPlayer(body))
            {
                Player.playerMoney -= cost;
            }
            else if (Statics.isEnemy(body))
            {
                body.GetComponent<Enemy>().money -= cost;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void gainMoney(GameObject body, int amount)
    {
        if (Statics.isPlayer(body))
        {
            Player.playerMoney += amount;
        }
        else if(Statics.isEnemy(body))
        {
            body.GetComponent<Enemy>().money += amount;
        }
    }

    public static bool isGunAffordable(GameObject body, int cost)
    {
        int _money = 0;

        if (Statics.isPlayer(body))
        {
            _money = Player.playerMoney;
        }
        else if (Statics.isEnemy(body))
        {
            _money = body.GetComponent<Enemy>().money;
        }

        if (_money >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
