using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Shoot : MonoBehaviour
{
    public float coolDown = 0.1f;
    float lastFireTime = 0;
    public int defaultAmmo = 120;
    public int magSize = 30;
    public int currentAmmo; //þuan kaç mermim var
    public int currentMagAmmo; // þuanki jarjörümde kaç mermi var
    public Camera camera;
    public int range;
    [Header("Gun Damage On Hit")]
    public GameObject bloodPrefab;
    public GameObject decalPrefab;
    public GameObject magObject;
    public ParticleSystem muzzlePartical;
    public int damage;
 
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo - magSize; //toplam 120 mermi silahýmda 
        currentMagAmmo = magSize; //jarjorde baþlangýçta 30 mermi
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reload
                ();
        }

        if (Input.GetMouseButton(0))
        {
            if (CanFire())
            {
                Fire();
            }
            
        }
    }

    private void Reload()
    {
        if (currentAmmo ==0 && currentMagAmmo == magSize)
        {
            return;

        }
        if (currentAmmo < magSize)
        {
            currentMagAmmo = currentMagAmmo+ currentAmmo;
            currentAmmo = 0;
        }
        else
        {
              currentAmmo -= magSize - currentMagAmmo;
             currentMagAmmo = magSize;
        
        }
       //GameObject newMagObject = Instantiate(magObject);
       // newMagObject.transform.position = magObject.transform.position;
       // newMagObject.AddComponent<Rigidbody>();

    }

    private bool CanFire()
    {
        
        if (currentMagAmmo > 0 && lastFireTime + coolDown < Time.time)
        {
            lastFireTime = Time.time + coolDown;
            return true;
        }
   
        return false;
    }

    private void Fire()
    {
        muzzlePartical.Play(true);
        currentMagAmmo -= 1;
        Debug.Log("Kalan Mermim: " + currentMagAmmo);
        //if (Physics.Raycast(Camera.main.transform.position, transform.forward,out hit, Mathf.Infinity))
        //{
        //    if (hit.collider.gameObject.tag == "Zombie")
        //    {
        //        Destroy(hit.collider.gameObject);
        //    }
        //}
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward, out hit, 10))
        {
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHealth>().Hit(damage);
                GenerateBloodEffect(hit);
            }
             else
             {
            GenerateHitEffect(hit);
             }
        }

        

    }
    

    private void GenerateHitEffect(RaycastHit hit)
    {
        // TODO: Mermi izi oluþtur.
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward * -1, hit.normal);
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
        
    }
}
