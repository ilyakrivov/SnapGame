using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn; // ������ �� ��������, ������� �� ����� ��������
    public float spawnInterval = 2.0f; // �������� ������� ����� ��������
    public int maxSpawnCount = 15; // ������������ ���������� �������

    private int spawnCount = 0; // ���������� ����������� �������

    // Coroutine ��� ������� SpawnCoroutine() � ������� ������
    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnCoroutine());
    }

    // Coroutine ��� ������ �������� � ���������� �������
    IEnumerator SpawnCoroutine()
    {
        while (spawnCount < maxSpawnCount) // ���� �� �� �������� ������������� ���������� �������
        {
            // �������� ��������� ������ �� ������
            int randomIndex = Random.Range(0, prefabsToSpawn.Count);
            GameObject prefabToSpawn = prefabsToSpawn[randomIndex];

            // ��������  ���������� ��� ������ ��������� ���, ���� ���� ����� ������
            Vector3 spawnPosition = transform.position;

            // ������� ������ � ����������� ������� �������
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            spawnCount++;

            // ���� �� ���������� ������
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
