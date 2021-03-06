﻿using System;
using System.Linq;
using System.Collections.Generic;
namespace SQL_Program
{
    class TableData
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public TableData(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My SQL Program");
            Console.WriteLine("List of tables:");
            Console.WriteLine("     items");
            Console.WriteLine("     categories");
            Console.WriteLine("     customers");
            Console.WriteLine("     basket");
            Console.WriteLine("     basket_items");
            Console.WriteLine("List of commands:");
            Console.WriteLine("     Show (table) - To show all listings of a table");
            Console.WriteLine("     Add (table) - To show all listings of a table");
            Console.WriteLine("     Remove (table) - To show all listings of a table");
            Console.WriteLine("     Quit - Quit the program");
            while (true)
            {
                Console.Write(" $ ");
                string userInput = Console.ReadLine().ToLower();
                string[] inputArgs = userInput.Split(" ");
                if (inputArgs.Length > 1)
                {
                    switch (inputArgs[0])
                    {
                        case "show":
                            string showQuery = "";
                            switch (inputArgs[1])
                            {
                                case "items":
                                    showQuery = @"SELECT items.id, items.name, categories.name as 'category'
                                                    FROM items
                                                    INNER JOIN categories
                                                    ON categories.id = items.category_id";
                                    break;
                                case "categories":
                                    showQuery = @"SELECT * from categories";
                                    break;
                                case "customers":
                                    showQuery = @"SELECT * from customers";
                                    break;
                                case "basket":
                                    showQuery = @"SELECT baskets.id, customers.firstName || ' ' ||customers.lastName as Customer
                                                    FROM baskets
                                                    INNER JOIN customers
                                                    ON customers.id = baskets.customer_id";
                                    break;
                                case "basket_items":
                                    showQuery = @"SELECT basket_items.id, baskets.id as basketId, customers.firstName || ' ' || customers.lastName as Customer, items.name as itemName
                                                    FROM basket_items
                                                        INNER JOIN baskets
                                                            ON baskets.id = basket_items.basket_id
                                                        INNER JOIN customers
                                                            ON customers.id = basket_items.customer_id
                                                        INNER JOIN items
                                                            ON items.id == basket_items.item_id";
                                    break;
                                case "sub":
                                    showQuery = @"SELECT * FROM items,
                                                    (SELECT * FROM categories),
                                                    (SELECT * FROM customers),
                                                    (SELECT * FROM baskets),
                                                    (SELECT * FROM basket_items)";
                                    break;
                                case "view":
                                    showQuery = @"SELECT * FROM v_customers";
                                    break;
                                default:
                                    Console.WriteLine("Invalid table");
                                    break;
                            }


                            Records records = Database.GetRecords(showQuery);
                            if (records != null)
                                PrettyPrintRecords(records);
                            break;
                        case "add":
                            // Get all the fields that has to be added and what datatypes they have
                            Records tableInfo = Database.GetRecords($"pragma table_info('{inputArgs[1]}')");
                            if (tableInfo != null)
                            {
                                if (tableInfo.Count > 0)
                                {
                                    List<TableData> tableDatas = new List<TableData>();
                                    foreach (var record in tableInfo)
                                    {
                                        if (record["pk"] == "1") continue;
                                        tableDatas.Add(new TableData(record["name"], record["type"]));
                                    }
                                    Console.WriteLine("Type in the values to be added");
                                    foreach (var item in tableDatas)
                                    {
                                        Console.Write($"{item.Name} : ");
                                        var dataInput = Console.ReadLine();

                                        item.Value = dataInput;
                                    }
                                    string[] fields = tableDatas.Select(i => i.Name).ToArray();
                                    string[] values = tableDatas.Select(i => i.Value).ToArray();
                                    string query = $"INSERT INTO {inputArgs[1]} ({string.Join(", ", tableDatas.Select(i => i.Name).ToArray())}) VALUES (";
                                    foreach (var item in tableDatas)
                                    {
                                        query += (item.DataType != "INTEGER") ? $"'{item.Value}'{((item != tableDatas.Last()) ? "," : "")}" : item.Value + ((item != tableDatas.Last()) ? "," : "");
                                    }
                                    query += ")";
                                    Database.Execute(query);
                                    Console.WriteLine("Successfully inserted data");
                                }
                                else Console.WriteLine($"No records for {inputArgs[1]}");
                            }

                            break;
                        case "remove":
                            PrettyPrintRecords(Database.GetRecords($"SELECT * FROM {inputArgs[1]}"));
                            Console.WriteLine("Select the ID of the row you want to remove");
                            int idSelection;
                            while (true)
                            {
                                Console.Write("ID: ");
                                if (Int32.TryParse(Console.ReadLine(), out idSelection))
                                    break;
                                else Console.WriteLine("That is not an ID!");
                            }
                            Database.Execute($"DELETE FROM {inputArgs[1]} WHERE Id={idSelection}");
                            Console.WriteLine($"Removed row with the id {idSelection}");
                            break;
                        default:
                            Console.WriteLine($"{userInput}, is not a command!");
                            break;
                    }
                }
                else if(inputArgs[0] == "quit")
                {
                    break;
                }
                else Console.WriteLine("Command requires table");
            }
        }

