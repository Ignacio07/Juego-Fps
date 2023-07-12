using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Interactable
{
    public GameObject player;
    private Gun gun;
    public int dropAmmo = 15;
    private AudioSource audioSource;
    public AudioClip reloadSound;
    public AudioClip errorSound;
    // Start is called before the first frame update
    void Start()
    {
        gun = player.GetComponent<Gun>();
        audioSource = player.GetComponent<AudioSource>();
    }
    protected override void Interact()
    {
        if (gun.maxAmmo != gun.ammo)
            {
                audioSource.clip = reloadSound;
                if ((gun.maxAmmo - gun.ammo) < dropAmmo)
                {
                    gun.ammo = gun.ammo + (gun.maxAmmo - gun.ammo);
                }
                else
                {
                    gun.ammo = gun.ammo + dropAmmo;
                }
            }
            else
            {
                audioSource.clip = errorSound;
            }
            audioSource.Play();
            gun.ammoDisplay.text = gun.ammo.ToString() + " / " + gun.maxAmmo.ToString();
        Debug.Log("Interacci�n con " + gameObject.name);
    }
}