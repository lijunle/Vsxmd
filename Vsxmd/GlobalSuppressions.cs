//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#if NETCOREAPP2_2
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307: Specify StringComparison", Justification = ".Net Framework not supports StirngComparison parameter for some string methods yet.")]
#endif
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "The uninstantiated internal class is for unit testing the XML documentation.", Scope = "type", Target = "~T:Vsxmd.Program.Test")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "The uninstantiated internal class is for unit testing the XML documentation.", Scope = "type", Target = "~T:Vsxmd.Program.TestGenericType`2")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1801: Review unused parameters", Justification = "The unused parameter is for unit testing the XML documentation.", Scope = "member", Target = "~M:Vsxmd.Program.Test.TestGenericParameter``2(System.Linq.Expressions.Expression{System.Func{``0,``1,System.String}})")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1801: Review unused parameters", Justification = "The unused parameter is for unit testing the XML documentation.", Scope = "member", Target = "~M:Vsxmd.Program.Test.TestParamWithoutDescription(System.String)")]
