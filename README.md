BlogPostsByAuthor
=================

Class library to read meta data about blog posts from a Ghost blog

To use add from nuget: Install-Package Novanet.Ghost.BlogPostsByAuthor

Get all posts for an author like this (pass in the authorSlug to identify the author):
<pre><code>
var posts = (await new AuthorPostService(CreateLoginSettings(),
                new TokenCache(new Authenticator()),
                new AuthorPostsFetcher()).GetPosts(authorSlug)).ToList();
</code></pre>

To find the author-slug check your users on the Ghost blog you are reading from.

To run the sample Web app you need to update the Web.config file before you run it.
The following 3 settings must be defined:
<pre><code>
    &lt;add key="BlogUrl" value="BlogUrl" /&gt;
    &lt;add key="UserName" value="UserName" /&gt;
    &lt;add key="Password" value="Password" /&gt;
</code></pre>
Username and password must be the user name and password of an existing user on your Ghost blog.
