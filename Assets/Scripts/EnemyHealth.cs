using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float health = 99;
    public float maxHealth = 100;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        //health = maxHealth;
        //slider.value = health;
    }

    void update()
    {
        //slider.value = CalculateHealth();
        slider.value = health;
        //slider.SetValueWithoutNotify(CalculateHealth());
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > maxHealth)
        {
            health = maxHealth;

        }
        float CalculateHealth()
        {
            return health / maxHealth; //%
        }
    }
}
