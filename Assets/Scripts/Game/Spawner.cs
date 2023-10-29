using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _cars;
    [SerializeField] private GameManager _gameManager;    
    [SerializeField] private float _timeBetweenSpawn;
    private float _spawnTime;

    private void Update()
    {
        if (Time.time > _spawnTime && _gameManager.startTimer == 0)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }

    }
    private void Spawn()
    {
        float randomX = Random.Range(-3, 3.5f);

        int randomCar = Random.Range(0, _cars.Length);
        Instantiate(_cars[randomCar], transform.position + new Vector3(randomX, 6, 0), transform.rotation);
    }
}
