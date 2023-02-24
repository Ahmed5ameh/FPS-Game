using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolFire : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject myPistol;
    public bool isFiring = false;
    public GameObject muzzleFlash;
    public AudioSource pistolShot;
    public float toTarget;

    public GameObject ammoTextUI;
    public int pistolCount = 50;

    RaycastHit hit;
    /*
    public float health = 100;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    */

    void Start()
    {
        //slider.value = health;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }
        ammoTextUI.GetComponent<Text>().text = "AMMO: " + pistolCount + "\n" + "DISTANCE: " + (int) toTarget;
        /*//SLIDER UI SETTINGS
        slider.value = health;
        if (health < maxHealth){
            healthBarUI.SetActive(true);
        }
        if (health <= 0){
            Destroy(gameObject);
        }
        if (health > maxHealth) {
            health = maxHealth;
        }
        float CalculateHealth(){
            return health / maxHealth; //%
        }
        */
    }
    IEnumerator FireThePistol()
    {
        isFiring = true;
        pistolCount -= 1;
        toTarget = PlayerCasting.distanceFromTarget;
        myPistol.GetComponent<Animator>().Play("FirePistol");
        pistolShot.Play();
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.22f);
        myPistol.GetComponent<Animator>().Play("New State");
        if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.tag == "Enemy" && isFiring == true)
        {
            Debug.Log("I HIT ENEMY");
            EnemyHealth.FindObjectOfType<Slider>().value -= 10;
            if(EnemyHealth.FindObjectOfType<Slider>().value == 0)
            {
                EnemyHealth.FindObjectOfType<Animator>().Play("Die 0");
            }
        }
        isFiring = false;
    }
}
