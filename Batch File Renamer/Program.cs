namespace Batch_File_Renamer;
class Program
{
    static void Main(string[] args)
    {
        string folder = "C:\\";

        Console.WriteLine("Please enter a path to the folder: ");

        try
        {
            folder = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        DirectoryInfo directory = new DirectoryInfo(@folder);


        bool continueLooping = true;
        while (continueLooping)
        {
            FileInfo[] listFiles = directory.GetFiles();
            Console.WriteLine("============================================================");
            Console.WriteLine("What operation do you want to make:");
            Console.WriteLine("1. List files in the specified folder");
            Console.WriteLine("2. Add a prefix to each file in the specified folder");
            Console.WriteLine("3. Add a suffix to each file in the specified folder");
            Console.WriteLine("4. Exit program");
            Console.Write("Enter the number of the operation: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    ListDirectory(listFiles);
                    break;

                case "2":
                    AddPrefix(listFiles);
                    break;

                case "3":
                    AddSuffix(listFiles);
                    break;

                case "4":
                    continueLooping = false;
                    break;
            }
        }



        //list all the files in the folder
        static void ListDirectory(FileInfo[] files)
        {
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{file}");
            }
        }

        //add a prefix
        static void AddPrefix(FileInfo[] files)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("What prefix do you want to add at the beginning of the file?");
            string prefix = Console.ReadLine();

            foreach (FileInfo file in files)
            {
                string newFileName = Path.Combine(Path.GetDirectoryName(file.FullName), prefix + Path.GetFileName(file.Name));
                File.Move(file.FullName, newFileName);
            }
            Console.WriteLine("============================================================");
            Console.WriteLine($"The prefix {prefix} was added to each of the file");
        }

        //add suffix
        static void AddSuffix(FileInfo[] files)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("What suffix do you want to add at the beginning of the file?");
            string suffix = Console.ReadLine();

            foreach (FileInfo file in files)
            {
                string newFileName = Path.Combine(Path.GetDirectoryName(file.FullName), Path.GetFileNameWithoutExtension(file.Name) + suffix + Path.GetExtension(file.Name));
                File.Move(file.FullName, newFileName);
            }
            Console.WriteLine("============================================================");
            Console.WriteLine($"The prefix {suffix} was added to each of the file");
        }

    }
}

