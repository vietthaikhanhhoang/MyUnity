using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class enemyHeath : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    //Kb cac bien UI
    public GameObject enemyHealthEF;

    //Kb cac bien UI
    public Slider enemyHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamge(float damage){
        currentHealth -= damage;

        enemyHealthSlider.value = currentHealth;

        if(currentHealth <= 0) {
            makeDeath();
        }
    }

    void makeDeath(){
        Destroy(gameObject);

        //Hieu ung enemy bi tieu diet
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
