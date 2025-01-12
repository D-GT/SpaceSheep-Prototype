// Nama File: runstate.cs
// Fungsi: State dari sheep ketika didekati anjing
using UnityEngine;

public class RunState : ISheepState
{
    private Transform dogTransform;

    public RunState(Transform dog)
    {
        dogTransform = dog;
    }

    public void EnterState(SheepStateManager sheep)
    {
        // Tidak ada logika tambahan saat masuk Run
    }

    public void UpdateState(SheepStateManager sheep)
    {
        // Lari ke arah yang sama dengan arah kepala anjing
        Vector3 dogForward = dogTransform.up; // Asumsi sumbu Y adalah arah kepala anjing
        sheep.rb.velocity = dogForward * 5f; // Kecepatan lari

        // Jika anjing keluar dari radius, kembali ke Idle
        float distanceToDog = Vector3.Distance(sheep.transform.position, dogTransform.position);
        if (distanceToDog > sheep.detectionRadius)
        {
            sheep.SwitchState(new IdleState());
        }
    }

    public void ExitState(SheepStateManager sheep)
    {
        // Tidak ada logika tambahan saat keluar dari Run
    }
}
