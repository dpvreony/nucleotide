# Nucleotide

![Build status](https://ci.appveyor.com/api/projects/status/jk9v57hxjj0mi6t4?svg=true)

## Mission Statement

To provide a tool that automatically generates repeditive .NET code to allow better use of developers time.

## Introduction

Nucleotide is a library to aid in the generation of .NET code for manipulation the following types of objects:

* Client\Server Services (Interfaces)
* Commands (Interfaces and Classes)
* Command Factory (Interfaces and Classes)
* Entity Framework DbSet (Classes)
* Entity Framework Models (Classes)
* Models (Interfaces and Classes)
* Queries (Interfaces and Classes)
* Query Factories (Interfaces and Classes)
* Request DTO POCO Objects (Classes)
* Response DTO POCO Objects (Classes)
* SignalR Hubs (Classes)
* WCF Service classes (Classes)
* Web Api Client (Classes)
* Web Api Controllers (Classes)

This project leverages Roslyn functionality to combine a simple DSL style model with the power of the compiler to give a simple way to generate code.

This version of Nucleotide is built upon CodeGenerators.Roslyn, this has allowed the removal of depedency on -.tt files.

## Getting Started

### Pre-requisites

**Currently the MSBuild generation is broken, this is an issue between the Visual Studio 2017 and the Roslyn library this version of Nucleotide is built on. You will need to use dotnet build from the command line for the time being.**

You will need:
* Visual Studio 2017
* A project using netstandard 1.4 upward

### Before you start

You can use the following project structure

1. Your code generation model and the generated code are in the same project.
2. Your code generation model is in Project1, while your generated code is in Project2.

### Get the package (Single Project)

You want to install Nucleotide in the project where you want to place your generated model.

` Install-Package Dhgms.Nucleotide `

### Get the package (Dual Project)

**In project1.**

` Install-Package Dhgms.Nucleotide `

**In project2.**

1. Reference Project1.

1. ` Install-Package CodeGenerators.Roslyn.BuildTime `


### Get started with a Code Generation Model

TODO.

### Apply a Model Generation Attribute

TODO.

## Viewing the documentation

The documentation can be found at http://dpvreony.github.io/nucleotide/

## Contributing to the code

### 1\. Fork the code

See the [github help page for instructions on how to create a fork](http://help.github.com/fork-a-repo/).

### 2\. Apply desired changes

Use your preffered method for carrying out work.

### 3\. Send a pull request

See the [github help page for instructions on how to send pull requests](http://help.github.com/send-pull-requests/)

