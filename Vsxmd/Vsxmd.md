<a name='contents'></a>
# Contents [#](#contents)

- [AssemblyUnit](#T-Vsxmd.Units.AssemblyUnit)
  - [#ctor](#M-Vsxmd.Units.AssemblyUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.AssemblyUnit.ToMarkdown)
- [BaseUnit](#T-Vsxmd.Units.BaseUnit)
  - [#ctor](#M-Vsxmd.Units.BaseUnit.#ctor-System.Xml.Linq.XElement,System.String-)
  - [Element](#P-Vsxmd.Units.BaseUnit.Element)
  - [ElementContent](#P-Vsxmd.Units.BaseUnit.ElementContent)
  - [GetAttribute](#M-Vsxmd.Units.BaseUnit.GetAttribute-System.Xml.Linq.XName-)
  - [GetChild](#M-Vsxmd.Units.BaseUnit.GetChild-System.Xml.Linq.XName-)
  - [GetChildren](#M-Vsxmd.Units.BaseUnit.GetChildren-System.Xml.Linq.XName-)
  - [ToMarkdown](#M-Vsxmd.Units.BaseUnit.ToMarkdown)
- [Converter](#T-Vsxmd.Converter)
  - [#ctor](#M-Vsxmd.Converter.#ctor-System.String-)
  - [ToMarkdown](#M-Vsxmd.Converter.ToMarkdown)
- [ExampleUnit](#T-Vsxmd.Units.ExampleUnit)
  - [#ctor](#M-Vsxmd.Units.ExampleUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.ExampleUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.ExampleUnit.ToMarkdown-System.Xml.Linq.XElement-)
- [ExceptionUnit](#T-Vsxmd.Units.ExceptionUnit)
  - [#ctor](#M-Vsxmd.Units.ExceptionUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.ExceptionUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.ExceptionUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-)
- [Extensions](#T-Vsxmd.Units.Extensions)
  - [AsCode](#M-Vsxmd.Units.Extensions.AsCode-System.String-)
  - [Escape](#M-Vsxmd.Units.Extensions.Escape-System.String-)
  - [GetParamTypes](#M-Vsxmd.Units.Extensions.GetParamTypes-System.String-)
  - [Join](#M-Vsxmd.Units.Extensions.Join-System.Collections.Generic.IEnumerable{System.String},System.String-)
  - [NthLast\`\`1](#M-Vsxmd.Units.Extensions.NthLast``1-System.Collections.Generic.IEnumerable{``0},System.Int32-)
  - [TakeAllButLast\`\`1](#M-Vsxmd.Units.Extensions.TakeAllButLast``1-System.Collections.Generic.IEnumerable{``0},System.Int32-)
  - [ToAnchor](#M-Vsxmd.Units.Extensions.ToAnchor-System.String-)
  - [ToHereLink](#M-Vsxmd.Units.Extensions.ToHereLink-System.String-)
  - [ToLowerString](#M-Vsxmd.Units.Extensions.ToLowerString-Vsxmd.Units.MemberKind-)
  - [ToMarkdownText](#M-Vsxmd.Units.Extensions.ToMarkdownText-System.Xml.Linq.XElement-)
  - [ToNameSegments](#M-Vsxmd.Units.Extensions.ToNameSegments-System.String-)
- [IUnit](#T-Vsxmd.Units.IUnit)
  - [ToMarkdown](#M-Vsxmd.Units.IUnit.ToMarkdown)
- [MemberKind](#T-Vsxmd.Units.MemberKind)
  - [Constants](#F-Vsxmd.Units.MemberKind.Constants)
  - [Constructor](#F-Vsxmd.Units.MemberKind.Constructor)
  - [Method](#F-Vsxmd.Units.MemberKind.Method)
  - [NotSupported](#F-Vsxmd.Units.MemberKind.NotSupported)
  - [Property](#F-Vsxmd.Units.MemberKind.Property)
  - [Type](#F-Vsxmd.Units.MemberKind.Type)
- [MemberUnit](#T-Vsxmd.Units.MemberUnit)
  - [#ctor](#M-Vsxmd.Units.MemberUnit.#ctor-System.Xml.Linq.XElement-)
  - [Comparer](#P-Vsxmd.Units.MemberUnit.Comparer)
  - [FriendlyName](#P-Vsxmd.Units.MemberUnit.FriendlyName)
  - [Kind](#P-Vsxmd.Units.MemberUnit.Kind)
  - [Link](#P-Vsxmd.Units.MemberUnit.Link)
  - [TypeName](#P-Vsxmd.Units.MemberUnit.TypeName)
  - [ComplementType](#M-Vsxmd.Units.MemberUnit.ComplementType-System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit}-)
  - [ToMarkdown](#M-Vsxmd.Units.MemberUnit.ToMarkdown)
- [MemberUnitComparer](#T-Vsxmd.Units.MemberUnit.MemberUnitComparer)
  - [Compare](#M-Vsxmd.Units.MemberUnit.MemberUnitComparer.Compare-Vsxmd.Units.MemberUnit,Vsxmd.Units.MemberUnit-)
- [ParamUnit](#T-Vsxmd.Units.ParamUnit)
  - [#ctor](#M-Vsxmd.Units.ParamUnit.#ctor-System.Xml.Linq.XElement,System.String-)
  - [ToMarkdown](#M-Vsxmd.Units.ParamUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.ParamUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement},System.Collections.Generic.IEnumerable{System.String},Vsxmd.Units.MemberKind-)
- [PermissionUnit](#T-Vsxmd.Units.PermissionUnit)
  - [#ctor](#M-Vsxmd.Units.PermissionUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.PermissionUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.PermissionUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-)
- [Program](#T-Vsxmd.Program)
  - [Main](#M-Vsxmd.Program.Main-System.String[]-)
- [RemarksUnit](#T-Vsxmd.Units.RemarksUnit)
  - [#ctor](#M-Vsxmd.Units.RemarksUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.RemarksUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.RemarksUnit.ToMarkdown-System.Xml.Linq.XElement-)
- [ReturnsUnit](#T-Vsxmd.Units.ReturnsUnit)
  - [#ctor](#M-Vsxmd.Units.ReturnsUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.ReturnsUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.ReturnsUnit.ToMarkdown-System.Xml.Linq.XElement-)
- [SeealsoUnit](#T-Vsxmd.Units.SeealsoUnit)
  - [#ctor](#M-Vsxmd.Units.SeealsoUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.SeealsoUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.SeealsoUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-)
- [SummaryUnit](#T-Vsxmd.Units.SummaryUnit)
  - [#ctor](#M-Vsxmd.Units.SummaryUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.SummaryUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.SummaryUnit.ToMarkdown-System.Xml.Linq.XElement-)
- [TableOfContents](#T-Vsxmd.TableOfContents)
  - [#ctor](#M-Vsxmd.TableOfContents.#ctor-System.Linq.IOrderedEnumerable{Vsxmd.Units.MemberUnit}-)
  - [Link](#P-Vsxmd.TableOfContents.Link)
  - [ToMarkdown](#M-Vsxmd.TableOfContents.ToMarkdown)
- [Test](#T-Vsxmd.Program.Test)
  - [#ctor](#M-Vsxmd.Program.Test.#ctor)
  - [TestBacktickInSummary](#M-Vsxmd.Program.Test.TestBacktickInSummary)
  - [TestGenericException](#M-Vsxmd.Program.Test.TestGenericException)
  - [TestGenericParameter\`\`2](#M-Vsxmd.Program.Test.TestGenericParameter``2-System.Linq.Expressions.Expression{System.Func{``0,``1,System.String}}-)
  - [TestGenericPermission](#M-Vsxmd.Program.Test.TestGenericPermission)
  - [TestGenericRefence](#M-Vsxmd.Program.Test.TestGenericRefence)
- [TestGenericType`2](#T-Vsxmd.Program.TestGenericType`2)
  - [TestGenericMethod\`\`2](#M-Vsxmd.Program.TestGenericType`2.TestGenericMethod``2)
- [TypeparamUnit](#T-Vsxmd.Units.TypeparamUnit)
  - [#ctor](#M-Vsxmd.Units.TypeparamUnit.#ctor-System.Xml.Linq.XElement-)
  - [ToMarkdown](#M-Vsxmd.Units.TypeparamUnit.ToMarkdown)
  - [ToMarkdown](#M-Vsxmd.Units.TypeparamUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-)

<a name='assembly'></a>
# Vsxmd [#](#assembly) [^](#contents)

<a name='T-Vsxmd.Units.AssemblyUnit'></a>
## AssemblyUnit [#](#T-Vsxmd.Units.AssemblyUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Assembly unit.

<a name='M-Vsxmd.Units.AssemblyUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.AssemblyUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `AssemblyUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The assembly XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `assembly`. |

<a name='M-Vsxmd.Units.AssemblyUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.AssemblyUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Units.BaseUnit'></a>
## BaseUnit [#](#T-Vsxmd.Units.BaseUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

The base unit.

<a name='M-Vsxmd.Units.BaseUnit.#ctor-System.Xml.Linq.XElement,System.String-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.BaseUnit.#ctor-System.Xml.Linq.XElement,System.String-) [^](#contents)

##### Summary

Initializes a new instance of the `BaseUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The XML element. |
| elementName | System.String | The expected XML element name. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML `element` name not matches the expected `elementName`. |

<a name='P-Vsxmd.Units.BaseUnit.Element'></a>
### Element `property` [#](#P-Vsxmd.Units.BaseUnit.Element) [^](#contents)

##### Summary

Gets the XML element.

<a name='P-Vsxmd.Units.BaseUnit.ElementContent'></a>
### ElementContent `property` [#](#P-Vsxmd.Units.BaseUnit.ElementContent) [^](#contents)

##### Summary

Gets the Markdown content representing the element.

<a name='M-Vsxmd.Units.BaseUnit.GetAttribute-System.Xml.Linq.XName-'></a>
### GetAttribute `method` [#](#M-Vsxmd.Units.BaseUnit.GetAttribute-System.Xml.Linq.XName-) [^](#contents)

##### Summary

Returns the `XAttribute` value of this `XElement` that has the specified `name`.

##### Returns

An `XAttribute` value that has the specified `name`; `null` if there is no attribute with the specified `name`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.Xml.Linq.XName | The `XName` of the `XAttribute` to get. |

<a name='M-Vsxmd.Units.BaseUnit.GetChild-System.Xml.Linq.XName-'></a>
### GetChild `method` [#](#M-Vsxmd.Units.BaseUnit.GetChild-System.Xml.Linq.XName-) [^](#contents)

##### Summary

Gets the first (in document order) child element with the specified `name`.

##### Returns

A `XName` that matches the specified `name`, or `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.Xml.Linq.XName | The `XName` to match. |

<a name='M-Vsxmd.Units.BaseUnit.GetChildren-System.Xml.Linq.XName-'></a>
### GetChildren `method` [#](#M-Vsxmd.Units.BaseUnit.GetChildren-System.Xml.Linq.XName-) [^](#contents)

##### Summary

Returns a collection of the child elements of this element or document, in document order. Only elements that have a matching `XName` are included in the collection.

##### Returns

An ``IEnumerable`1`` of `XElement` containing the children that have a matching `XName`, in document order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.Xml.Linq.XName | The `XName` to match. |

<a name='M-Vsxmd.Units.BaseUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.BaseUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Converter'></a>
## Converter [#](#T-Vsxmd.Converter) [^](#contents)

##### Namespace

Vsxmd

##### Summary

Convert from XML docuement to Markdown syntax.

<a name='M-Vsxmd.Converter.#ctor-System.String-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Converter.#ctor-System.String-) [^](#contents)

##### Summary

Initializes a new instance of the `Converter` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| xmlPath | System.String | The XML document path. |

<a name='M-Vsxmd.Converter.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Converter.ToMarkdown) [^](#contents)

##### Summary

Convert to Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Units.ExampleUnit'></a>
## ExampleUnit [#](#T-Vsxmd.Units.ExampleUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Example unit.

<a name='M-Vsxmd.Units.ExampleUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.ExampleUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `ExampleUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The example XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `example`. |

<a name='M-Vsxmd.Units.ExampleUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ExampleUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.ExampleUnit.ToMarkdown-System.Xml.Linq.XElement-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ExampleUnit.ToMarkdown-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Convert the example XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The example XML element. |

<a name='T-Vsxmd.Units.ExceptionUnit'></a>
## ExceptionUnit [#](#T-Vsxmd.Units.ExceptionUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Exception unit.

<a name='M-Vsxmd.Units.ExceptionUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.ExceptionUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `ExceptionUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The exception XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `exception`. |

<a name='M-Vsxmd.Units.ExceptionUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ExceptionUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.ExceptionUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ExceptionUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-) [^](#contents)

##### Summary

Convert the exception XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement} | The exception XML element list. |

<a name='T-Vsxmd.Units.Extensions'></a>
## Extensions [#](#T-Vsxmd.Units.Extensions) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Extensions helper.

<a name='M-Vsxmd.Units.Extensions.AsCode-System.String-'></a>
### AsCode `method` [#](#M-Vsxmd.Units.Extensions.AsCode-System.String-) [^](#contents)

##### Summary

Wrap the `code` into Markdown backtick safely.

The backtick characters inside the `code` reverse as it is.

##### Returns

The Markdwon code span.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | System.String | The code span. |

##### Remarks

Reference: http://meta.stackexchange.com/questions/55437/how-can-the-backtick-character-be-included-in-code

<a name='M-Vsxmd.Units.Extensions.Escape-System.String-'></a>
### Escape `method` [#](#M-Vsxmd.Units.Extensions.Escape-System.String-) [^](#contents)

##### Summary

Escape the content to keep it raw in Markdown syntax.

##### Returns

The escaped content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | System.String | The content. |

<a name='M-Vsxmd.Units.Extensions.GetParamTypes-System.String-'></a>
### GetParamTypes `method` [#](#M-Vsxmd.Units.Extensions.GetParamTypes-System.String-) [^](#contents)

##### Summary

Gets the method parameter type names from the member unit `name`.

##### Returns

The method parameter type name list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.String | The member unit name. |

<a name='M-Vsxmd.Units.Extensions.Join-System.Collections.Generic.IEnumerable{System.String},System.String-'></a>
### Join `method` [#](#M-Vsxmd.Units.Extensions.Join-System.Collections.Generic.IEnumerable{System.String},System.String-) [^](#contents)

##### Summary

Concatenates the `value`s with the `separator`.

##### Returns

The concatenated string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | System.Collections.Generic.IEnumerable{System.String} | The string values. |
| separator | System.String | The separator. |

<a name='M-Vsxmd.Units.Extensions.NthLast``1-System.Collections.Generic.IEnumerable{``0},System.Int32-'></a>
### NthLast\`\`1 `method` [#](#M-Vsxmd.Units.Extensions.NthLast``1-System.Collections.Generic.IEnumerable{``0},System.Int32-) [^](#contents)

##### Summary

Gets the n-th last element from the `source`.

##### Returns

The element at the specified position in the `source` sequence.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | System.Collections.Generic.IEnumerable{\`\`0} | The source enumerable. |
| index | System.Int32 | The index for the n-th last. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements of `source`. |

<a name='M-Vsxmd.Units.Extensions.TakeAllButLast``1-System.Collections.Generic.IEnumerable{``0},System.Int32-'></a>
### TakeAllButLast\`\`1 `method` [#](#M-Vsxmd.Units.Extensions.TakeAllButLast``1-System.Collections.Generic.IEnumerable{``0},System.Int32-) [^](#contents)

##### Summary

Take all element except the last `count`.

##### Returns

The generated enumerable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | System.Collections.Generic.IEnumerable{\`\`0} | The source enumerable. |
| count | System.Int32 | The number to except. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements of `source`. |

<a name='M-Vsxmd.Units.Extensions.ToAnchor-System.String-'></a>
### ToAnchor `method` [#](#M-Vsxmd.Units.Extensions.ToAnchor-System.String-) [^](#contents)

##### Summary

Generate an anchor for the `href`.

##### Returns

The anchor for the `href`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| href | System.String | The href. |

<a name='M-Vsxmd.Units.Extensions.ToHereLink-System.String-'></a>
### ToHereLink `method` [#](#M-Vsxmd.Units.Extensions.ToHereLink-System.String-) [^](#contents)

##### Summary

Generate "to here" link for the `href`.

##### Returns

The "to here" link for the `href`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| href | System.String | The href. |

<a name='M-Vsxmd.Units.Extensions.ToLowerString-Vsxmd.Units.MemberKind-'></a>
### ToLowerString `method` [#](#M-Vsxmd.Units.Extensions.ToLowerString-Vsxmd.Units.MemberKind-) [^](#contents)

##### Summary

Convert the `MemberKind` to its lowercase name.

##### Returns

The member kind's lowercase name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberKind | Vsxmd.Units.MemberKind | The member kind. |

<a name='M-Vsxmd.Units.Extensions.ToMarkdownText-System.Xml.Linq.XElement-'></a>
### ToMarkdownText `method` [#](#M-Vsxmd.Units.Extensions.ToMarkdownText-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Convert the inline XML nodes to Markdown text. For example, it works for `summary` and `returns` elements.

##### Returns

The generated Markdwon content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The XML element. |

##### Example

This method converts the following `summary` element

```
<summary>The <paramref name="element" /> value is <value>null</value>, it throws <c>ArgumentException</c>. For more, see <see cref="M:Vsxmd.Units.Extensions.ToMarkdownText(System.Xml.Linq.XElement)" />.</summary>
```

To the below Markdown content.

```
The `element` value is `null`, it throws `ArgumentException`. For more, see `ToMarkdownText`.
```

<a name='M-Vsxmd.Units.Extensions.ToNameSegments-System.String-'></a>
### ToNameSegments `method` [#](#M-Vsxmd.Units.Extensions.ToNameSegments-System.String-) [^](#contents)

##### Summary

Split the member unit `name` to segments.

##### Returns

The name segments.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.String | The member unit name. |

##### Example

Split `M:Vsxmd.Converter.#ctor(System.String)` to `["Vsxmd", "Converter", "#ctor"]` string list.

<a name='T-Vsxmd.Units.IUnit'></a>
## IUnit [#](#T-Vsxmd.Units.IUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

`IUnit` is wrapper to handle XML elements.

<a name='M-Vsxmd.Units.IUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.IUnit.ToMarkdown) [^](#contents)

##### Summary

Represent the XML element content as Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Units.MemberKind'></a>
## MemberKind [#](#T-Vsxmd.Units.MemberKind) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

The member kind.

<a name='F-Vsxmd.Units.MemberKind.Constants'></a>
### Constants `constants` [#](#F-Vsxmd.Units.MemberKind.Constants) [^](#contents)

##### Summary

Constants

<a name='F-Vsxmd.Units.MemberKind.Constructor'></a>
### Constructor `constants` [#](#F-Vsxmd.Units.MemberKind.Constructor) [^](#contents)

##### Summary

Constructor.

<a name='F-Vsxmd.Units.MemberKind.Method'></a>
### Method `constants` [#](#F-Vsxmd.Units.MemberKind.Method) [^](#contents)

##### Summary

Method.

<a name='F-Vsxmd.Units.MemberKind.NotSupported'></a>
### NotSupported `constants` [#](#F-Vsxmd.Units.MemberKind.NotSupported) [^](#contents)

##### Summary

Not supported member kind.

<a name='F-Vsxmd.Units.MemberKind.Property'></a>
### Property `constants` [#](#F-Vsxmd.Units.MemberKind.Property) [^](#contents)

##### Summary

Property.

<a name='F-Vsxmd.Units.MemberKind.Type'></a>
### Type `constants` [#](#F-Vsxmd.Units.MemberKind.Type) [^](#contents)

##### Summary

Type.

<a name='T-Vsxmd.Units.MemberUnit'></a>
## MemberUnit [#](#T-Vsxmd.Units.MemberUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Member unit.

<a name='M-Vsxmd.Units.MemberUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.MemberUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `MemberUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The member XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `member`. |

<a name='P-Vsxmd.Units.MemberUnit.Comparer'></a>
### Comparer `property` [#](#P-Vsxmd.Units.MemberUnit.Comparer) [^](#contents)

##### Summary

Gets the member unit comparer.

<a name='P-Vsxmd.Units.MemberUnit.FriendlyName'></a>
### FriendlyName `property` [#](#P-Vsxmd.Units.MemberUnit.FriendlyName) [^](#contents)

##### Summary

Gets the user friendly name for the member. This name will be shown as caption.

<a name='P-Vsxmd.Units.MemberUnit.Kind'></a>
### Kind `property` [#](#P-Vsxmd.Units.MemberUnit.Kind) [^](#contents)

##### Summary

Gets the member kind, one of `MemberKind`.

<a name='P-Vsxmd.Units.MemberUnit.Link'></a>
### Link `property` [#](#P-Vsxmd.Units.MemberUnit.Link) [^](#contents)

##### Summary

Gets the link pointing to this member unit.

<a name='P-Vsxmd.Units.MemberUnit.TypeName'></a>
### TypeName `property` [#](#P-Vsxmd.Units.MemberUnit.TypeName) [^](#contents)

##### Summary

Gets the type name.

##### Example

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='M-Vsxmd.Units.MemberUnit.ComplementType-System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit}-'></a>
### ComplementType `method` [#](#M-Vsxmd.Units.MemberUnit.ComplementType-System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit}-) [^](#contents)

##### Summary

Complement a type unit if the member unit `group` does not have one. One member unit group has the same `TypeName`.

##### Returns

The complemented member unit group.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| group | System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit} | The member unit group. |

<a name='M-Vsxmd.Units.MemberUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.MemberUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Units.MemberUnit.MemberUnitComparer'></a>
## MemberUnitComparer [#](#T-Vsxmd.Units.MemberUnit.MemberUnitComparer) [^](#contents)

##### Namespace

Vsxmd.Units.MemberUnit

<a name='M-Vsxmd.Units.MemberUnit.MemberUnitComparer.Compare-Vsxmd.Units.MemberUnit,Vsxmd.Units.MemberUnit-'></a>
### Compare `method` [#](#M-Vsxmd.Units.MemberUnit.MemberUnitComparer.Compare-Vsxmd.Units.MemberUnit,Vsxmd.Units.MemberUnit-) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Units.ParamUnit'></a>
## ParamUnit [#](#T-Vsxmd.Units.ParamUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Param unit.

<a name='M-Vsxmd.Units.ParamUnit.#ctor-System.Xml.Linq.XElement,System.String-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.ParamUnit.#ctor-System.Xml.Linq.XElement,System.String-) [^](#contents)

##### Summary

Initializes a new instance of the `ParamUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The param XML element. |
| paramType | System.String | The paramter type corresponding to the param XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `param`. |

<a name='M-Vsxmd.Units.ParamUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ParamUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.ParamUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement},System.Collections.Generic.IEnumerable{System.String},Vsxmd.Units.MemberKind-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ParamUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement},System.Collections.Generic.IEnumerable{System.String},Vsxmd.Units.MemberKind-) [^](#contents)

##### Summary

Convert the param XML element to Markdown safely.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement} | The param XML element list. |
| paramTypes | System.Collections.Generic.IEnumerable{System.String} | The paramater type names. |
| memberKind | Vsxmd.Units.MemberKind | The member kind of the parent element. |

##### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is `Constructor` or `Method`, it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.

<a name='T-Vsxmd.Units.PermissionUnit'></a>
## PermissionUnit [#](#T-Vsxmd.Units.PermissionUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Permission unit.

<a name='M-Vsxmd.Units.PermissionUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.PermissionUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `PermissionUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The permission XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `permission`. |

<a name='M-Vsxmd.Units.PermissionUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.PermissionUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.PermissionUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.PermissionUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-) [^](#contents)

##### Summary

Convert the permission XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement} | The permission XML element list. |

<a name='T-Vsxmd.Program'></a>
## Program [#](#T-Vsxmd.Program) [^](#contents)

##### Namespace

Vsxmd

##### Summary

Program entry.

##### Permissions

| Name | Description |
| ---- | ----------- |
| System.Security.PermissionSet | Vsxmd provides no program APIs. |

##### Remarks

Usage syntax: `Vsxmd.exe <input-XML-path> [output-Markdown-path]`

The `input-XML-path` argument is required. It references to the VS generated XML documentation file.

The `output-Markdown-path` argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a `.md` file with same file name as the XML documentation file, path at the XML documentation folder.

<a name='M-Vsxmd.Program.Main-System.String[]-'></a>
### Main `method` [#](#M-Vsxmd.Program.Main-System.String[]-) [^](#contents)

##### Summary

Program main function entry.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | System.String[] | Program arguments. |

##### See Also

- `Vsxmd.Program`

<a name='T-Vsxmd.Units.RemarksUnit'></a>
## RemarksUnit [#](#T-Vsxmd.Units.RemarksUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Remarks unit.

<a name='M-Vsxmd.Units.RemarksUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.RemarksUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `RemarksUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The remarks XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `remarks`. |

<a name='M-Vsxmd.Units.RemarksUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.RemarksUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.RemarksUnit.ToMarkdown-System.Xml.Linq.XElement-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.RemarksUnit.ToMarkdown-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Convert the remarks XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The remarks XML element. |

<a name='T-Vsxmd.Units.ReturnsUnit'></a>
## ReturnsUnit [#](#T-Vsxmd.Units.ReturnsUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Returns unit.

<a name='M-Vsxmd.Units.ReturnsUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.ReturnsUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `ReturnsUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The returns XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `returns`. |

<a name='M-Vsxmd.Units.ReturnsUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ReturnsUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.ReturnsUnit.ToMarkdown-System.Xml.Linq.XElement-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.ReturnsUnit.ToMarkdown-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Convert the returns XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The returns XML element. |

<a name='T-Vsxmd.Units.SeealsoUnit'></a>
## SeealsoUnit [#](#T-Vsxmd.Units.SeealsoUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Seealso unit.

<a name='M-Vsxmd.Units.SeealsoUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.SeealsoUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `SeealsoUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The seealso XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `seealso`. |

<a name='M-Vsxmd.Units.SeealsoUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.SeealsoUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.SeealsoUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.SeealsoUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-) [^](#contents)

##### Summary

Convert the seealso XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement} | The seealso XML element list. |

<a name='T-Vsxmd.Units.SummaryUnit'></a>
## SummaryUnit [#](#T-Vsxmd.Units.SummaryUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Summary unit.

<a name='M-Vsxmd.Units.SummaryUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.SummaryUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `SummaryUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The summary XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `summary`. |

<a name='M-Vsxmd.Units.SummaryUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.SummaryUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.SummaryUnit.ToMarkdown-System.Xml.Linq.XElement-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.SummaryUnit.ToMarkdown-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Convert the summary XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The summary XML element. |

<a name='T-Vsxmd.TableOfContents'></a>
## TableOfContents [#](#T-Vsxmd.TableOfContents) [^](#contents)

##### Namespace

Vsxmd

##### Summary

Table of contents.

<a name='M-Vsxmd.TableOfContents.#ctor-System.Linq.IOrderedEnumerable{Vsxmd.Units.MemberUnit}-'></a>
### #ctor `constructor` [#](#M-Vsxmd.TableOfContents.#ctor-System.Linq.IOrderedEnumerable{Vsxmd.Units.MemberUnit}-) [^](#contents)

##### Summary

Initializes a new instance of the `TableOfContents` class.

It convert the table of contents from the `memberUnits`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberUnits | System.Linq.IOrderedEnumerable{Vsxmd.Units.MemberUnit} | The member unit list. |

<a name='P-Vsxmd.TableOfContents.Link'></a>
### Link `property` [#](#P-Vsxmd.TableOfContents.Link) [^](#contents)

##### Summary

Gets the link pointing to the table of contents.

<a name='M-Vsxmd.TableOfContents.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.TableOfContents.ToMarkdown) [^](#contents)

##### Summary

Convert the table of contents to Markdown syntax.

##### Returns

The table of contents in Markdown syntax.

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Program.Test'></a>
## Test [#](#T-Vsxmd.Program.Test) [^](#contents)

##### Namespace

Vsxmd.Program

<a name='M-Vsxmd.Program.Test.#ctor'></a>
### #ctor `constructor` [#](#M-Vsxmd.Program.Test.#ctor) [^](#contents)

##### Summary

Initializes a new instance of the `Test` class.

Test constructor without parameters.

See `#ctor`

##### Parameters

This constructor has no parameters.

<a name='M-Vsxmd.Program.Test.TestBacktickInSummary'></a>
### TestBacktickInSummary `method` [#](#M-Vsxmd.Program.Test.TestBacktickInSummary) [^](#contents)

##### Summary

Test backtick characters in summary comment.

See \`should not inside code block\`.

See `` `backtick inside code block` ``

See \``code block inside backtick`\`

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Program.Test.TestGenericException'></a>
### TestGenericException `method` [#](#M-Vsxmd.Program.Test.TestGenericException) [^](#contents)

##### Summary

Test generic exception type.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| Vsxmd.Program.Test.TestGenericParameter\`\`2(System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1,System.String}}) | Just for test. |

<a name='M-Vsxmd.Program.Test.TestGenericParameter``2-System.Linq.Expressions.Expression{System.Func{``0,``1,System.String}}-'></a>
### TestGenericParameter\`\`2 `method` [#](#M-Vsxmd.Program.Test.TestGenericParameter``2-System.Linq.Expressions.Expression{System.Func{``0,``1,System.String}}-) [^](#contents)

##### Summary

Test generic parameter type.

See `T1` and `T2`.

##### Returns

Nothing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1,System.String}} | The linq expression. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T1 | Generic type 1. |
| T2 | Generic type 2. |

<a name='M-Vsxmd.Program.Test.TestGenericPermission'></a>
### TestGenericPermission `method` [#](#M-Vsxmd.Program.Test.TestGenericPermission) [^](#contents)

##### Summary

Test generic exception type.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Permissions

| Name | Description |
| ---- | ----------- |
| Vsxmd.Program.Test.TestGenericParameter\`\`2(System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1,System.String}}) | Just for test. |

<a name='M-Vsxmd.Program.Test.TestGenericRefence'></a>
### TestGenericRefence `method` [#](#M-Vsxmd.Program.Test.TestGenericRefence) [^](#contents)

##### Summary

Test generic reference type.

See ```TestGenericParameter``2```.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='T-Vsxmd.Program.TestGenericType`2'></a>
## TestGenericType`2 [#](#T-Vsxmd.Program.TestGenericType`2) [^](#contents)

##### Namespace

Vsxmd.Program

##### Summary

Test generic type.

See ``TestGenericType`2``.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T1 | Generic type 1. |
| T2 | Generic type 2. |

<a name='M-Vsxmd.Program.TestGenericType`2.TestGenericMethod``2'></a>
### TestGenericMethod\`\`2 `method` [#](#M-Vsxmd.Program.TestGenericType`2.TestGenericMethod``2) [^](#contents)

##### Summary

Test generic method.

See ```TestGenericMethod``2```

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T3 | Generic type 3. |
| T4 | Generic type 4. |

<a name='T-Vsxmd.Units.TypeparamUnit'></a>
## TypeparamUnit [#](#T-Vsxmd.Units.TypeparamUnit) [^](#contents)

##### Namespace

Vsxmd.Units

##### Summary

Typeparam unit.

<a name='M-Vsxmd.Units.TypeparamUnit.#ctor-System.Xml.Linq.XElement-'></a>
### #ctor `constructor` [#](#M-Vsxmd.Units.TypeparamUnit.#ctor-System.Xml.Linq.XElement-) [^](#contents)

##### Summary

Initializes a new instance of the `TypeparamUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The typeparam XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| System.ArgumentException | Throw if XML element name is not `typeparam`. |

<a name='M-Vsxmd.Units.TypeparamUnit.ToMarkdown'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.TypeparamUnit.ToMarkdown) [^](#contents)

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-Vsxmd.Units.TypeparamUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-'></a>
### ToMarkdown `method` [#](#M-Vsxmd.Units.TypeparamUnit.ToMarkdown-System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}-) [^](#contents)

##### Summary

Convert the param XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement} | The param XML element list. |
