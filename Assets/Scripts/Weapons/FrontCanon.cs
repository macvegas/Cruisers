using UnityEngine;

public class FrontCanon : Weapon
{
    protected override void Shoot()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        direction = WeaponDirEnum.Forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
