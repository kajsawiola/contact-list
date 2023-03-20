namespace dtp6_contacts
{
    class MainClass
    {
        static Person[] contactList = new Person[100];
        class Person
        {
            public string persname, surname, phone, address, birthdate;
        }
        public static void Main(string[] args)
        {
            string lastFileName = "address.lis";
            string[] commandLine;
            välkommstInfo();
            do
            {
                Console.Write($"> ");
                commandLine = Console.ReadLine().Split(' ');
                if (commandLine[0] == "quit") //Avslutar programmet
                {
                    quit();
                }
                else if (commandLine[0] == "load") //laddar texten i filen "adress.txt" i rader i en array.
                {
                    if (commandLine.Length < 2)
                    {
                        lastFileName = "address.txt";
                        loadFile(lastFileName);
                    }
                    else //laddar texten i angiven fil in i rader i en array
                    {
                        lastFileName = commandLine[1];
                        loadFile(lastFileName);
                    }
                }
                else if (commandLine[0] == "save")  //sparar ett angivet objekt i "contactlist []"
                {
                    if (commandLine.Length < 2)
                    {
                        save(lastFileName);
                    }
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: save /file/");
                    }
                }
                else if (commandLine[0] == "new") //lägger till en ny person till atributen namn, efternamn och telefon
                {
                    if (commandLine.Length < 2)
                        nyPerson();
                    else
                    {
                        // NYI!
                        Console.WriteLine("Not yet implemented: new /person/");
                    }
                }
                else if (commandLine[0] == "help") //visar alla funktioner i programmet
                {
                    listaFunktioner();
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{commandLine[0]}'");
                }
            } while (commandLine[0] != "quit"); //avslutar programmet
        }

        private static void listaFunktioner()
        {
            Console.WriteLine("Avaliable commands: ");
            Console.WriteLine("  delete       - emtpy the contact list");
            Console.WriteLine("  delete /persname/ /surname/ - delete a person");
            Console.WriteLine("  load        - load contact list data from the file address.lis");
            Console.WriteLine("  load /file/ - load contact list data from the file");
            Console.WriteLine("  new        - create new person");
            Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
            Console.WriteLine("  quit        - quit the program");
            Console.WriteLine("  save         - save contact list data to the file previously loaded");
            Console.WriteLine("  save /file/ - save contact list data to the file");
            Console.WriteLine();
        }

        private static void nyPerson()
        {
            Console.Write("personal name: ");
            string persname = Console.ReadLine();
            Console.Write("surname: ");
            string surname = Console.ReadLine();
            Console.Write("phone: ");
            string phone = Console.ReadLine();
        }

        private static void save(string lastFileName)
        {
            using (StreamWriter outfile = new StreamWriter(lastFileName))
            {
                foreach (Person p in contactList)
                {
                    if (p != null)
                        outfile.WriteLine($"{p.persname};{p.surname};{p.phone};{p.address};{p.birthdate}");
                }
            }
        }

        private static void quit()
        {
            // NYI!
            Console.WriteLine("Not yet implemented: safe quit");
        }

        private static void välkommstInfo()
        {
            Console.WriteLine("Hello and welcome to the contact list");
            listaFunktioner();
        }

        private static void loadFile(string lastFileName)
        {
            using (StreamReader textfilen = new StreamReader(lastFileName))
            {
                string line;
                while ((line = textfilen.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] attribut = line.Split('|');
                    Person p = new Person();
                    p.persname = attribut[0];
                    p.surname = attribut[1];
                    string[] phones = attribut[2].Split(';');
                    p.phone = phones[0];
                    string[] addresses = attribut[3].Split(';');
                    p.address = addresses[0];
                    for (int ix = 0; ix < contactList.Length; ix++)
                    {
                        if (contactList[ix] == null)
                        {
                            contactList[ix] = p;
                            break;
                        }
                    }
                }
            }
        }
    }
}
