using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public void Create(GameObject fireballPrefab, Vector2 firePoint, GameObject characterDirection, List<int> frames)
    {
        var fireball = Instantiate(fireballPrefab, firePoint, Quaternion.identity);
        fireball.GetComponent<FireballMovement>().SetOrientation(characterDirection.GetComponent<movement>().faceRight);
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
