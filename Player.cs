using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _basedamage;
        private Item[] _inventory;
        private Item _currentweapon;
        private Item _hands;

        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _basedamage = 10;
            _hands.name = "Fist-I-Cuffs";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
        {
            _name = nameVal;
            _health = healthVal;
            _basedamage = damageVal;
            _inventory = new Item[inventorySize];
            _hands.name = "Fist-I-Cuffs";
            _hands.statBoost = 0;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex) == true)
            {
                _currentweapon = _inventory[itemIndex];
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
        
        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void UnequipItem()
        {
            _currentweapon = _hands;
        }

        public void RemoveItem(int index)
        {
            _inventory[index] = _hands;
        }
        public void MoveItem(int from, int to)
        {
            _inventory[to] = _inventory[from];
            RemoveItem(from);
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _basedamage + _currentweapon.statBoost;
            enemy.TakeDamage(totalDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + (_basedamage + _currentweapon.statBoost));
        }

        private void TakeDamage(int damageVal)
        {
            if(GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!!!");
        }
    }
}
