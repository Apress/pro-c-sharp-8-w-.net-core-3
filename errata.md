# Errata for *Pro C# 8 with .NET Core 3

**Chapter 1**

[On **page 10** in the first paragraph of "Additional .NET Core Aware Programming Languages it says that "ASP.NET Core applications are limited to C#. This is not true as Razor pages are limited to C#, but the code-behind and the class can be written in any .NET Core compatible language.]

Instead of this:

Understand that C# is not the only language that can be used to build .NET Core applications. .NET Core
applications can generally be built with C#, Visual Basic, and F#. ASP.NET Core applications are limited to C#.

It should appear as this:

Understand that C# is not the only language that can be used to build .NET Core applications. .NET Core
applications can generally be built with C#, Visual Basic, and F#. 

(Thank you to Patrick Lanz for reporting this errata)

**Chapter 2**

[On **page 31** the "note" has an error.]

It should read like this:

Note Creating solutions and projects can also be accomplished using the .NET Core CLI. For example, to create a new solution, enter dotnet new sln -n SimpleCSharpConsoleApp. To create a new .NET Core C# Console application, enter dotnet new console -lang C# -n SimpleCSharpConsoleApp. To add the new console app to the solution, enter dotnet sln add SimpleCSharpConsoleApp. This is just a small sample of what the CLI is capable of. To discover everything the CLI can do, enter dotnet -h

**Chapter 3** 

[On **page 52** in the section that begins with “The following output shows…”, the following sentence should be removed:] 

"Of course, if you did not specify command-line arguments via the Visual Studio Debug tab, you will not find them printed to the console."

(Thank you to Mehmet Kaya for reporting)


**Chapter 22**

[On **page 836** in the last paragraph that begins with "Delete the Data and Reseed..." there is a typo.] 

Instead of:

"Open the StoreDataInitializer.cs class"

It should read: 

"Open the SampleDataInitializer.cs class"

[On **page 836** there is a typo in the last paragraph.] 

Instead of: 

“DBCC ChecIdent"

It should read:

"DBCC CheckIdent"

(Thank you to Herbert Feichtinger for reporting this typo)


**Chapter 23**

[On **page 865** the code following the paragraph that begins with "Another constructor takes an instance..." should read like this:]

private readonly bool _disposeContext;
protected BaseRepo(DbContextOptions<ApplicationDbContext> options)
 : this(new ApplicationDbContext(options)) {
  _disposeContext = true;
}
 
 [On **page 852** there is a missing assert at the end of the page "ShouldSortByFirstNameThenLastName()"]

The code in the Sort Records example should be this:

[Fact]
public void ShouldSortByFirstNameThenLastName()
{
  var customers = Context.Customers
    .OrderBy(x => x.PersonalInformation.LastName)
    .ThenBy(x => x.PersonalInformation.FirstName).ToList();
  if (customers.Count <= 1)
  {
    return;
  }
  for (int x = 0; x < customers.Count-1; x++)
  {
    var compareLastName = string.Compare(customers[x].PersonalInformation.LastName,
      customers[x + 1].PersonalInformation.LastName, StringComparison.CurrentCultureIgnoreCase);
    Assert.True(compareLastName <= 0);
    if (compareLastName == 0)
    {
      var compareFirstName = string.Compare(customers[x].PersonalInformation.FirstName,
        customers[x + 1].PersonalInformation.FirstName, StringComparison.CurrentCultureIgnoreCase);
      Assert.True(compareLastName <= 0);
    }
  }
}



 
 [On **page 869** there is a typo in the paragraph in the listing that appears under Entity-Specific Repo Interfaces.]

IMakeIRepo.cs   

should read:

IMakeRepo.cs

(Thank you to Herbert Feichtingerfor reporting this typo)


**Chapter 25**

[On **page 943** the “Note” indicates that a much deeper look at commands is in chapter 30. It should be chapter 28.] 

It should read:

Note  Chapter 28 will take a much deeper look into the WPF command system. In it, you will create custom commands base on ICommand as well as RelayCommands.
