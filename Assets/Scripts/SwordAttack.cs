using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
   
    public float damage = 1;
   public Collider2D swordCollider;
    Vector2 rightAttackOffset;
    // Start is called before the first frame update
    void Start()
    {
        rightAttackOffset = transform.position;
    }



    public void AttackRight() {
        print("Attack right");
        transform.localPosition = rightAttackOffset;
        swordCollider.enabled = true;
        
    }

    public void AttackLeft(){
        print("Attack left");
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
        swordCollider.enabled = true;
        
    }

    public void StopAttack(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("entered");
       
        if(other.tag == "Enemy") {
        //Deal damage to the enemy.
        Enemy enemy = other.GetComponent<Enemy>();

        if(enemy != null) {
            
            enemy.Health -= damage;
            print(enemy.Health);
            
            }
        }
    }



}



