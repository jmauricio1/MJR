# I Need My Space Project Guidelines
Please follow the guidelines listed below when contributing code to this project. Please keep in mind that this project was started as a university class and some decisions have been made with students and teaching in mind.

### Overall Guidelines
- Code will be written in C# following the ASP.NET / MVC5 style. 
  - Follow standard C# convetions which can be found [here](https://www.dofactory.com/reference/csharp-coding-standards).
- Use RESTful style when creating new controllers (IE. A new controller for differentiable entities)

### Code
- For consistencies sake, we ask that you please use place the curly bracket (brace) on a new line. 
```
public class NewClass
{
    if(something)
    {
        print(Hello World!)
    }
    else
    {
        print(Goodbye World!)
    }
}
```
- Please use clear and understandable / logical class names, method names and variable names. 
- Frequent comments would be appreciated using either the */ text /* multine comment or //text single line comment.
- A method should minimally be accompanied by a comment explaining what that method does. 

### Git
- Use branching methods as notated [here](https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging). 
- Commit often to create a steady flow of restore points in case something goes wrong. 
- Verify that all code compiles before you commit the code.
- Don't commit any auto-generated files. Use an appropriate visual studio .gitignore ([.gitignore example](https://github.com/github/gitignore/blob/master/VisualStudio.gitignore)).
- Resolve your own merge conflicts.

### Javascript
- Use external .js script files. We will not be writing any javascript within the views and we would ask that you don't either. 

### Styles
- Use external CSS style sheets for the vast majority of formatting. 
- Exceptions will be made for in-line CSS where we find acceptable (IE. Formatting a picture's width & height)

### Databases
- If you create new tables please follow the naming convention for the ID of the table using TableNameID.
- Please pluralize table names (Ie. 'Athlete' table should be 'Athletes').
- Foreign keys will be EntityID.

### Pull Requests
1. Be sure you are pulling from upstream dev when you start working for the most up to date developement files. 
2. Create your feature branches off of the dev branch.
3. When you are ready to merge, checkout your dev branch and pull from upstream to make certain you have the current files. Now checkout your feature branch and merge your dev branch into it. Test at this point to assure that your merge was successful and that all features are working correctly still.
4. Push your feature branch to your remote repository (push origin featureBranch)
5. From your forked repository create a pull request, from your remote featureBranch to the upstreams dev branch, fill out information as necessary. [Instructions Here](https://help.github.com/en/desktop/contributing-to-projects/creating-a-pull-request)


