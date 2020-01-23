[![Build Status](https://dev.azure.com/jberger8/CSCD379-2020-Winter/_apis/build/status/jacob-berger.EWU-CSCD379-2020-Winter?branchName=master)](https://dev.azure.com/jberger8/CSCD379-2020-Winter/_build/latest?definitionId=2&branchName=master)
# Assignment

The purpose of this assignment is to learn the following:

- Leveraging code analysis
- Activating nullability
- Implementing continuous integration
- Basic unit testing
- Git basics including rebase

## Instructions

1. Turn on nullability in the **SecretSanta.API** project.
2. Configure nullability in **SecretSanta.API** project to be conditional based Nullability not already being set (pending Thursday lecture).
3. Add the following classes to the **SecretSanta.Business** project with the following the associated properties:
   - **`Gift`**
     - `int Id`e
 as read-only
     - `string Title`
     - `string Description`
     - `string Url`
     - `User User`

   - **`User`**
     - `int Id` as read-only
     - `string FirstName`
     - `string LastName`
     - <*a collection of*> `Gifts`

4. Add non-default constructors for `Gift` and `User`.
5. Add unit tests to all projects except **SecretSanta.Web** and fully unit test the new classes in **SecretSanta.Business**(pending Thursday lecture).
6. Refactor nullability setting into solution level **props** and *targets** files (pending Thursday lecture).
7. Add the following list of code analysis assemblies and appropriately handle all warnings: `IntelliTectAnalyzer.dll`,`Microsoft.NetCore.Analyzers.dll`,`Microsoft.CodeQuality.Analyzers.dll`,`Microsoft.NetCore.Analyzers.dll`,`Microsoft.NetFramework.Analyzers.dll`.  Refactor out a solution level global suppression file for disabling code analysis warnings across all projects.
8. Configure Azure DevOps build for continuous integration to compile and run all unit tests# CSCD-379-2020-Winter
9. If any updates occur in **Assignment1** prior to your PR, rebase onto **Assignment1**.  Finally, and just prior to submitting your PR, rebase from master (which has additional commits added after **Assessment1** was created such as the addition of the cSpell.json in commit #7b106a6).

## Extra Credit

The following are options for extra credit (you don't need to do them all):

- Use reflection to test all properties on all classes in **SecretSanta.Business**.
- Configure tests to run in parallel both locally and in Azure DevOps.
