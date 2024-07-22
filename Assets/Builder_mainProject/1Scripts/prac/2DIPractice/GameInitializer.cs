using TMPro.EditorUtilities;
using UnityEngine;

namespace Assets.Builder_mainProject._1Scripts._2DIPractice
{
    public class GameInitializer : MonoBehaviour
    {
        private DIContainerPractice _container;
        private void Awake()
        {
            // Использование DIContainer
            _container = new();

            // Регистрация зависимостей
            _container.Register<IHealthService>(() => new HealthService());
            _container.Register<IInventoryService>(() => new InventoryService());

            var player = new Player(_container.Resolve<IHealthService>(), _container.Resolve<IInventoryService>());



            //// Ручное создание экземпляров и их прокидывание 
            //IHealthService healthService = new HealthService();
            //IInventoryService inventoryService = new InventoryService();

            //Player player = new(healthService, inventoryService);

            player.TakeDamage(34);
            player.AddInventory("Sword");
        }
    }
}
