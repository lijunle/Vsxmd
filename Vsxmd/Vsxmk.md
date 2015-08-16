# Vsxmd

## AssemblyUnit

##### Namespace

Vsxmd.Units

##### Summary

Assembly unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `AssemblyUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The assembly XML element. |

### ToMarkdown `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

## BaseUnit

##### Namespace

Vsxmd.Units

##### Summary

The base unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `BaseUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The XML element. |
| elementName | System.String | The expected XML element name. |

### Element `property`

##### Summary

Gets the XML element.

##### Parameters

This method has no parameters.

### ToMarkdown `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

## Converter

##### Namespace

Vsxmd

##### Summary

Convert from XML docuement to Markdown syntax.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `Converter` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| xmlPath | System.String | The XML document path. |

### ToMarkdown `method`

##### Summary

Convert to Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.

## Extensions

##### Namespace

Vsxmd.Units

##### Summary

Extensions helper.

### Escape `method`

##### Summary

Escape the content to keep it raw in Markdown syntax.

##### Returns

The escaped content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | System.String | The content. |

### Join `method`

##### Summary

Concatenates the s with the .

##### Returns

The concatenated string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | System.Collections.Generic.IEnumerable{System.String} | The string values. |
| separator | System.String | The separator. |

### NthLastOrDefault\`\`1 `method`

##### Summary

Gets the n-th last element from the .

##### Returns

The target element, default(`TSource`) if not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | System.Collections.Generic.IEnumerable{``0} | The source enumerable. |
| index | System.Int32 | The index for the n-th last. |

### TakeAllButLast\`\`1 `method`

##### Summary

Take all element except the last .

##### Returns

The generated enumerable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | System.Collections.Generic.IEnumerable{``0} | The source enumerable. |
| count | System.Int32 | The number to except. |

### ToMarkdownText `method`

##### Summary

Convert the inline XML nodes to Markdown text. For example, it works for `summary` and `returns` elements.

##### Returns

The generated Markdwon content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The XML element. |

## IUnit

##### Namespace

Vsxmd.Units

##### Summary

`IUnit` is wrapper to handle XML elements.

### ToMarkdown `method`

##### Summary

Represent the XML element content as Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.

## MemberKind

##### Namespace

Vsxmd.Units

##### Summary

The member kind.

### Constants `constants`

##### Summary

Constants

##### Parameters

This method has no parameters.

### Constructor `constants`

##### Summary

Constructor.

##### Parameters

This method has no parameters.

### Method `constants`

##### Summary

Method.

##### Parameters

This method has no parameters.

### NotSupported `constants`

##### Summary

Not supported member kind.

##### Parameters

This method has no parameters.

### Property `constants`

##### Summary

Property.

##### Parameters

This method has no parameters.

### Type `constants`

##### Summary

Type.

##### Parameters

This method has no parameters.

## MemberUnit

##### Namespace

Vsxmd.Units

##### Summary

Member unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `MemberUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The member XML element. |

### Comparer `property`

##### Summary

Gets the member unit comparer.

##### Parameters

This method has no parameters.

### Kind `property`

##### Summary

Gets the member kind, one of `MemberKind`.

##### Parameters

This method has no parameters.

### Name `property`

##### Summary

Gets the name.

##### Parameters

This method has no parameters.

### NamespaceName `property`

##### Summary

Gets the namespace name.

##### Parameters

This method has no parameters.

### TypeFullName `property`

##### Summary

Gets the type full name.

##### Parameters

This method has no parameters.

### TypeName `property`

##### Summary

Gets the type name.

##### Parameters

This method has no parameters.

### ToMarkdown `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

### Compare `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

## ParamUnit

##### Namespace

Vsxmd.Units

##### Summary

Param unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `ParamUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The param XML element. |
| paramType | System.String | The paramter type corresponding to the param XML element. |

### ToMarkdown `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

### ToMarkdown `method`

##### Summary

Convert the param XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement} | The param XML element list. |
| paramTypes | System.Collections.Generic.IEnumerable{System.String} | The paramater type names. |

## Program

##### Namespace

Vsxmd

##### Summary

Program entry.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `Program` class.

##### Parameters

This method has no parameters.

### Main `method`

##### Summary

Program main function entry.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | System.String[] | Program arguments. |

## ReturnsUnit

##### Namespace

Vsxmd.Units

##### Summary

Returns unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `ReturnsUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The returns XML element. |

### ToMarkdown `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

### ToMarkdown `method`

##### Summary

Convert the returns XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The returns XML element. |

## SummaryUnit

##### Namespace

Vsxmd.Units

##### Summary

Summary unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `SummaryUnit` class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The summary XML element. |

### ToMarkdown `method`

Inherit documentation from parent.

##### Parameters

This method has no parameters.

### ToMarkdown `method`

##### Summary

Convert the summary XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The summary XML element. |
