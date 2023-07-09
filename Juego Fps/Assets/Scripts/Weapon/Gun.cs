using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    public Animator animator;
    public Camera Cam;
    private Vector3 destination;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 10;
    private bool animatorBool;
    public TextMeshProUGUI ammoDisplay;
    public int ammo = 15;
    public int maxAmmo = 100;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public float fireDelay = 0.4f; // Delay entre disparos en segundos
    public Image cooldownBar;
    private float lastFireTime; // Tiempo del último disparo
    public PauseMenu pauseMenu;

    void Start()
    {
        ammoDisplay.text = ammo.ToString() + " / " + maxAmmo.ToString();
        animatorBool = false;
        lastFireTime = -fireDelay; // Establecer un tiempo inicial que permita disparar inmediatamente al inicio
    }

    void Update()
    {
        if (animatorBool == true)
        {
            animatorBool = false;
        }

        float timeSinceLastFire = Time.time - lastFireTime;
        float cooldownRemaining = Mathf.Max(0f, fireDelay - timeSinceLastFire);
        float cooldownPercentage = cooldownRemaining / fireDelay;

        // Actualizar la barra de progreso
        cooldownBar.fillAmount = cooldownPercentage;

        if (timeSinceLastFire >= fireDelay)
        {
            if (Input.GetMouseButtonDown(0) && ammo > 0 && pauseMenu.GameIsPaused == false)
            {
                animatorBool = true;
                FireBullet();
                ammo--;
                ammoDisplay.text = ammo.ToString() + " / " + maxAmmo.ToString();
                lastFireTime = Time.time;
            }
        }

        animator.SetBool("Shoot", animatorBool);
    }


    void FireBullet()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
        Ray ray = Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            destination = hit.point;
        }
        else{
            destination = ray.GetPoint(1000);
        }
        InstantiateBullet(firePoint);
    }

    void InstantiateBullet(Transform firePoint)
    {
        var bulletObj = Instantiate (bullet, firePoint.position, Quaternion.identity) as GameObject;
        bulletObj.transform.LookAt(destination);
        bulletObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * bulletSpeed;
    }
}
