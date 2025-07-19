
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trombone",
        Price = 150.99M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Trumpet",
        Price = 120.99M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Saxophone",
        Price = 200.00M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "The Road Not Taken",
        Price = 9.99M,
        ProductTypeId = 2,
    },
    new Product()
    {
        Name = "Fire and Ice",
        Price = 11.50M,
        ProductTypeId = 2,
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Title = "Brass",
    },
    new ProductType()
    {
        Id = 2,
        Title = "Poem",
    },
};

//put your greeting here
Console.WriteLine("Welcome to Brass and Poem!");

//implement your loop here
string choice = "";
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    if (choice == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("BYE BYE!!");
    }
}

void DisplayMenu()
{
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        string title = "";

        for (int type = 0; type < productTypes.Count; type++)
        {
            if (product.ProductTypeId == productTypes[type].Id)
            {
                title = productTypes[type].Title;
            }
        }

        Console.WriteLine($"{i + 1}. {product.Name}||${product.Price:F2}||Type: {title}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Which one to delete?");
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        string typeTitle = "";

        for (int type = 0; type < productTypes.Count; type++)
        {
            if (product.ProductTypeId == productTypes[type].Id)
            {
                typeTitle = productTypes[type].Title;
            }
        }

        Console.WriteLine($"{i + 1}. {product.Name}||${product.Price:F2}||Type: {typeTitle}");
    }

    string input = Console.ReadLine();
    int selection = int.Parse(input);

    string deleted = products[selection - 1].Name;
    products.RemoveAt(selection - 1);

    Console.WriteLine($"{deleted} has been vanquished");
    
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Name of Product: ");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the Price: ");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Choose Product Type: ");

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }

    int typeChoice = int.Parse(Console.ReadLine());
    int productTypeId = productTypes[typeChoice - 1].Id;

    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        ProductTypeId = productTypeId
    };

    products.Add(newProduct);
    Console.WriteLine($"{name} has been added");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Which product to update?");
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        string title = "";
        for (int type = 0; type < productTypes.Count; type++)
        {
            if (productTypes[type].Id == product.ProductTypeId)
            {
                title = productTypes[type].Title;
            }
        }

        Console.WriteLine($"{i + 1}. {product.Name}||${product.Price:F2}||Type: {title}");
    }

    string input = Console.ReadLine();
    int num = int.Parse(input);

    Product selection = products[num - 1];

    Console.WriteLine($"Current name: {selection}");
    Console.WriteLine("Enter new name: ");
    string name = Console.ReadLine();
    if (name != "")
    {
        selection.Name = name;
    }

    Console.WriteLine($"Current Price: {selection.Price}");
    Console.WriteLine("Enter new price: ");
    string priceInput = Console.ReadLine();
    if (priceInput != "")
    {
        selection.Price = decimal.Parse(priceInput);
    }

    string typeInput = Console.ReadLine();
    if (typeInput != "")
    {
        int typeChoice = int.Parse(typeInput);
        selection.ProductTypeId = productTypes[typeChoice - 1].Id;
    }

    Console.WriteLine("Updated!");
}

// don't move or change this!
public partial class Program { }
