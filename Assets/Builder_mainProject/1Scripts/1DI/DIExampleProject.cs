using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Builder_mainProject._1Scripts._1DI
{
    public class MyAwesomeProjectService { } // Сервис для уровня проекта

    public class MySceneService // Сервис уровня сцены. У нее есть ссылка на сервис уровня проекта
    {
        private readonly MyAwesomeProjectService _myAwesomeProjectService;

        public MySceneService (MyAwesomeProjectService myAwesomeProjectService)
        {
            _myAwesomeProjectService = myAwesomeProjectService;
        }
    }

    public class MyAwesomeFactory 
    {
        public MyAwesomeObject CreateInstance(string id, int par1) // Создаем фабрику
        {
            return new MyAwesomeObject(id, par1);
        }
    } // Фабрика, который создает объект (в данной случае: MyAwesomeObject)

    public class MyAwesomeObject
    {
        private readonly string _id;
        private readonly int _par1;

        public MyAwesomeObject (string id, int par1)
        {
            this._id = id;   
            this._par1 = par1;
        }
    } // Сам объект 

    public class DIExampleProject : MonoBehaviour
    {

        //Регистрация
        private void Awake()
        {
            var projectContainer = new DIContainer();
            projectContainer.RegisterSingletone<MyAwesomeProjectService>(_ => new MyAwesomeProjectService());
        }

    }
}
