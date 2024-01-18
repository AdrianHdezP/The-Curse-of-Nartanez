using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int rounds = 1;
    [SerializeField] private float spawnTimer = 0;
    public float countdown = 0; 

    public Transform[] spawnZone1;
    public Transform[] spawnZone2;

    public bool spawnZoneBool1 = false;
    public bool spawnZoneBool2 = false;

    [SerializeField] private GameObject necrofago;
    private int necrofagosInRound = 2;
    private int necrofagosSpawnInRound = 0;
    public int necrofagosLeftInRound = 2;


    private void Update()
    {
        if(necrofagosSpawnInRound < necrofagosInRound && countdown <= 0)
        {
            if(spawnTimer > 2)
            {
                spawnTimer = 0;

                if (rounds <= 4)
                {
                    Debug.Log("Is Round: " + rounds);
                    if (spawnZoneBool1 == true)
                        SpawnEnemy(spawnZone1, necrofago);

                    if (spawnZoneBool2 == true)
                        SpawnEnemy(spawnZone2, necrofago);
                }

                if (rounds == 5)
                {
                    Debug.Log("Is Round: " + rounds);
                    if (spawnZoneBool1 == true)
                        SpawnEnemy(spawnZone1, necrofago);

                    if (spawnZoneBool2 == true)
                        SpawnEnemy(spawnZone2, necrofago);
                }

                if(rounds >= 6 && rounds <= 9)
                {
                    Debug.Log("Is Round: " + rounds);
                    if (spawnZoneBool1 == true)
                        SpawnEnemy(spawnZone1, necrofago);

                    if (spawnZoneBool2 == true)
                        SpawnEnemy(spawnZone2, necrofago);
                }
            }
            else
            {
                spawnTimer += Time.deltaTime;
            }
        }
        else if(necrofagosLeftInRound == 0)
        {
            StartNewRound();
        }

        if (countdown != 0)
            countdown -= Time.deltaTime;
        else
            countdown = 0;
    }

    private void StartNewRound()
    {
        rounds++;
        necrofagosInRound = necrofagosLeftInRound = rounds * 2;
        necrofagosSpawnInRound = 0;
        countdown = 15;
    }

    private void SpawnEnemy(Transform[] _spawnZone, GameObject _enemyType)
    {
        Vector3 randomSpawnPoint = _spawnZone[Random.Range(0, _spawnZone.Length)].position;
        Instantiate(_enemyType, randomSpawnPoint, Quaternion.identity);
        necrofagosSpawnInRound++;
    }
}
