Abmes.SyntaxHighlighter
=======================
[![Build status](https://ci.appveyor.com/api/projects/status/bdm9l3rwyhlt477w?svg=true)](https://ci.appveyor.com/project/abmes/syntaxhighlighter)

This is a Visual Studio extension which adds the following classification types:
- C#/JS/TS Delimiter - matches '**:**', '**;**' and '**,**'
- C#/JS/TS Parenthesis - matches '**(**' and '**)**'
- C#/JS/TS Bracket - matches '**[**' and '**]**'
- C#/JS/TS Brace - matches '**{**' and '**}**'
- C# Namespace - matches a C# namespace

The above classification types can then be colored by going to Tools -> Options -> Fonts and Colors

Installation
------------
You can get the latest release from the Visual Studio Gallery. Go to Tools -> Extensions and Updates -> Online -> Visual Studio Gallery and search for Abmes SyntaxHighlighter

Compatible Visual Studio Versions
---------------------------------
Currently this extension has been tested on:
* Visual Studio 2012
* Visual Studio 2013
* Visual Studio 2015 RC

Recommended Colors
------------------
- Operator = Red
- String = Green
- Comment = Gray
- XML Doc Comment = Silver
- Number = Navy
- Preprocessor Keyword = Olive
- C# Namespace (Abmes) = R: 120, G: 10, B: 170
- C#/JS/TS Brace (Abmes) = Blue

Recommended Colors specific for VS 2012 and VS 2013
---------------------------------------------------
- String (C# @ Verbatim) = Green
- C#/JS/TS Bracket (Abmes) = Red
- C#/JS/TS Delimiter (Abmes) = Red
- C#/JS/TS Parentheses (Abmes) = Red

Recommended Colors specifig for VS 2015 RC
------------------------------------------
- String - Verbatim = Green
- Punctuation = Red
- C#/JS/TS Bracket (Abmes) = Default
- C#/JS/TS Delimiter (Abmes) = Default
- C#/JS/TS Parentheses (Abmes) = Default

Other recommended colors
------------------------
The following colors are recommended for **"Breakpoint"**, **"Breakpoint - Mapped"** and **"Breakpoint - Advanced"**

Breakpoint (Disabled) - Foreground = R: 231, G: 190, B: 196

Breakpoint (Enabled) - Foreground = Automatic  
Breakpoint (Enabled) - Background = R: 231, G: 190, B: 196

Breakpoint (Error) - Foreground = Red  
Breakpoint (Error) - Background = R: 231, G: 190, B: 196

Breakpoint (Scroll Bar) - Background = R: 231, G: 190, B: 196

Breakpoint (Warning) - Foreground = Automatic  
Breakpoint (Warning) - Background = R: 231, G: 190, B: 196