        static void PrettyPrintRecords(Records records)
        {
            // Get all the fields first for formatting
            const int columnFormatLength = 26;

            if (records.Count > 0)
            {
                foreach (var field in records[0])
                {
                    Console.Write($"{field.Key, -columnFormatLength}");
                }
                Console.WriteLine();
                foreach (var row in records)
                {
                    foreach (var data in row)
                    {
                        Console.Write($"{data.Value, -columnFormatLength}");
                    }
                    Console.WriteLine();
                }
            }
        }


        static void AddSampleData()
        {
            Database.Execute("INSERT INTO categories (name) VALUES ('Electronics')");
            Database.Execute("INSERT INTO categories (name) VALUES ('Convenience')");
            Database.Execute("INSERT INTO categories (name) VALUES ('Agriculture')");


            Database.Execute("INSERT INTO items (name, category_id) VALUES ('USB 16GB', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('USB 32GB', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('USB 64GB', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('USB 128GB', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Lenovo Laptop 256 GB SSD', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Logitech mouse 3000', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Mobile Charger', 1)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Mobile Charger', 1)");

            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Sack of potatoes(24)', 2)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('One tomato', 2)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Honning melon', 2)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Squash', 2)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Apples', 2)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('porrer', 2)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Plante lol', 2)");

            Database.Execute("INSERT INTO items (name, category_id) VALUES ('Kæmpe traktor', 3)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('lille traktor', 3)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('have slange', 3)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('græs', 3)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('skovl', 3)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('stor skovl v2', 3)");
            Database.Execute("INSERT INTO items (name, category_id) VALUES ('deluxe græsslås maskine', 3)");

            Database.Execute("INSERT INTO customers (firstName, lastName, zipCode) VALUES ('John', 'Johnson', 7500)");
            Database.Execute("INSERT INTO customers (firstName, lastName, zipCode) VALUES ('Bent', 'Bentsen', 7500)");
            Database.Execute("INSERT INTO customers (firstName, lastName, zipCode) VALUES ('Citron', 'Melon', 7500)");
            Database.Execute("INSERT INTO customers (firstName, lastName, zipCode) VALUES ('Henning', 'Henningsens', 7500)");
            Database.Execute("INSERT INTO customers (firstName, lastName, zipCode) VALUES ('Palle', 'Palle', 7500)");
            Database.Execute("INSERT INTO customers (firstName, lastName, zipCode) VALUES ('Brian', 'Magnet', 7500)");
            
            Database.Execute("INSERT INTO baskets (customer_id) VALUES (1)");
            Database.Execute("INSERT INTO baskets (customer_id) VALUES (2)");
            Database.Execute("INSERT INTO baskets (customer_id) VALUES (3)");
            
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (1, 1, 1)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (1, 1, 2)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (1, 1, 3)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (1, 1, 4)");

            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (2, 2, 5)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (2, 2, 6)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (2, 2, 7)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (2, 2, 8)");

            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (3, 3, 9)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (3, 3, 10)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (3, 3, 11)");
            Database.Execute("INSERT INTO basket_items (basket_id, customer_id, item_id) VALUES (3, 3, 12)");





        }
    }
}
