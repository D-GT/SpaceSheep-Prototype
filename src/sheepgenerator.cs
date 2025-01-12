// Nama File: sheepgenerator.cs
// Fungsi: Mengenerate domba domba yang akan digirng dan muncul satu per satu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepgenerator : MonoBehaviour
{
    public GameObject PREFAB;
    public float spawnInterval = 3f; // Spawn rate sheep, interchangeable
    public LayerMask cliffLayer;    // Tambahkan LayerMask untuk mendeteksi cliff
    public float spawnCheckRadius = 0.5f; // Radius untuk pengecekan overlap dengan cliff

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnSheep(); // Fungsi spawn sheep dijalankan setiap timer mencapai 0
            timer = spawnInterval;
        }
    }

    private void SpawnSheep()
    {
        Vector3 spawnPosition = randomPosition();

        // Periksa apakah posisi spawn berada di dalam cliff
        while (Physics2D.OverlapCircle(spawnPosition, spawnCheckRadius, cliffLayer))
        {
            spawnPosition = randomPosition(); // Jika overlap dengan cliff, cari posisi baru
        }

        GameObject sheep = Instantiate(PREFAB, spawnPosition, Quaternion.identity);
    }

    private Vector3 randomPosition()
    {
        float randomX = Random.Range(-9, 9); // Default border sumbu X
        float randomY = Random.Range(-4, 4); // Default border sumbu Y
        
        return new Vector3(randomX, randomY, 0f);
    }
}
