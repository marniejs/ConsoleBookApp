using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBookApp
{
    public class CRUDFunctions
    {
        public static void Connect()
        {
            string constring;
            SqlConnection connection;
            constring = @"data source=LAPTOP-NU7K0JI4\SQLEXPRESS;initial catalog=Books;integrated security=true";
            connection = new SqlConnection(constring);
            connection.Open();
            Console.WriteLine("Connection Open!");
            connection.Close();
        }

        public static void Read()
        {
            string constring;
            SqlConnection connection;
            constring = @"data source=LAPTOP-NU7K0JI4\SQLEXPRESS;initial catalog=Books;integrated security=true";
            connection = new SqlConnection(constring);
            connection.Open();
            SqlCommand cmd;
            SqlDataReader dreader;
            string sql, output = "";
            sql = "Select ID, BookTitle, BookAuthor, Genre, PublicationYear from BookTable";
            cmd = new SqlCommand(sql, connection);
            dreader = cmd.ExecuteReader();

            var table = new ConsoleTable("ID", "Title", "Author", "Genre", "Publication Year");
            while (dreader.Read())
            {
                table.AddRow(dreader.GetValue(0), dreader.GetValue(1), dreader.GetValue(2), dreader.GetValue(3), dreader.GetValue(4));  
            }

            table.Write();
            Console.WriteLine();

            dreader.Close();
            cmd.Dispose();
            connection.Close();
        }

        public static void Insert()
        {
            Console.WriteLine("What is the book's title?");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("What is the book's author?");
            string bookAuthor = Console.ReadLine();
            Console.WriteLine("What is the genre?");
            string genre = Console.ReadLine();
            Console.WriteLine("What year was the book published?");
            string pubYear = Console.ReadLine();

            string constring;
            SqlConnection connection;
            constring = @"data source=LAPTOP-NU7K0JI4\SQLEXPRESS;initial catalog=Books;integrated security=true";
            connection = new SqlConnection(constring);
            connection.Open();
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = $"insert into BookTable (BookTitle, BookAuthor, Genre, PublicationYear) values('{bookTitle}', '{bookAuthor}', '{genre}', {pubYear})";
            cmd = new SqlCommand(sql, connection);
            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();

            Console.WriteLine($"{bookTitle} has been added!");
            cmd.Dispose();
            connection.Close();
        }

        public static void Update()
        {
            Console.WriteLine("What is the title of the book you'd like to update?");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("What would you like to update? \n 1 - Title \n 2 - Author \n 3 - Genre \n 4 - Publication Year");
            string userChoice = Console.ReadLine();

            string constring;
            SqlConnection connection;
            constring = @"data source=LAPTOP-NU7K0JI4\SQLEXPRESS;initial catalog=Books;integrated security=true";
            connection = new SqlConnection(constring);
            connection.Open();
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            if (userChoice == "1")
            {
                Console.WriteLine("Please enter the new title.");
                string newBookTitle = Console.ReadLine();
                sql = $"update BookTable set BookTitle='{newBookTitle}' where BookTitle='{bookTitle}'";
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("Please enter the new author");
                string newBookAuthor = Console.ReadLine();
                sql = $"update BookTable set BookAuthor='{newBookAuthor}' where BookTitle='{bookTitle}'";
            }
            else if (userChoice == "3")
            {
                Console.WriteLine("Please enter a new genre");
                string newGenre = Console.ReadLine();
                sql = $"update BookTable set Genre='{newGenre}' where BookTitle='{bookTitle}'";
            }
            else if (userChoice == "4")
            {
                Console.WriteLine("Please enter the new publication year");
                string newPubYear = Console.ReadLine();
                sql = $"update BookTable set PublicationYear='{newPubYear}' where BookTitle='{bookTitle}'";
            }
            else
            {
                Console.WriteLine("Invalid Entry!");
            }

            cmd = new SqlCommand(sql, connection);
            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();

            Console.WriteLine($"{bookTitle} has been updated!");
            cmd.Dispose();
            connection.Close();
        }

        public static void Delete()
        {
            Console.WriteLine("What is the title of the book you'd like to delete?");
            string bookTitle = Console.ReadLine();

            string constring;
            SqlConnection connection;
            constring = @"data source=LAPTOP-NU7K0JI4\SQLEXPRESS;initial catalog=Books;integrated security=true";
            connection = new SqlConnection(constring);
            connection.Open();
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = $"delete from BookTable where BookTitle='{bookTitle}'";
            cmd = new SqlCommand(sql, connection);
            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();

            Console.WriteLine($"{bookTitle} has been deleted!");
            cmd.Dispose();
            connection.Close();
        }
    }
}
