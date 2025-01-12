using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cliffdetector : MonoBehaviour
{
    public int maxSheepFalls = 10; // Batas maksimum domba yang boleh jatuh
    private int sheepFallCount = 0; // Counter untuk domba yang jatuh

    private void OnTriggerStay2D(Collider2D other)
    {
        // Periksa jika yang masuk adalah domba atau pemain
        if (other != null && (other.CompareTag("Sheep") || other.CompareTag("Player")))
        {
            Collider2D objectCollider = other.GetComponent<Collider2D>();
            Collider2D cliffCollider = GetComponent<Collider2D>();

            // Pastikan objek masih valid sebelum dilanjutkan
            if (objectCollider == null || cliffCollider == null) return;

            // Buat array untuk menampung collider yang tumpang tindih
            ContactFilter2D filter = new ContactFilter2D();
            Collider2D[] results = new Collider2D[10];
            
            // Periksa apakah semua titik collider objek berada di dalam cliff
            int overlapCount = objectCollider.OverlapCollider(filter, results);
            bool fullyInside = true;

            for (int i = 0; i < overlapCount; i++)
            {
                if (results[i] != cliffCollider)
                {
                    fullyInside = false;
                    break;
                }
            }

            if (fullyInside)
            {
                if (other.CompareTag("Sheep"))
                {
                    // Pastikan objek masih valid sebelum dihancurkan
                    if (other.gameObject != null)
                    {
                        Destroy(other.gameObject); // Hancurkan domba
                        sheepFallCount++; // Tambahkan counter domba yang jatuh
                        Debug.Log("A sheep has fallen off the cliff! Total: " + sheepFallCount);

                        // Periksa apakah jumlah domba yang jatuh mencapai batas
                        if (sheepFallCount >= maxSheepFalls)
                        {
                            Debug.Log("Game Over: Too many sheep have fallen!");
                            GameOver();
                        }
                    }
                }
                else if (other.CompareTag("Player"))
                {
                    Debug.Log("Game Over: The player fell off the cliff!");
                    GameOver();
                }
            }
        }
    }

    private void GameOver()
    {
        // Logika Game Over, misalnya kembali ke menu utama atau restart level
        Debug.Log("Game Over triggered!");
        Time.timeScale = 0f;// Menghentikan semua aktivitas game
        SceneManager.LoadScene(2);
        // Anda juga bisa menampilkan UI Game Over di sini
    }
}
