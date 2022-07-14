namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Node? root = null;          
            bool z = false;
            
            while (z == false)
            {
                root = null;
                while (true)
                {
                    Console.WriteLine("Введите Имя сотрудника");
                    var name = Console.ReadLine();
                    int pay = 0;
                    if (name == "")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите зарплату сотрудника");
                        while(!int.TryParse(Console.ReadLine(),out pay))
                        {
                            Console.WriteLine("Укажите число! Введите зарплату сотрудника");
                        }
                    }
                    if (root == null)
                    {
                        root = new Node
                        {
                            Pay = pay,
                            Name = name
                        };
                    }
                    else
                    {
                        AddNode(root, new Node
                        {
                            Name = name,
                            Pay = pay
                        });
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Отсортированные зарплаты: ");
                Traverse(root);

                z = true;
                while (z == true)
                {
                    Console.WriteLine("Какую зарплату ищем?");
                    int n = 0;
                    while (!int.TryParse(Console.ReadLine(), out n))
                    {
                        Console.WriteLine("Укажите число! Какую зарплату ищем?");
                    }
                    var node = Find(root, n);
                    if (node != null)
                    {
                        Console.WriteLine("Имя: " + node.Name);
                    }
                    else
                    {
                        Console.WriteLine("Такой сотрудник не найден");
                    }

                    Console.WriteLine("0 для выхода, 1 для продолжения ");
                    int x = 0;
                    while (!int.TryParse(Console.ReadLine(), out x))
                    {
                        Console.WriteLine("Укажите число! 0 для выхода, 1 для продолжения ");
                    }
                    if (x == 0)
                    {
                        z = false;
                    }
                    if (x == 1)
                    {
                        z = true;
                    }
                }
            }

            static Node Find(Node node, int needle)
            {
                if (needle < node.Pay)
                {
                    // ищем в левом поддереве
                    if (node.Left == null)
                    {
                        return null;
                    }
                    return Find(node.Left, needle);
                }
                else if (needle > node.Pay)
                {
                    // ищем в правом поддереве
                    if (node.Right == null)
                    {
                        return null;
                    }
                    return Find(node.Right, needle);
                }
                else
                {
                    return node;
                }
            }
            static void AddNode(Node node, Node toAdd)
            {
                if (toAdd.Pay < node.Pay)
                {
                    // добавляем в левое поддерево
                    if (node.Left == null)
                    {
                        node.Left = toAdd;
                    }
                    else
                    {
                        AddNode(node.Left, toAdd);
                    }
                }
                else
                {
                    // добавляем в правое поддерево
                    if (node.Right == null)
                    {
                        node.Right = toAdd;
                    }
                    else
                    {
                        AddNode(node.Right, toAdd);
                    }
                }
            }
            static void Traverse(Node node)
            {
                if (node.Left != null)
                {
                    Traverse(node.Left);
                }

                Console.WriteLine($"{node.Name}, {node.Pay}");

                if (node.Right != null)
                {
                    Traverse(node.Right);
                }
            }
        }
        class Node
        {
            public int Pay { get; set; }
            public string? Name { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }  
        }
    }
}
