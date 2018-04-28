---
title: Home
layout: default
---
# Nucleotide

![Build status](https://ci.appveyor.com/api/projects/status/jk9v57hxjj0mi6t4?svg=true)

## Mission Statement

To provide a tool that automatically generates repeditive .NET code to allow better use of developers time.

## Introduction

Nucleotide is a library to aid in the generation of .NET code for manipulation the following types of objects:

### Client \ Server
* Client\Server Services (Interfaces)
* Models (Interfaces and Classes)
* Request DTO POCO Objects (Classes)
* Response DTO POCO Objects (Classes)

### Server
* Commands (Interfaces and Classes)
* Command Factory (Interfaces and Classes)
* Entity Framework DbContext (Classes)
* Entity Framework Models (Classes)
* Queries (Interfaces and Classes)
* Query Factories (Interfaces and Classes)
* SignalR Hubs (Classes)
* Web Api Controllers (Classes)

### Client
* ReactiveUI ViewModels (Interfaces and Classes)
* Web Api Client (Classes)

This project leverages Roslyn functionality to combine a simple DSL style model with the power of the roslyn to

* Give a simple way to generate code.
* Give visibility in Visual Studio of the classes generated via Solution Explorer.
* Reduce time spent producing boiler plate code.
* Utilise patterns of development to produce consistent design

This version of Nucleotide is built upon CodeGenerators.Roslyn, this has allowed the removal of dependency on -.tt files.

## Credits

* https://github.com/AArnott/CodeGeneration.Roslyn

## Getting Started

### Pre-requisites

You will need:
* Visual Studio 2017
* A project using netstandard 1.4 upward

### Before you start

You can use one of the following project structures

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

** There will be a change in future to have bundle nuget packages that will install nucleotide and the relevant packages that are used by the code it generates. For now you need to this yourself. These packages are:

** TODO **

### Get started with a Code Generation Model

A code generation model is a simple DSL describing what objects will be built by a generator and what they will contain. These have been intended to be as simple as possible and allow reuse across the different generators.

Your starting point should be a simple model where you can add the properties and get an appreciation of what will be produced. You can then start to expand them with relationships.

Currently there is a single DSL type to represent each object to be generated. These are then contained in a wrapper dsl object that holds a collection of them. This allows the generator to be flexible produce as many (or as few) as you want with needing to use multiple attributes (unless you want to).

### Apply a Model Generation Attribute

The generation tool scans for attributes as part of the build process. These attributes give guidance to what generation logic will be used and the model that will be used to produce the desired code.

Currently the generated has the following limitations
* Code is placed in a namespace where the *.cs file is placed
* Multiple classes are written to a single *.cs file

You may also want to keep an eye on issues both in the nucleotide project and in the underlying code generator.

There are the following attributes

** TODO **
