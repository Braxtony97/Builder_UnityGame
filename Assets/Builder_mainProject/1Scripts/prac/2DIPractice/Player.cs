
namespace Assets.Builder_mainProject._1Scripts._2DIPractice
{
    public class Player
    {
        private readonly IHealthService _healthService;
        private readonly IInventoryService _inventoryService;

        public Player(IHealthService healthService, IInventoryService inventoryService)
        {
            _healthService = healthService;
            _inventoryService = inventoryService;
        }

        public void TakeDamage(int damage)
        {
            _healthService.TakeDamage(damage);
        }

        public void AddInventory(string item)
        {
            _inventoryService.AddItem(item);
        }
    }
}
