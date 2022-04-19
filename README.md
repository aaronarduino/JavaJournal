# Java Journal
A coffee tasting web application

## Description

Java Journal is a coffee tasting web application that is inspired by: 

## Status

In progress... build at your own risk...

## Tech

- .Net Core MVC
- EF
- Bootstrap

## Development Log

This was my first time using EF for something more complex than a TODO app and I ran into an issue where I thought EF was not detecting the relationships between objects correctly.

The actual issue was that I was scaffolding the controller and views for the crud operations and the scaffolding was not including the sub-objects. The fix was to add the objects manually. I wonder why Visual Studio does not scaffold the crud operations for the sub-objects?
