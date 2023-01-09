namespace UAS_146
{
    class Node
    {
        public int rollnumber;
        public string name;
        public string kelas;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addnote()
        {
            int rollNo;
            string nm;
            string kelas;
            Console.Write("\nMasukkan Nomor Induk Murid: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Murid: ");
            nm = Console.ReadLine();
            Console.Write("\n Masukkan Kelas Murid: ");
            kelas = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollnumber = rollNo;
            newnode.name = nm;
            newnode.kelas = kelas;
            // if the node to be inserted  is the first node
            if ((START == null) || rollNo <= START.rollnumber)
            {
                if ((START != null) && (rollNo == START.rollnumber))
                {
                    Console.WriteLine("\nNomor induk telah ada !!!\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (rollNo >= current.rollnumber))
            {
                if (rollNo == current.rollnumber)
                {
                    Console.WriteLine("\nNomor induk telah ada !!!\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool delnode(string noKel)
        {
            Node previous, current;
            previous = current = null;
            if (Search(noKel, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(string noKel, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (noKel != current.kelas))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else return true;
        }
        public void Traverse()
        {
            if(listEmpty())
            {
                Console.WriteLine("\n Nomor induk || Nama || Kelas || ");
            }
            else
            {
                Console.WriteLine("\n Nomor induk || Nama || Kelas || ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollnumber + "               " + currentNode.name + "        " + currentNode.kelas + "\n");
                Console.WriteLine("");
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambahkan Data murid");
                    Console.WriteLine("2. Menghapus data murid");
                    Console.WriteLine("3. Tampilkan semua data");
                    Console.WriteLine("4. Mencari data murid");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n Data kosong");
                                    break;
                                }
                                Console.WriteLine("Masukkan nomor induk" + "data murid telah dihapus: ");
                                string noKel = Console.ReadLine();
                                if (obj.delnode(noKel) == false)
                                    Console.WriteLine("\n Data tidak ditemukan.");
                                else
                                    Console.WriteLine("Record with roll number" + noKel + "deleted");
                            }
                            break;
                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData tidak ada!!!");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Kelas " + "Data dikelas : ");
                                string kel = Console.ReadLine();
                                if (obj.Search(kel, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine("\nKelas: " + current.kelas);
                                    Console.WriteLine("\nName: " + current.name);
                                    Console.WriteLine("\nNomor Induk Murid: " + current.rollnumber);

                         
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\n Invalid option");
                                break;
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered");
                }
            }
        }
    }
}

// 2.SinglyLinkedList 
// 3.TOP pada STACK adalah tempat untuk masuk dan keluar di STACK 
// 4.REAR,FRONT
/* 5. a.5
 *    b.inorder traversal (15,20,25,30,31,32,35,48,50.65,66,67,69,70,94,98,99,90) */