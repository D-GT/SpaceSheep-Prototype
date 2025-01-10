using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliffdetector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        // Periksa jika yang masuk adalah domba atau pemain
        if (other.CompareTag("Sheep") || other.CompareTag("Player"))
        {
            Collider2D objectCollider = other.GetComponent<Collider2D>();
            Collider2D cliffCollider = GetComponent<Collider2D>();

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
                    Destroy(other.gameObject); // Hancurkan domba
                    Debug.Log("A sheep has fallen off the cliff!");
                }
                else if (other.CompareTag("Player"))
                {
                    Debug.Log("Game Over: The player fell off the cliff!");
                    // Tambahkan logika Game Over di sini
                }
            }
        }
    }
}