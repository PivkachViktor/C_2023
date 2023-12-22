using ConsoleApp1.Commands;
using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        // Створення списку покупок поза циклом
        ShoppingList shoppingList = new ShoppingList();

        // Створення менеджера команд
        CommandManager commandManager = new CommandManager();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("======== Shopping List Menu ========");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Edit Item");
            Console.WriteLine("3. Delete Item");
            Console.WriteLine("4. Undo");
            Console.WriteLine("5. Redo");
            Console.WriteLine("6. Exit");
            Console.WriteLine("7. allList");
            Console.WriteLine("===================================");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter item name: ");
                    string itemName = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    ShoppingItem newItem = new ShoppingItem(itemName, quantity, false);
                    ICommand addCommand = new AddCommand(shoppingList, newItem);
                    commandManager.ExecuteCommand(addCommand);
                    break;

                case "2":
                    Console.WriteLine("Enter the index of the item to edit:");
                    if (int.TryParse(Console.ReadLine(), out int editIndex) && editIndex >= 0 && editIndex < shoppingList.Count)
                    {
                        Console.Write("Enter new item name: ");
                        string newEditName = Console.ReadLine();
                        Console.Write("Enter new quantity: ");
                        int newQuantity = int.Parse(Console.ReadLine());
                        ShoppingItem editedItem = new ShoppingItem(newEditName, newQuantity, false);
                        ShoppingItem oldItem = shoppingList.GetItemByIndex(editIndex); // Отримати старий елемент для скасування
                        ICommand editCommand = new EditCommand(shoppingList, oldItem, editedItem);
                        commandManager.ExecuteCommand(editCommand);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please enter a valid index.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Enter the index of the item to delete:");
                    if (int.TryParse(Console.ReadLine(), out int deleteIndex) && deleteIndex >= 0 && deleteIndex < shoppingList.Count)
                    {
                        ShoppingItem deletedItem = shoppingList.GetItemByIndex(deleteIndex); // Отримати видаляємий елемент для скасування
                        ICommand deleteCommand = new DeleteCommand(shoppingList, deletedItem);
                        commandManager.ExecuteCommand(deleteCommand);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please enter a valid index.");
                    }
                    break;


                case "4":
                    commandManager.UndoLastCommand();
                    break;

                case "5":
                    commandManager.RedoLastUndoneCommand();
                    break;

                case "6":
                    exit = true;
                    break;
                case "7":
                    shoppingList.DisplayList();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
