using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static List<Enemy> allEnemies = new List<Enemy>();
    public List<Text> bestofList;
    public Transform Enemies, Coins;
	public GameObject EnemyPre, CoinPre, PlayerPre, GameOverScreen;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        player = (GameObject)Instantiate(PlayerPre, transform.position, Quaternion.identity);
        Statics.coinCount = 0;
        EnemyIns(19);
        StartCoroutine(CoinIns());
        InvokeRepeating("EnemySorting", 0f, 2f);
    }

    public void CreateWeapon()
    {
        player.GetComponent<Player>().CreateWeapon();
    }

    public void EnemySorting()
    {
        allEnemies = allEnemies.OrderByDescending(w => w.point).ToList();

        RefreshList(allEnemies);
    }

    void RefreshList(List<Enemy> enemies)
    {
        int playerPlace = 0;

        foreach (Enemy e in enemies)
        {
            playerPlace++;
            if (e.point <= Player.playerPoints)
            {
                break;
            }
        }

        for (int i = 1; i <= 5; i++)
        {
            if (i < playerPlace)
            {
                bestofList[i-1].text = i + ". " + allEnemies[i-1].name + ":   " + allEnemies[i-1].point;
            }
            else if (i == playerPlace)
            {
                bestofList[i-1].text = i + ". " + player.name + ": " + Player.playerPoints;
            }
            else
            {
                bestofList[i-1].text = i + ". " + allEnemies[i-2].name + ": " + allEnemies[i-2].point;
            }
        }

        if (playerPlace > 5)
        {
            bestofList[4].text = (playerPlace + 1) + ". " + player.name + ": " + Player.playerPoints;
        }
    }

    private IEnumerator CoinIns()
    {
        Vector3 coinInsPos;

        for (int j = 0; j < 1; )
        {
            if (Statics.coinCount < 100)
            {
                coinInsPos = new Vector3(Random.Range(-38f, 38f), Random.Range(-18f, 18f), 0f);
                Instantiate(CoinPre, coinInsPos, Quaternion.identity, Coins);
                Statics.coinCount++; 
            }
            yield return new WaitForSeconds(0.7f);
        }
    }

    public void EnemyIns(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 enemyInsPos;
            Vector3 left = new Vector3(Random.Range(-38f, -15f), Random.Range(-18f, 18f), 0f);
            Vector3 right = new Vector3(Random.Range(15f, 38f), Random.Range(-18f, 18f), 0f);

            //Enemy shouldn't instantiate in front of the camera
            if (Player.currentPos.x > 0)
            {
                enemyInsPos = left;
            }
            else if(Player.currentPos.x < 0)
            {
                enemyInsPos = right;
            }
            else
            {
                if(Random.Range(1,3) == 1){
                    enemyInsPos = left;
                }
                else
                {
                    enemyInsPos = right;
                }
            }

            GameObject e = (GameObject)Instantiate(EnemyPre, enemyInsPos, Quaternion.identity, Enemies);
            
            Enemy enemyComponent = e.GetComponent<Enemy>();
            enemyComponent.name = EnemyNames.CreateName(allEnemies);
            if (count == 1)
            {
                enemyComponent.isZero = true;
            }
            else
            {
                enemyComponent.isZero = false;
            }
            allEnemies.Add(enemyComponent);
        }
    }

    public void Killable(GameObject g, float health)
    {
        if (health <= 0)
        {
            GameManager.allEnemies.Remove(g.GetComponent<Enemy>());
            Destroy(g);

            EnemyIns(1);
        }
    }

    public void ToggleGameOverScreen(bool key)
    {
        Time.timeScale = 0.02f;
        GameOverScreen.SetActive(key);
    }
}
