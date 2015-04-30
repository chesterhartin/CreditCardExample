# CreditCardExample

Usage
==============

The primary entry point for this application is in the located in the CreditCard.Console project. You should be able to open the main CreditCard project and compile it with the release setting. Once compiled, you should be able to find the CreditCard.exe file.

To run the application, type:

   CreditCard.exe PathToFile

Where PathToFile is the directory and file name. For example, if you would like to process the file input.txt on your C:\ root drive you would type:

  CreditCard C:\\input.txt 
  ^^
  Note -- see the double slashes? 

So that's the basic usage.

Layers
===================

Controllers: the account controller is basic controller and controlls the flow. 

BI: The BI is where the core business logic happens. Is the transaction good?

DAL: is super basic, but could be extended to use a non-memory datastore. The current implementation has a unique constraint on name.

Entities: While "Transaction" is more of an action than an entity, having it in this collection for this exercise made sense. I didn't want to get too fancy with .Net validation attributes, so I kept to most OOP standards

Extensions: I like the ability to check the validity of a credit card inline vs having to call a method on it directly

Interfaces: They make everything easier! Checkout IOutput, made testing the controller so much easier. Also, we now have flexible output options

Utilities: Stripping the $ off was something that I had originally had as a regex, but thought that was a bit too much, so I put this functionality one place so I could test and use.

Validation: While there was no minimum length for a card, I thought it'd be safe to impose a min. Here you'll also find the Luhn10 algorithm. 

Views: Handy to print to the screen, or a file, or to get the result set from the dal (usually I would have a get-all method in the dal, but I decided to spice it up and show some flexability).


TDD
===========
Tests: While 31 tests isn't what I'd call full coverage, hopefully it shows basic test-driven-development. I typically use mocking as well in the real-world, but felt it was a tad overkill here. I also tend to split up my tests into individual units, instead of the tests seen here in StringExtensions_Test_IsValidCard. For testing I'm using NUnit.


The future
===========
It'd be nice to integrate Unity injection / Mocking / Logging into this, but that's probably overkill for now.