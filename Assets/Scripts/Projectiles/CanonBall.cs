using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    private Vector3 shootDir;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * speed * Time.deltaTime;
    }
}
