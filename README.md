# Nucleotide

![Build status](https://ci.appveyor.com/api/projects/status/jk9v57hxjj0mi6t4?svg=true)

## Mission Statement

To provide a tool that automatically generates repeditive .NET code to allow better use of developers time.

## Current Status

This project is in a beta phase and tied to work being done in https://github.com/dpvreony/whipstaff, development is slow due to COVID workload.

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

This version of Nucleotide is built upon CodeGenerators.Roslyn, this has allowed the removal of dependency on -.tt files.

## Credits

* https://github.com/AArnott/CodeGeneration.Roslyn

## Getting Started

### Pre-requisites

You will need:
* Visual Studio 2019
* A project using
  * netcore 3.1 upward
  * C# 8 language compiler settings or later

### Before you start

You can use the following project structure

1. Your code generation model and the generated code are in the same project.
2. Your code generation model is in Project1, while your generated code is in Project2.

### Get the package (Single Project)

You want to install Nucleotide in the project where you want to place your generated model.

` Install-Package Dhgms.Nucleotide `

### Get the package (Dual Project)

**In project1.**

1. ` Install-Package Dhgms.Nucleotide `

1. Add Your Code Generation Models

1. Inherit the Code Generation Attributes.

**In project2.**

1. Reference Project1.

1. ` Install-Package Dhgms.Nucleotide `

1. Apply the Assembly Code Generation Attributes.

### Get started with a Code Generation Model

TODO.

### Apply a Model Generation Attribute

TODO.

## Viewing the documentation

The documentation can be found at http://dpvreony.github.io/nucleotide/

## Contributing to the code

See the [contribution guidelines](CONTRIBUTING.md).
