using Assets.Builder_mainProject._1Scripts._1DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectService // Service for Project level (Parent)
{ } 
public class MySceneService // Service for Scene level
{
    private readonly MyProjectService _myprojectService;
    public MySceneService(MyProjectService myProjectService)
    {
        this._myprojectService = myProjectService;
    }
}                                     

// Factories
public class MyFactory // some Factory that creates an object (in my case: MyObject)
{
    public MyObject CreateInstance(string id, int par1)
    {
        return new MyObject(id, par1);
    }
}
public class MyObject // the object itself
{
    private readonly string _id;
    private readonly int _par1;

    public MyObject(string id, int par1)
    {
        this._id = id;
        this._par1 = par1;
    }
}


public class DIExampleProject : MonoBehaviour
{
    //registration example

    private void Awake()
    {
        var projectContainer = new DIContainer();
        projectContainer.RegisterSingletone(_ => new MyProjectService()); //Services are usually registred as Singletone
        // В данном случае, код регистрирует сервис MyProjectService как синглтон, что означает, что будет создан только
        // один экземпляр этого сервиса и будет возвращаться при каждом обращении.
        projectContainer.RegisterSingletone("Option_1", _ => new MyProjectService());
        projectContainer.RegisterSingletone("Option_2", _ => new MyProjectService());

        // Когда сцена загрузилась
        var sceneRoot = FindObjectOfType<DIExampleScene>();
        sceneRoot.Init(projectContainer);
    }
}
