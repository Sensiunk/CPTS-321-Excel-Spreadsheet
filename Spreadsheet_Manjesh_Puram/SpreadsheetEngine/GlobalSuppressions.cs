// <copyright file="GlobalSuppressions.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "The Assignment asks us to do a certain way but stylecop wants it other ways.", Scope = "type", Target = "~T:CptS321.SpreadsheetCell")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "The Assignment asks us to do a certain way but stylecop wants it other ways.", Scope = "member", Target = "~F:CptS321.SpreadsheetCell.rowIndex")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "The Assignment asks us to do a certain way but stylecop wants it other ways.", Scope = "member", Target = "~F:CptS321.SpreadsheetCell.cellText")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "There is nothing we can do about the class possibly containing a single type.", Scope = "type", Target = "~T:CptS321.NewCell")]
