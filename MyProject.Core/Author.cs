namespace MyProject.Core
{
    public class Author
    {
        public int Id { get; set; } ///получение и вписывание
         public string FullName { get; set; } /// полное имя автора
        public List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>(); /// ссылка на таблицу автора...

    }
}
