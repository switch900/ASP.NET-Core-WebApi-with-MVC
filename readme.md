The assignment involves development of a web app that provides information about Harry Potter books. You will use the Google APIs JSON endpoints at https://www.googleapis.com/books/v1/ for data.
The purpose of this assignment is for you to familiarize yourself with ASP.NET Core, Identity Framework and reading JSON objects.

The assignment consists of two views. On the first view, titles of books written about the good wizard Harry Potter are listed. These need to be read dynamically from the JSON end point at https://www.googleapis.com/books/v1/volumes?q=harry+potter. The title data comes from the item >> title field.
When the user clicks on a book, the second view displays details about that book, namely:
  o title
  o smallThumbnail [ this is an image that needs to be displayed ]
  o authors
  o publisher
  o publishedDate
  o description
  o ISBN_10

The names of students in the team should display on the home page.
Only authenticated users can access the book and book details views.
To help the marker test your application, seed the appropriate identity framework database tables with the following user Email Password a@a.a P@$$w0rd
Users do not see menu items that they do not have access to unless they are authenticated
Deploy your application to Azure SUBMISSION

<img src="https://github.com/switch900/Comp3973_Assign_01/blob/master/BookApi.PNG" alt="Smiley face" width="200">
