// Nama File: Meteorkambing.cw
// Fungsi: Mengenerate meteor
// Status saat ini : Belum di-implementasikan ke dalam game

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class meteorkambing : MonoBehaviour
{
    public GameObject spriteLingkaran;
    public GameObject spriteMeteor;
    public Rigidbody2D rbMeteor;
    public SpriteRenderer spriteRen;
    // public Rigidbody2D rbLingkaran;
    public float xDimensionMin;
    public float xDimensionMax;
    public float yDimensionMin;
    public float yDimensionMax;
    public float movementSpeed;
    public float frekuensiMeteor;
    public float jarakMeteor;
    public float stayMeteor;
    public bool coroutine1Running = false;
    public bool coroutine2Running = false;
    // Start is called before the first frame update
    IEnumerator moveMeteor()
    {
        float startTime = Time.time;
        float endTime = startTime + jarakMeteor/movementSpeed;
        while (Time.time<endTime)
        {
            coroutine1Running = true;
            spriteRen.enabled = true;
            rbMeteor.velocity = Vector2.left*movementSpeed+Vector2.down*movementSpeed;
            yield return null;
        }
        rbMeteor.velocity = Vector2.left*0f;
        Destroy(spriteMeteor, stayMeteor);
        
    }
    IEnumerator moveMeteor2()
    {
        float startTime = Time.time;
        float endTime = startTime + jarakMeteor/movementSpeed;
        while (Time.time<endTime)
        {
            coroutine2Running = true;
            spriteRen.enabled = true;
            rbMeteor.velocity = Vector2.left*movementSpeed+Vector2.down*movementSpeed;
            yield return null;
        }
        rbMeteor.velocity = Vector2.left*0f;
        Destroy(spriteMeteor, stayMeteor);
        
    }
    IEnumerator ir()
    {
        while (true)
        {
            yield return new WaitForSeconds(frekuensiMeteor);
            float x = UnityEngine.Random.Range(xDimensionMin, xDimensionMax);
            float y = UnityEngine.Random.Range(yDimensionMin, yDimensionMax);
            Vector2 posisiLingkaran = new Vector2(x, y);
            Vector2 posisiMeteor = new Vector2(x+jarakMeteor, y+jarakMeteor);
            // Instantiate(spriteLingkaran, posisiLingkaran, Quaternion.identity);
            spriteLingkaran.transform.position = posisiLingkaran;
            spriteRen.enabled = false;
            Instantiate(spriteMeteor, posisiMeteor, quaternion.identity);
            if (coroutine1Running == false)
            {
                StartCoroutine(moveMeteor());
            }
            else if (coroutine2Running == false)
            {
                StartCoroutine(moveMeteor2());
            }
            // Destroy(spriteLingkaran, stayMeteor);
            
            
        }
    }

    void Start()
    {
        StartCoroutine(ir());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
