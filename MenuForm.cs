using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ресторан_проект.LoginForm;

namespace ресторан_проект
{
    public partial class MenuForm : Form
    {
        private readonly User currentUser;
        private readonly List<MenuItem> menuItems;
        private readonly List<MenuItem> cartItems = new List<MenuItem>();

        public MenuForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            menuItems = MenuService.GetMenuItems();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            listBoxMenu.DisplayMember = "Name";
            listBoxCart.DisplayMember = "DisplayText";
            LoadMenuItems();
            UpdateTotalPrice();
        }

        private void LoadMenuItems()
        {
            listBoxMenu.Items.Clear();
            foreach (var item in menuItems)
            {
                listBoxMenu.Items.Add(item);
            }
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (listBoxMenu.SelectedItem == null)
            {
                MessageBox.Show("Выберите блюдо из меню", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = (MenuItem)listBoxMenu.SelectedItem;
            cartItems.Add(selectedItem);
            UpdateCartDisplay();
            UpdateTotalPrice();
        }

        private void buttonRemoveFromCart_Click_1(object sender, EventArgs e)
        {
            if (listBoxCart.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите блюдо из корзины", "Внимание",
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedText = listBoxCart.SelectedItem.ToString();
            string itemName = selectedText;
            int itemCount = 1;

            if (selectedText.Contains(" - "))
            {
                var parts = selectedText.Split( " - " , StringSplitOptions.None);
                itemName = parts[0];

                if (parts[1].EndsWith(" шт."))
                {
                    var countStr = parts[1].Replace(" шт.", "");
                    int.TryParse(countStr, out itemCount);
                }
            }
            var menuItem = menuItems.FirstOrDefault(m => m.Name == itemName);
            if (menuItem == null)
            {
                MessageBox.Show("Не удалось найти выбранный товар в меню", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var itemToRemove = cartItems.FirstOrDefault(item => item.Id == menuItem.Id);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
            UpdateCartDisplay();
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            int total = 0;
            foreach (var item in cartItems)
            {
                total += item.Price;
            }

            labelTotal.Text = $"Итого: {total:C}";
            labelTotal.Visible = cartItems.Count > 0;
            buttonPlaceOrder.Enabled = cartItems.Count > 0;
            buttonClearCart.Enabled = cartItems.Count > 0;
        }

        private void buttonPlaceOrder_Click_1(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Корзина пуста", "Внимание",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var itemGroups = new Dictionary<int, CartItemGroup>();
            foreach (var item in cartItems)
            {
                if (itemGroups.ContainsKey(item.Id))
                {
                    itemGroups[item.Id].Count++;
                }
                else
                {
                    itemGroups.Add(item.Id, new CartItemGroup
                    {
                        MenuItem = item,
                        Count = 1
                    });
                }
            }
            var orderLines = new List<string>();
            int totalPrice = 0;
            foreach (var group in itemGroups.Values)
            {
                string line = group.Count > 1 ? $"{group.MenuItem.Name} ({group.Count} шт.) - {group.MenuItem.Price * group.Count:C}" : $"{group.MenuItem.Name} - {group.MenuItem.Price:C}";
                orderLines.Add(line);
                totalPrice += group.MenuItem.Price * group.Count;
            }

            string orderDescription = "Ваш заказ:\n\n" + string.Join("\n", orderLines) + $"\n\nОбщая сумма: {totalPrice:C}";

            var result = MessageBox.Show(orderDescription + "\n\nПодтвердить заказ?", "Подтверждение заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            try
            {
                OrderForm.OrderService.AddOrder(currentUser.Id, orderDescription);
                MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay()
        {
            listBoxCart.Items.Clear();

            // Группировка товаров по ID
            var itemGroups = new Dictionary<int, CartItemGroup>();
            foreach (var item in cartItems)
            {
                if (itemGroups.ContainsKey(item.Id))
                {
                    itemGroups[item.Id].Count++;
                }
                else
                {
                    itemGroups.Add(item.Id, new CartItemGroup
                    {
                        MenuItem = item,
                        Count = 1
                    });
                }
            }
            // Добавление элементов в корзину
            foreach (var group in itemGroups.Values)
            {
                string displayText = group.Count > 1  ? $"{group.MenuItem.Name} - {group.Count} шт." : group.MenuItem.Name;

                listBoxCart.Items.Add(displayText);
            }
        }

        private void ClearCart()
        {
            cartItems.Clear();
            listBoxCart.Items.Clear();
            UpdateTotalPrice();
        }

        private void buttonClearCart_Click_1(object sender, EventArgs e)
        {
            if (cartItems.Count == 0) return;

            var result = MessageBox.Show("Очистить корзину?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearCart();
            }
        }

        // Вспомогательный класс для группировки товаров
        private class CartItemGroup
        {
            public MenuItem MenuItem { get; set; }
            public int Count { get; set; }
        }

        public class MenuItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }

        public static class MenuService
        {
            private static readonly List<MenuItem> items = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Стейк из говядины", Description = "Нежный стейк с овощами гриль", Price = 1200 },
                new MenuItem { Id = 2, Name = "Салат Цезарь", Description = "С курицей, листьями салата и соусом", Price = 450 },
                new MenuItem { Id = 3, Name = "Тирамису", Description = "Классический итальянский десерт", Price = 350 },
                new MenuItem { Id = 4, Name = "Пицца Маргарита", Description = "Томаты, моцарелла, базилик", Price = 650 },
                new MenuItem { Id = 5, Name = "Суп Том Ям", Description = "Острый тайский суп с морепродуктами", Price = 550 },
                new MenuItem { Id = 6, Name = "Полина в панировке ", Description = "осторожно может укусить", Price = 1500000}
            };

            public static List<MenuItem> GetMenuItems() => new List<MenuItem>(items);
        }

        private void MenuForm_Load(object sender, EventArgs e) { }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void MenuForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}