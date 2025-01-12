// Nama File: panicstate.cs
// Fungsi: State sheep saat berada pada range hantaman meteor
using UnityEngine;

public class PanicState : ISheepState
{
    private float panicDuration;
    private Vector3 randomDirection;

    public PanicState(float duration)
    {
        panicDuration = duration;
    }

    public void EnterState(SheepStateManager sheep)
    {
        SetRandomDirection();
    }

    public void UpdateState(SheepStateManager sheep)
    {
        // Lari secara acak
        sheep.rb.velocity = randomDirection * 5f;

        // Kurangi durasi panic
        panicDuration -= Time.deltaTime;
        if (panicDuration <= 0)
        {
            sheep.SwitchState(new IdleState());
        }

        // Ubah arah secara berkala
        if (Random.Range(0f, 1f) < 0.05f)
        {
            SetRandomDirection();
        }
    }

    public void ExitState(SheepStateManager sheep)
    {
        // Tidak ada logika tambahan saat keluar dari Panic
    }

    private void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
