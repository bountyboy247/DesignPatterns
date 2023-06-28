using DesignPatterns.DSAs.BFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OOP {
    internal class KindleDesignSimple {

        public KindleDesignSimple() {
            List<string> pages = new List<string>();
            for(int i = 0; i < 9; i++) {
                pages.Add("");
            }

            pages[0] = "content page";
            pages[1] = "chapter 1 story";
            pages[2] = "chapter 1 story details";
            pages[3] = "chapter 2 story";
            pages[4] = "chapter 2 story details";
            pages[5] = "chapter 3 story";
            pages[6] = "chapter 3 story details";
            pages[7] = "chapter 4 story";
            pages[8] = "chapter 4 story details";
            //Book historyBook = new Book("American History", pages);
            //Book geoBook = new Book("American Geography", pages);
            string strf = "abcdefghijklmno";
            var ls1 = new List<string>();
            ls1.Add("Samy");
            ls1.Add("sfs");
            string ansss = ls1[0];
            for(int i = 0; i < strf.Length; i++) {
                ls1.Add(strf.Remove(i, 1));
            }
            MinTime mt = new MinTime();
            Library samysLibrary = new Library();
            var book1 = samysLibrary.AddBook("American History", pages);
            var book2 = samysLibrary.AddBook("American Geography", pages);
            samysLibrary.SetBookActive(book1.Id);
            string page = samysLibrary.GotoNextPage(book1.Id);
            string anotherPage = samysLibrary.GotoNextPage(book1.Id);
            int currentPage = samysLibrary.GetCurrentPage(book1.Id);
            samysLibrary.SetBookActive(book2.Id);
        }
    }


public class Library {
    public Dictionary<int, Book> books;
    public Book ActiveBook;
    public int idCounter = 0;
    public Library() {
        books = new Dictionary<int, Book>();
    }
    public List<Book> GetAllBooks() =>
        books.Values.ToList();

    public Book AddBook(string title, List<string> pages) {
        idCounter++;
        books[idCounter] = new Book(idCounter, title, pages);


        return books[idCounter];
    }
    public void RemoveBook(int id) {
        var book = books[id];
        book = null;
        books.Remove(id);
        idCounter--;

    }
    public void SetBookActive(int Id) {
        ActiveBook = books[Id];
    }

    public string GotoNextPage(int id) =>
        ActiveBook.GoToNextPage();
    public int GetCurrentPage(int id) =>
        ActiveBook.LastPage;
}
public class Book {
    public int Id;
    public string title;
    public List<string> Pages;
    public int LastPage;
    public Book(int Id, string title, List<string> pages) {
        this.Id = Id;
        this.title = title;
        Pages = pages;
        LastPage = 0;
    }

    public string GoToNextPage() {
        if(LastPage < Pages.Count)
            LastPage++;
        return Pages[LastPage];
    }
    public string GoToPrevPage() {
        if(LastPage > 0)
            LastPage--;
        return Pages[LastPage];
    }
    public string DisplayPageNo(int page) {
        if(page > 0 && page < Pages.Count) {
            LastPage = page;
        }
        return Pages[LastPage];
    }
}


}
