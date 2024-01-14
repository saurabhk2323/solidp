using ConsoleApp.SQLite.EF.Data;
using ConsoleApp.SQLite.EF.Model;

try
{
    using var db = new BloggingContext();

    // Note: this sample requires  the database  to be created before running
    Console.WriteLine($"databse path: {db.DbPath}");

    // create
    Console.WriteLine("inserting a new blog...");
    await db.AddAsync(new Blog { Url = "https://blogs.msdn.in" });
    await db.SaveChangesAsync();

    // read
    Console.WriteLine("querying for a blog....");
    var blog = db.Blogs.OrderBy(b => b.BlogId).First();
    Console.WriteLine($"Blog Id: {blog.BlogId} ; url: {blog.Url}");

    // update
    Console.WriteLine("Updating the blog, adding a new post");
    blog.Posts = new List<Post>()
    {
        new Post { Title = "SQLite Tutorial", Content = "This is a tutorial course explaining about the integration of SQLite in Asp .Net Core" }
    };
    await db.SaveChangesAsync();

    var updatedBlog = db.Blogs.OrderBy(b => b.BlogId).First();
    var post = updatedBlog.Posts.First();
    Console.WriteLine($"BlogId: {updatedBlog.BlogId}; Post -> Title: {post.Title}; Content: {post.Content}");

    // delete
    Console.WriteLine("delete the blog");
    db.Remove(updatedBlog);
    await db.SaveChangesAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Exception {ex}");
}