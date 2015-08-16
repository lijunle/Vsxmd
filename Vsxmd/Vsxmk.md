# Vsxmd

## AssemblyUnit

##### Namespace

Vsxmd.Units

##### Summary

Assembly unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `AssemblyUnit` class.

### ToMarkdown `method`

## BaseUnit

##### Namespace

Vsxmd.Units

##### Summary

The base unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `BaseUnit` class.

### Element `property`

##### Summary

Gets the XML element.

### ToMarkdown `method`

## Converter

##### Namespace

Vsxmd

##### Summary

Convert from XML docuement to Markdown syntax.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `Converter` class.

### ToMarkdown `method`

##### Summary

Convert to Markdown syntax.

##### Returns

The generated Markdown content.

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

### Join `method`

##### Summary

Concatenates the s with the .

##### Returns

The concatenated string.

### NthLastOrDefault\`\`1 `method`

##### Summary

Gets the n-th last element from the .

##### Returns

The target element, default(`TSource`) if not found.

### TakeAllButLast\`\`1 `method`

##### Summary

Take all element except the last .

##### Returns

The generated enumerable.

### ToMarkdownText `method`

##### Summary

Convert the inline XML nodes to Markdown text. For example, it works for `summary` and `returns` elements.

##### Returns

The generated Markdwon content.

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

## MemberKind

##### Namespace

Vsxmd.Units

##### Summary

The member kind.

### Constants `constants`

##### Summary

Constants

### Constructor `constants`

##### Summary

Constructor.

### Method `constants`

##### Summary

Method.

### NotSupported `constants`

##### Summary

Not supported member kind.

### Property `constants`

##### Summary

Property.

### Type `constants`

##### Summary

Type.

## MemberUnit

##### Namespace

Vsxmd.Units

##### Summary

Member unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `MemberUnit` class.

### Comparer `property`

##### Summary

Gets the member unit comparer.

### Kind `property`

##### Summary

Gets the member kind, one of `MemberKind`.

### Name `property`

##### Summary

Gets the name.

### NamespaceName `property`

##### Summary

Gets the namespace name.

### TypeFullName `property`

##### Summary

Gets the type full name.

### TypeName `property`

##### Summary

Gets the type name.

### ToMarkdown `method`

### Compare `method`

## Program

##### Namespace

Vsxmd

##### Summary

Program entry.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `Program` class.

### Main `method`

##### Summary

Program main function entry.

## ReturnsUnit

##### Namespace

Vsxmd.Units

##### Summary

Returns unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `ReturnsUnit` class.

### ToMarkdown `method`

### ToMarkdown `method`

##### Summary

Convert the returns XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.

## SummaryUnit

##### Namespace

Vsxmd.Units

##### Summary

Summary unit.

### #ctor `constructor`

##### Summary

Initializes a new instance of the `SummaryUnit` class.

### ToMarkdown `method`

### ToMarkdown `method`

##### Summary

Convert the summary XML element to Markdown safely. If elemnt is `null`, return empty string.

##### Returns

The generated Markdown.
