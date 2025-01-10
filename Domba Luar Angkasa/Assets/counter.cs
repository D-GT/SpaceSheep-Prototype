using UnityEngine;
using UnityEngine.UI; // Tambahkan ini untuk Text

public class Cliff : MonoBehaviour
{
    public Text sheepCounterText; // Tambahkan referensi ke Text
    private int sheepFallCount = 0; // Counter untuk sheep yang jatuh

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Sheep"))
        {
            Destroy(other.gameObject); // Hancurkan domba
            sheepFallCount++; // Tambahkan counter

            // Perbarui teks di UI
            UpdateSheepCounterText();

            Debug.Log("A sheep has fallen off the cliff!");
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over: The player fell off the cliff!");
            // Tambahkan logika Game Over di sini
        }
    }

    private void UpdateSheepCounterText()
    {
        if (sheepCounterText != null)
        {
            sheepCounterText.text = "Sheep Fallen: " + sheepFallCount;
        }
    }
}
