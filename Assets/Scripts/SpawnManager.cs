using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn; // Список из префабов, которые мы будем спаунить
    public float spawnInterval = 2.0f; // Интервал времени между спавнами
    public int maxSpawnCount = 15; // Максимальное количество спавнов

    private int spawnCount = 0; // Количество проведенных спавнов

    // Coroutine для запуска SpawnCoroutine() в фоновом режиме
    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnCoroutine());
    }

    // Coroutine для спавна объектов с интервалом времени
    IEnumerator SpawnCoroutine()
    {
        while (spawnCount < maxSpawnCount) // Пока мы не достигли максимального количества спавнов
        {
            // Выбираем случайный префаб из списка
            int randomIndex = Random.Range(0, prefabsToSpawn.Count);
            GameObject prefabToSpawn = prefabsToSpawn[randomIndex];

            // Выбираем  координаты для спавна конкретно тут, берём прям точку спавна
            Vector3 spawnPosition = transform.position;

            // Спавним объект и увеличиваем счетчик спавнов
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            spawnCount++;

            // Ждем до следующего спавна
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
