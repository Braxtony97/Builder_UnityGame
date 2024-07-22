using System.Collections.Generic;
using UnityEngine;

namespace Assets.Builder_mainProject._1Scripts._2DIPractice
{
    internal class InventoryService : IInventoryService
    {
        private List<string> _inventory = new();

        public void AddItem(string item)
        {
            _inventory.Add(item);
            Debug.Log("Item added: " +  item);
        }
    }
}
