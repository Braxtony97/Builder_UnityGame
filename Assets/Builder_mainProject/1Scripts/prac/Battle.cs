using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    GameObject _myGameObject;
    //private Person _person = new Person();
    private NonMonoBehaviourPerson _person1 = new NonMonoBehaviourPerson();

    private void Start()
    {
        //_myGameObject = new GameObject("MyGameObject");
        //_person.Attack();
        _person1.Attack();
    }
}
