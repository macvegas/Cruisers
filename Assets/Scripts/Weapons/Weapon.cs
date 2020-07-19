using System.Collections;
using System.Diagnostics;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;
    public float coolDownTime;
    public bool canShoot;
    public float projectileSpeed;
    public float projectileCount;
    public Vector3 direction;

    protected abstract void Shoot();

    public void TryShoot()
    { 
        if(canShoot)
        {
            Shoot();
            StartCoroutine(StartCoolDown());
        }
    }

    private IEnumerator StartCoolDown()
    {
        canShoot = false;

        float time = 0f;

        while (time < coolDownTime)
        {
            //TODO rafraichir l'affichage pour montrer cb de temps il reste
            time += Time.deltaTime;
            yield return null;
        }
        canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
