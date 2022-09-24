using Xunit;
namespace GradeBook.Tests;

public class TypeTests
{
    [Fact]
    public void TestName()
    {
        // Given
        var x = GetInt();
        SetInt(ref x);
        // When

        // Then
        Assert.Equal(42, x);
    }

    private void SetInt(ref object x)
    {
        x = 42;
    }

    private object GetInt()
    {
        return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        // Given
        var book1 = Getbook("Book 1");
        GetBookSetName(out book1, "New Name");
        // When

        // Then
        Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(out Book book, string name)
    {
        book = new Book(name);
    }
    [Fact]
    public void Test1()
    {
        // Given
        var book1 = Getbook("Book 1");
        GetBookSetName(book1, "New Name");
        // When

        // Then
        Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
        book.Name = name;
    }
    [Fact]
    public void CanSetNameFromReference()
    {
        // Given
        var book1 = Getbook("Book 1");
        SetName(book1, "New Name");
        // When

        // Then
        Assert.Equal("New Name", book1.Name);
    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = Getbook("Book 1");
        var book2 = Getbook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);

    }
    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = Getbook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(object.ReferenceEquals(book1, book2));

    }

    private Book Getbook(string name)
    {
        return new Book(name);
    }
}
