using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlus
{
    internal class School
    {
        List<User> userList;

        public School ()
        {
            userList = new List<User>();
            ReadDatabase();
        }

        User Login()
        {
            Console.Write("Kullanıcı adı:");
            string uname = Console.ReadLine();
            Console.Write("Şifre:");
            string pass = Console.ReadLine();

            foreach(User user in userList) {
                if (user.username==uname) {
                    if (user.password==pass) {
                        Console.WriteLine("Hoşgeldin " + user);
                        return user;
                    } else {
                        Console.WriteLine("Şifreniz yanlış");
                        return null;
                    }
                } 
            }
            Console.WriteLine("Bu isimde bir kullanıcı yok.");
            return null;
        }

        void ReadDatabase ()
        {
            string[] lines = File.ReadAllLines("users.txt");

            foreach (string line in lines) {
                string[] cols = line.Split("#");

                User user;
                string name = cols[3];
                string username = cols[1];
                string pass = cols[2];
                string email = cols[4];

                if (cols[0] == "Admin") {
                    user = new Admin(name, username, pass,email);
                } else if (cols[0] == "Teacher") {
                    user = new Teacher(name, username, pass, email);
                } else if (cols[0] == "Student") {
                    user = new Student(name, username, pass, email);
                } else if (cols[0] == "Parent") {
                    user = new Parent(name, username, pass, email);
                } else {
                    user = null;
                }

                if (user != null) {
                   
                    userList.Add(user);
                }
            }
        }



        public void MainMenu ()
        {
            Console.Clear();
            Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1. Kullanıcı listesini gör");
            Console.WriteLine("2. Yeni kullanıcı ekle");
            Console.WriteLine("3. Dersleri göster");
            string choice = Console.ReadLine();

            if (choice == "1") {
                ShowUserList();
            } else if (choice == "2") {
                AddNewUser();
            } else if (choice == "3") {
                ShowCourseList();
            }

        }

        private void AddNewUser ()
        {
            Console.Clear();
            Console.WriteLine("Yeni kullanıcı ekleme");
            Console.WriteLine("---------------------");
            Console.Write("Eklenecek kullanıcının tipini seçin: Öğrenci(S), Öğretmen(T), Veli(P):");
            string typ = Console.ReadLine();
            if (typ== "S") {
                typ = UserTypes.Student;

            }
            if (typ == "T") {
                typ = UserTypes.Teacher;
            }
            if (typ == "P") {
                typ = UserTypes.Parent;
            }
            
        }
        private void ShowCourseList ()
        {
            Console.Clear();
            Console.WriteLine("Kursları görme");
            Console.WriteLine("---------------------");

            foreach (User user in userList) {
                Console.WriteLine(user + "---" + user);
            }
        }

        private void ShowUserList ()
        {
            Console.Clear();
            Console.WriteLine("Kullanıcı Listesi");
            Console.WriteLine("-----------------");

            foreach (User user in userList) {
                Console.WriteLine(user + "(" + user.username + ") - " + user.userType);
            }
            Console.WriteLine("\nDevam etmek için ENTER");
            Console.ReadLine();
        }

        public void Run ()
        {
            
            Console.WriteLine("Okul Yönetim Programı");
            Console.WriteLine("---------------------");


            User loggedInUser = null;
            while (loggedInUser==null) {
                loggedInUser = Login();
            }
            while (true) {
                MainMenu();
            }
        }
    }
}
