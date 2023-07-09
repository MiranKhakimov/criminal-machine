using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class attack_input : MonoBehaviour
{
    public List<GameObject> fireballPrefab;
    public Transform firePointTransform;
    private Vector2 firePoint;
    public List<int> fireballFrames; 
    public GameObject capsule;

    List<List<int>> inputMatrix = new List<List<int>> {new List<int> {7, 8, 9}, new List<int> {4, 5, 6}, new List<int> {1, 2, 3}};
    List<int> framesInput = Enumerable.Repeat(5, 85).ToList();
    List<int> inputForCast;
    int x, y;

    void Start()
    {
        firePoint = firePointTransform.position;
    }
    
    void Update()
    {
        firePoint = firePointTransform.position;
    }

    void FixedUpdate()
    {
        if (capsule.GetComponent<movement>().status == "neutral")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                InputUpdate();
                if (IsSublist(inputForCast, new List<int>{2, 1, 4}) || IsSublist(inputForCast, new List<int>{2, 3, 6}))
                { 
                    GetComponent<FireBall>().Create(fireballPrefab[0], firePoint, capsule, fireballFrames);
                }
            
            }
        }
        
        x = 1;
        y = 1;
        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            y -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y += 1;
        }
        
        framesInput.RemoveAt(0); 
        framesInput.Add(inputMatrix[y][x]);
    }

    void InputUpdate() 
    {
        inputForCast = new List<int>();
        inputForCast.Add(framesInput[0]);
        for (int i = 1; i < framesInput.Count; i++)
        {
            if (framesInput[i] != 5)
            {
                if (framesInput[i] != framesInput[i - 1])
                {
                    inputForCast.Add(framesInput[i]);
                }
            }
        }
    }

    static bool IsSublist<T>(IEnumerable<T> list1, IEnumerable<T> list2)
    {
        int count1 = list1.Count();
        int count2 = list2.Count();

        if (count2 > count1)
            return false;

        for (int i = 0; i <= count1 - count2; i++)
        {
            if (Enumerable.Range(i, count2).Select(index => list1.ElementAt(index)).SequenceEqual(list2))
                return true;
        }

        return false;
    }
}
