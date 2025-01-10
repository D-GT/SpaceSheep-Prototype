using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepgenerator : MonoBehaviour
{
    public GameObject PREFAB;
    public float spawnInterval = 3f; //spawnrate shepe, interchangable 

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnSheep(); // fungsi spawn shepe dijalankan setiap timer mencapai 0 dari waktu yang ditentukan
            timer = spawnInterval;
        }
    }

    private void SpawnSheep() // fungsi spawn shepe
    {
        Vector3 spawnPosition = randomPosition(); //spawn akan dilakukan pada posisi acak di FOV Main Camera
        GameObject sheep = Instantiate(PREFAB, spawnPosition, Quaternion.identity);
    }


    private Vector3 randomPosition() //posisi acak berada diluar cliff dan pada FOV default Main Camera
    {
        float randomX = Random.Range(-9,9); // default border sumbu x +-[-10, 10] bisa disesuaikan
        float randomY = Random.Range(-4,4); // default border sumbu y +-[-5, 5] bisa disesuaikan
        
        return new Vector3(randomX, randomY, 0f); //new shepe spawn coordinate 
    }

}
