<a name='assembly'></a>
# Vsxmd

## Contents

- [AssemblyUnit](#vsxmd-units-assemblyunit)
  - [#ctor(element)](#vsxmd-units-assemblyunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-assemblyunit-tomarkdown)
- [BaseUnit](#vsxmd-units-baseunit)
  - [#ctor(element,elementName)](#vsxmd-units-baseunit-#ctor-system-xml-linq-xelement,system-string-)
  - [Element](#vsxmd-units-baseunit-element)
  - [ElementContent](#vsxmd-units-baseunit-elementcontent)
  - [GetAttribute(name)](#vsxmd-units-baseunit-getattribute-system-xml-linq-xname-)
  - [GetChild(name)](#vsxmd-units-baseunit-getchild-system-xml-linq-xname-)
  - [GetChildren(name)](#vsxmd-units-baseunit-getchildren-system-xml-linq-xname-)
  - [ToMarkdown()](#vsxmd-units-baseunit-tomarkdown)
- [Converter](#vsxmd-converter)
  - [#ctor(document)](#vsxmd-converter-#ctor-system-xml-linq-xdocument-)
  - [ToMarkdown(document)](#vsxmd-converter-tomarkdown-system-xml-linq-xdocument-)
  - [ToMarkdown()](#vsxmd-converter-tomarkdown)
- [ExampleUnit](#vsxmd-units-exampleunit)
  - [#ctor(element)](#vsxmd-units-exampleunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-exampleunit-tomarkdown)
  - [ToMarkdown(element)](#vsxmd-units-exampleunit-tomarkdown-system-xml-linq-xelement-)
- [ExceptionUnit](#vsxmd-units-exceptionunit)
  - [#ctor(element)](#vsxmd-units-exceptionunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-exceptionunit-tomarkdown)
  - [ToMarkdown(elements)](#vsxmd-units-exceptionunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-)
- [Extensions](#vsxmd-units-extensions)
  - [AsCode(code)](#vsxmd-units-extensions-ascode-system-string-)
  - [Escape(content)](#vsxmd-units-extensions-escape-system-string-)
  - [Join(value,separator)](#vsxmd-units-extensions-join-system-collections-generic-ienumerable{system-string},system-string-)
  - [NthLast\`\`1(source,index)](#vsxmd-units-extensions-nthlast``1-system-collections-generic-ienumerable{``0},system-int32-)
  - [Suffix(value,suffix)](#vsxmd-units-extensions-suffix-system-string,system-string-)
  - [TakeAllButLast\`\`1(source,count)](#vsxmd-units-extensions-takeallbutlast``1-system-collections-generic-ienumerable{``0},system-int32-)
  - [ToAnchor(href)](#vsxmd-units-extensions-toanchor-system-string-)
  - [ToHereLink(href)](#vsxmd-units-extensions-toherelink-system-string-)
  - [ToLowerString(memberKind)](#vsxmd-units-extensions-tolowerstring-vsxmd-units-memberkind-)
  - [ToMarkdownText(element)](#vsxmd-units-extensions-tomarkdowntext-system-xml-linq-xelement-)
  - [ToReferenceLink(memberName,useShortName)](#vsxmd-units-extensions-toreferencelink-system-string,system-boolean-)
- [IConverter](#vsxmd-iconverter)
  - [ToMarkdown()](#vsxmd-iconverter-tomarkdown)
- [IUnit](#vsxmd-units-iunit)
  - [ToMarkdown()](#vsxmd-units-iunit-tomarkdown)
- [MemberKind](#vsxmd-units-memberkind)
  - [Constants](#vsxmd-units-memberkind-constants)
  - [Constructor](#vsxmd-units-memberkind-constructor)
  - [Method](#vsxmd-units-memberkind-method)
  - [NotSupported](#vsxmd-units-memberkind-notsupported)
  - [Property](#vsxmd-units-memberkind-property)
  - [Type](#vsxmd-units-memberkind-type)
- [MemberName](#vsxmd-units-membername)
  - [#ctor(name,paramNames)](#vsxmd-units-membername-#ctor-system-string,system-collections-generic-ienumerable{system-string}-)
  - [#ctor(name)](#vsxmd-units-membername-#ctor-system-string-)
  - [Caption](#vsxmd-units-membername-caption)
  - [Kind](#vsxmd-units-membername-kind)
  - [Link](#vsxmd-units-membername-link)
  - [Namespace](#vsxmd-units-membername-namespace)
  - [TypeName](#vsxmd-units-membername-typename)
  - [CompareTo()](#vsxmd-units-membername-compareto-vsxmd-units-membername-)
  - [GetParamTypes()](#vsxmd-units-membername-getparamtypes)
  - [ToReferenceLink(useShortName)](#vsxmd-units-membername-toreferencelink-system-boolean-)
- [MemberUnit](#vsxmd-units-memberunit)
  - [#ctor(element)](#vsxmd-units-memberunit-#ctor-system-xml-linq-xelement-)
  - [Comparer](#vsxmd-units-memberunit-comparer)
  - [Kind](#vsxmd-units-memberunit-kind)
  - [Link](#vsxmd-units-memberunit-link)
  - [TypeName](#vsxmd-units-memberunit-typename)
  - [ComplementType(group)](#vsxmd-units-memberunit-complementtype-system-collections-generic-ienumerable{vsxmd-units-memberunit}-)
  - [ToMarkdown()](#vsxmd-units-memberunit-tomarkdown)
- [MemberUnitComparer](#vsxmd-units-memberunit-memberunitcomparer)
  - [Compare()](#vsxmd-units-memberunit-memberunitcomparer-compare-vsxmd-units-memberunit,vsxmd-units-memberunit-)
- [ParamUnit](#vsxmd-units-paramunit)
  - [#ctor(element,paramType)](#vsxmd-units-paramunit-#ctor-system-xml-linq-xelement,system-string-)
  - [ToMarkdown()](#vsxmd-units-paramunit-tomarkdown)
  - [ToMarkdown(elements,paramTypes,memberKind)](#vsxmd-units-paramunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement},system-collections-generic-ienumerable{system-string},vsxmd-units-memberkind-)
- [PermissionUnit](#vsxmd-units-permissionunit)
  - [#ctor(element)](#vsxmd-units-permissionunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-permissionunit-tomarkdown)
  - [ToMarkdown(elements)](#vsxmd-units-permissionunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-)
- [Program](#vsxmd-program)
  - [Main(args)](#vsxmd-program-main-system-string[]-)
- [RemarksUnit](#vsxmd-units-remarksunit)
  - [#ctor(element)](#vsxmd-units-remarksunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-remarksunit-tomarkdown)
  - [ToMarkdown(element)](#vsxmd-units-remarksunit-tomarkdown-system-xml-linq-xelement-)
- [ReturnsUnit](#vsxmd-units-returnsunit)
  - [#ctor(element)](#vsxmd-units-returnsunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-returnsunit-tomarkdown)
  - [ToMarkdown(element)](#vsxmd-units-returnsunit-tomarkdown-system-xml-linq-xelement-)
- [SeealsoUnit](#vsxmd-units-seealsounit)
  - [#ctor(element)](#vsxmd-units-seealsounit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-seealsounit-tomarkdown)
  - [ToMarkdown(elements)](#vsxmd-units-seealsounit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-)
- [SummaryUnit](#vsxmd-units-summaryunit)
  - [#ctor(element)](#vsxmd-units-summaryunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-summaryunit-tomarkdown)
  - [ToMarkdown(element)](#vsxmd-units-summaryunit-tomarkdown-system-xml-linq-xelement-)
- [TableOfContents](#vsxmd-tableofcontents)
  - [#ctor(memberUnits)](#vsxmd-tableofcontents-#ctor-system-linq-iorderedenumerable{vsxmd-units-memberunit}-)
  - [Link](#vsxmd-tableofcontents-link)
  - [ToMarkdown()](#vsxmd-tableofcontents-tomarkdown)
- [Test](#vsxmd-program-test)
  - [#ctor()](#vsxmd-program-test-#ctor)
  - [TestBacktickInSummary()](#vsxmd-program-test-testbacktickinsummary)
  - [TestGenericException()](#vsxmd-program-test-testgenericexception)
  - [TestGenericParameter\`\`2(expression)](#vsxmd-program-test-testgenericparameter``2-system-linq-expressions-expression{system-func{``0,``1,system-string}}-)
  - [TestGenericPermission()](#vsxmd-program-test-testgenericpermission)
  - [TestGenericReference()](#vsxmd-program-test-testgenericreference)
  - [TestParamWithoutDescription(p)](#vsxmd-program-test-testparamwithoutdescription-system-string-)
  - [TestSeeLangword()](#vsxmd-program-test-testseelangword)
  - [TestSpaceAfterInlineElements\`\`1()](#vsxmd-program-test-testspaceafterinlineelements``1-system-boolean-)
- [TestGenericType\`2](#vsxmd-program-testgenerictype`2)
  - [TestGenericMethod\`\`2()](#vsxmd-program-testgenerictype`2-testgenericmethod``2)
- [TypeparamUnit](#vsxmd-units-typeparamunit)
  - [#ctor(element)](#vsxmd-units-typeparamunit-#ctor-system-xml-linq-xelement-)
  - [ToMarkdown()](#vsxmd-units-typeparamunit-tomarkdown)
  - [ToMarkdown(elements)](#vsxmd-units-typeparamunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-)

<a name='vsxmd-units-assemblyunit'></a>
## AssemblyUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Assembly unit.

<a name='vsxmd-units-assemblyunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [AssemblyUnit](#vsxmd-units-assemblyunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The assembly XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `assembly`. |

<a name='vsxmd-units-assemblyunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-baseunit'></a>
## BaseUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

The base unit.

<a name='vsxmd-units-baseunit-#ctor-system-xml-linq-xelement,system-string-'></a>
### #ctor(element,elementName) `constructor`

##### Summary

Initializes a new instance of the [BaseUnit](#vsxmd-units-baseunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The XML element. |
| elementName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The expected XML element name. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML `element` name not matches the expected `elementName`. |

<a name='vsxmd-units-baseunit-element'></a>
### Element `property`

##### Summary

Gets the XML element.

<a name='vsxmd-units-baseunit-elementcontent'></a>
### ElementContent `property`

##### Summary

Gets the Markdown content representing the element.

<a name='vsxmd-units-baseunit-getattribute-system-xml-linq-xname-'></a>
### GetAttribute(name) `method`

##### Summary

Returns the [XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute') value of this [XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') that has the specified `name`.

##### Returns

An [XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute') value that has the specified `name`; `null` if there is no attribute with the specified `name`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.Xml.Linq.XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') | The [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') of the [XAttribute](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XAttribute 'System.Xml.Linq.XAttribute') to get. |

<a name='vsxmd-units-baseunit-getchild-system-xml-linq-xname-'></a>
### GetChild(name) `method`

##### Summary

Gets the first (in document order) child element with the specified `name`.

##### Returns

A [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') that matches the specified `name`, or `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.Xml.Linq.XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') | The [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') to match. |

<a name='vsxmd-units-baseunit-getchildren-system-xml-linq-xname-'></a>
### GetChildren(name) `method`

##### Summary

Returns a collection of the child elements of this element or document, in document order.
Only elements that have a matching [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') are included in the collection.

##### Returns

An [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') of [XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') containing the children that have a matching [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName'), in document order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.Xml.Linq.XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') | The [XName](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XName 'System.Xml.Linq.XName') to match. |

<a name='vsxmd-units-baseunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-converter'></a>
## Converter `type`

##### Namespace

Vsxmd

##### Summary

*Inherit from parent.*

<a name='vsxmd-converter-#ctor-system-xml-linq-xdocument-'></a>
### #ctor(document) `constructor`

##### Summary

Initializes a new instance of the [Converter](#vsxmd-converter) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [System.Xml.Linq.XDocument](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') | The XML document. |

<a name='vsxmd-converter-tomarkdown-system-xml-linq-xdocument-'></a>
### ToMarkdown(document) `method`

##### Summary

Convert VS XML document to Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [System.Xml.Linq.XDocument](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') | The XML document. |

<a name='vsxmd-converter-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-exampleunit'></a>
## ExampleUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Example unit.

<a name='vsxmd-units-exampleunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [ExampleUnit](#vsxmd-units-exampleunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The example XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `example`. |

<a name='vsxmd-units-exampleunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-exampleunit-tomarkdown-system-xml-linq-xelement-'></a>
### ToMarkdown(element) `method`

##### Summary

Convert the example XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The example XML element. |

<a name='vsxmd-units-exceptionunit'></a>
## ExceptionUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Exception unit.

<a name='vsxmd-units-exceptionunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [ExceptionUnit](#vsxmd-units-exceptionunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The exception XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `exception`. |

<a name='vsxmd-units-exceptionunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-exceptionunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-'></a>
### ToMarkdown(elements) `method`

##### Summary

Convert the exception XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}') | The exception XML element list. |

<a name='vsxmd-units-extensions'></a>
## Extensions `type`

##### Namespace

Vsxmd.Units

##### Summary

Extensions helper.

<a name='vsxmd-units-extensions-ascode-system-string-'></a>
### AsCode(code) `method`

##### Summary

Wrap the `code` into Markdown backtick safely.

The backtick characters inside the `code` reverse as it is.

##### Returns

The Markdown code span.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The code span. |

##### Remarks

Reference: http://meta.stackexchange.com/questions/55437/how-can-the-backtick-character-be-included-in-code .

<a name='vsxmd-units-extensions-escape-system-string-'></a>
### Escape(content) `method`

##### Summary

Escape the content to keep it raw in Markdown syntax.

##### Returns

The escaped content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| content | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content. |

<a name='vsxmd-units-extensions-join-system-collections-generic-ienumerable{system-string},system-string-'></a>
### Join(value,separator) `method`

##### Summary

Concatenates the `value`s with the `separator`.

##### Returns

The concatenated string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | The string values. |
| separator | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The separator. |

<a name='vsxmd-units-extensions-nthlast``1-system-collections-generic-ienumerable{``0},system-int32-'></a>
### NthLast\`\`1(source,index) `method`

##### Summary

Gets the n-th last element from the `source`.

##### Returns

The element at the specified position in the `source` sequence.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The source enumerable. |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The index for the n-th last. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements of `source`. |

<a name='vsxmd-units-extensions-suffix-system-string,system-string-'></a>
### Suffix(value,suffix) `method`

##### Summary

Suffix the `suffix` to the `value`, and generate a new string.

##### Returns

The new string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The original string value. |
| suffix | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The suffix string. |

<a name='vsxmd-units-extensions-takeallbutlast``1-system-collections-generic-ienumerable{``0},system-int32-'></a>
### TakeAllButLast\`\`1(source,count) `method`

##### Summary

Take all element except the last `count`.

##### Returns

The generated enumerable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The source enumerable. |
| count | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number to except. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the elements of `source`. |

<a name='vsxmd-units-extensions-toanchor-system-string-'></a>
### ToAnchor(href) `method`

##### Summary

Generate an anchor for the `href`.

##### Returns

The anchor for the `href`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| href | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The href. |

<a name='vsxmd-units-extensions-toherelink-system-string-'></a>
### ToHereLink(href) `method`

##### Summary

Generate "to here" link for the `href`.

##### Returns

The "to here" link for the `href`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| href | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The href. |

<a name='vsxmd-units-extensions-tolowerstring-vsxmd-units-memberkind-'></a>
### ToLowerString(memberKind) `method`

##### Summary

Convert the [MemberKind](#vsxmd-units-memberkind) to its lowercase name.

##### Returns

The member kind's lowercase name.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberKind | [Vsxmd.Units.MemberKind](#vsxmd-units-memberkind) | The member kind. |

<a name='vsxmd-units-extensions-tomarkdowntext-system-xml-linq-xelement-'></a>
### ToMarkdownText(element) `method`

##### Summary

Convert the inline XML nodes to Markdown text.
For example, it works for `summary` and `returns` elements.

##### Returns

The generated Markdown content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The XML element. |

##### Example

This method converts the following `summary` element.

```
<summary>The <paramref name="element" /> value is <value>null</value>, it throws <c>ArgumentException</c>. For more, see <see cref="M:Vsxmd.Units.Extensions.ToMarkdownText(System.Xml.Linq.XElement)" />.</summary>
```

To the below Markdown content.

```
The `element` value is `null`, it throws `ArgumentException`. For more, see `ToMarkdownText`.
```

<a name='vsxmd-units-extensions-toreferencelink-system-string,system-boolean-'></a>
### ToReferenceLink(memberName,useShortName) `method`

##### Summary

Generate the reference link for the `memberName`.

##### Returns

The generated reference link.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The member name. |
| useShortName | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicate if use short type name. |

##### Example

For `T:Vsxmd.Units.MemberUnit`, convert it to `[MemberUnit](#T-Vsxmd.Units.MemberUnit)`.

For `T:System.ArgumentException`, convert it to `[ArgumentException](http://msdn/path/to/System.ArgumentException)`.

<a name='vsxmd-iconverter'></a>
## IConverter `type`

##### Namespace

Vsxmd

##### Summary

Converter for XML document to Markdown syntax conversion.

<a name='vsxmd-iconverter-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

Convert to Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.

<a name='vsxmd-units-iunit'></a>
## IUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

[IUnit](#vsxmd-units-iunit) is wrapper to handle XML elements.

<a name='vsxmd-units-iunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

Represent the XML element content as Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.

<a name='vsxmd-units-memberkind'></a>
## MemberKind `type`

##### Namespace

Vsxmd.Units

##### Summary

The member kind.

<a name='vsxmd-units-memberkind-constants'></a>
### Constants `constants`

##### Summary

Constants

<a name='vsxmd-units-memberkind-constructor'></a>
### Constructor `constants`

##### Summary

Constructor.

<a name='vsxmd-units-memberkind-method'></a>
### Method `constants`

##### Summary

Method.

<a name='vsxmd-units-memberkind-notsupported'></a>
### NotSupported `constants`

##### Summary

Not supported member kind.

<a name='vsxmd-units-memberkind-property'></a>
### Property `constants`

##### Summary

Property.

<a name='vsxmd-units-memberkind-type'></a>
### Type `constants`

##### Summary

Type.

<a name='vsxmd-units-membername'></a>
## MemberName `type`

##### Namespace

Vsxmd.Units

##### Summary

Member name.

<a name='vsxmd-units-membername-#ctor-system-string,system-collections-generic-ienumerable{system-string}-'></a>
### #ctor(name,paramNames) `constructor`

##### Summary

Initializes a new instance of the [MemberName](#vsxmd-units-membername) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The raw member name. For example, `T:Vsxmd.Units.MemberName`. |
| paramNames | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | The parameter names. It is only used when member kind is [Constructor](#vsxmd-units-memberkind-constructor) or [Method](#vsxmd-units-memberkind-method). |

<a name='vsxmd-units-membername-#ctor-system-string-'></a>
### #ctor(name) `constructor`

##### Summary

Initializes a new instance of the [MemberName](#vsxmd-units-membername) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The raw member name. For example, `T:Vsxmd.Units.MemberName`. |

<a name='vsxmd-units-membername-caption'></a>
### Caption `property`

##### Summary

Gets the caption representation for this member name.

##### Example

For [Type](#vsxmd-units-memberkind-type), show as `## Vsxmd.Units.MemberName [#](#here) [^](#contents)`.

For other kinds, show as `### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)`.

<a name='vsxmd-units-membername-kind'></a>
### Kind `property`

##### Summary

Gets the member kind, one of [MemberKind](#vsxmd-units-memberkind).

<a name='vsxmd-units-membername-link'></a>
### Link `property`

##### Summary

Gets the link pointing to this member unit.

<a name='vsxmd-units-membername-namespace'></a>
### Namespace `property`

##### Summary

Gets the namespace name.

##### Example

`System`, `Vsxmd`, `Vsxmd.Units`.

<a name='vsxmd-units-membername-typename'></a>
### TypeName `property`

##### Summary

Gets the type name.

##### Example

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='vsxmd-units-membername-compareto-vsxmd-units-membername-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-membername-getparamtypes'></a>
### GetParamTypes() `method`

##### Summary

Gets the method parameter type names from the member name.

##### Returns

The method parameter type name list.

##### Parameters

This method has no parameters.

##### Example

It will prepend the type kind character (`T:`) to the type string.

For `(System.String,System.Int32)`, returns `["T:System.String","T:System.Int32"]`.

It also handle generic type.

For `(System.Collections.Generic.IEnumerable{System.String})`, returns `["T:System.Collections.Generic.IEnumerable{System.String}"]`.

<a name='vsxmd-units-membername-toreferencelink-system-boolean-'></a>
### ToReferenceLink(useShortName) `method`

##### Summary

Convert the member name to Markdown reference link.

If then name is under `System` namespace, the link points to MSDN.

Otherwise, the link points to this page anchor.

##### Returns

The generated Markdown reference link.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| useShortName | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicate if use short type name. |

<a name='vsxmd-units-memberunit'></a>
## MemberUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Member unit.

<a name='vsxmd-units-memberunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [MemberUnit](#vsxmd-units-memberunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The member XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `member`. |

<a name='vsxmd-units-memberunit-comparer'></a>
### Comparer `property`

##### Summary

Gets the member unit comparer.

<a name='vsxmd-units-memberunit-kind'></a>
### Kind `property`

##### Summary

Gets the member kind, one of [MemberKind](#vsxmd-units-memberkind).

<a name='vsxmd-units-memberunit-link'></a>
### Link `property`

##### Summary

Gets the link pointing to this member unit.

<a name='vsxmd-units-memberunit-typename'></a>
### TypeName `property`

##### Summary

Gets the type name.

##### Example

`Vsxmd.Program`, `Vsxmd.Units.TypeUnit`.

<a name='vsxmd-units-memberunit-complementtype-system-collections-generic-ienumerable{vsxmd-units-memberunit}-'></a>
### ComplementType(group) `method`

##### Summary

Complement a type unit if the member unit `group` does not have one.
One member unit group has the same [TypeName](#vsxmd-units-memberunit-typename).

##### Returns

The complemented member unit group.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| group | [System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{Vsxmd.Units.MemberUnit}') | The member unit group. |

<a name='vsxmd-units-memberunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-memberunit-memberunitcomparer'></a>
## MemberUnitComparer `type`

##### Namespace

Vsxmd.Units.MemberUnit

<a name='vsxmd-units-memberunit-memberunitcomparer-compare-vsxmd-units-memberunit,vsxmd-units-memberunit-'></a>
### Compare() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-paramunit'></a>
## ParamUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Param unit.

<a name='vsxmd-units-paramunit-#ctor-system-xml-linq-xelement,system-string-'></a>
### #ctor(element,paramType) `constructor`

##### Summary

Initializes a new instance of the [ParamUnit](#vsxmd-units-paramunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The param XML element. |
| paramType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The parameter type corresponding to the param XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `param`. |

<a name='vsxmd-units-paramunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-paramunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement},system-collections-generic-ienumerable{system-string},vsxmd-units-memberkind-'></a>
### ToMarkdown(elements,paramTypes,memberKind) `method`

##### Summary

Convert the param XML element to Markdown safely.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}') | The param XML element list. |
| paramTypes | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | The paramater type names. |
| memberKind | [Vsxmd.Units.MemberKind](#vsxmd-units-memberkind) | The member kind of the parent element. |

##### Remarks

When the parameter (a.k.a `elements`) list is empty:

If parent element kind is [Constructor](#vsxmd-units-memberkind-constructor) or [Method](#vsxmd-units-memberkind-method), it returns a hint about "no parameters".

If parent element kind is not the value mentioned above, it returns an empty string.

<a name='vsxmd-units-permissionunit'></a>
## PermissionUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Permission unit.

<a name='vsxmd-units-permissionunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [PermissionUnit](#vsxmd-units-permissionunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The permission XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `permission`. |

<a name='vsxmd-units-permissionunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-permissionunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-'></a>
### ToMarkdown(elements) `method`

##### Summary

Convert the permission XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}') | The permission XML element list. |

<a name='vsxmd-program'></a>
## Program `type`

##### Namespace

Vsxmd

##### Summary

Program entry.

##### Remarks

Usage syntax:

```
Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path]
```

The `input-XML-path` argument is required. It references to the VS generated XML documentation file.

The `output-Markdown-path` argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a `.md` file with same file name as the XML documentation file, path at the XML documentation folder.

<a name='vsxmd-program-main-system-string[]-'></a>
### Main(args) `method`

##### Summary

Program main function entry.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Program arguments. |

##### See Also

- [Vsxmd.Program](#vsxmd-program)

<a name='vsxmd-units-remarksunit'></a>
## RemarksUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Remarks unit.

<a name='vsxmd-units-remarksunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [RemarksUnit](#vsxmd-units-remarksunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The remarks XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `remarks`. |

<a name='vsxmd-units-remarksunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-remarksunit-tomarkdown-system-xml-linq-xelement-'></a>
### ToMarkdown(element) `method`

##### Summary

Convert the remarks XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The remarks XML element. |

<a name='vsxmd-units-returnsunit'></a>
## ReturnsUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Returns unit.

<a name='vsxmd-units-returnsunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [ReturnsUnit](#vsxmd-units-returnsunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The returns XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `returns`. |

<a name='vsxmd-units-returnsunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-returnsunit-tomarkdown-system-xml-linq-xelement-'></a>
### ToMarkdown(element) `method`

##### Summary

Convert the returns XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The returns XML element. |

<a name='vsxmd-units-seealsounit'></a>
## SeealsoUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Seealso unit.

<a name='vsxmd-units-seealsounit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [SeealsoUnit](#vsxmd-units-seealsounit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The seealso XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `seealso`. |

<a name='vsxmd-units-seealsounit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-seealsounit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-'></a>
### ToMarkdown(elements) `method`

##### Summary

Convert the seealso XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}') | The seealso XML element list. |

<a name='vsxmd-units-summaryunit'></a>
## SummaryUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Summary unit.

<a name='vsxmd-units-summaryunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [SummaryUnit](#vsxmd-units-summaryunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The summary XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `summary`. |

<a name='vsxmd-units-summaryunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-summaryunit-tomarkdown-system-xml-linq-xelement-'></a>
### ToMarkdown(element) `method`

##### Summary

Convert the summary XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The summary XML element. |

<a name='vsxmd-tableofcontents'></a>
## TableOfContents `type`

##### Namespace

Vsxmd

##### Summary

Table of contents.

<a name='vsxmd-tableofcontents-#ctor-system-linq-iorderedenumerable{vsxmd-units-memberunit}-'></a>
### #ctor(memberUnits) `constructor`

##### Summary

Initializes a new instance of the [TableOfContents](#vsxmd-tableofcontents) class.

It convert the table of contents from the `memberUnits`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberUnits | [System.Linq.IOrderedEnumerable{Vsxmd.Units.MemberUnit}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IOrderedEnumerable 'System.Linq.IOrderedEnumerable{Vsxmd.Units.MemberUnit}') | The member unit list. |

<a name='vsxmd-tableofcontents-link'></a>
### Link `property`

##### Summary

Gets the link pointing to the table of contents.

<a name='vsxmd-tableofcontents-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

Convert the table of contents to Markdown syntax.

##### Returns

The table of contents in Markdown syntax.

##### Parameters

This method has no parameters.

<a name='vsxmd-program-test'></a>
## Test `type`

##### Namespace

Vsxmd.Program

<a name='vsxmd-program-test-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [Test](#vsxmd-program-test) class.

Test constructor without parameters.

See [Test.#ctor](#vsxmd-program-test-#ctor).

##### Parameters

This constructor has no parameters.

##### Permissions

| Name | Description |
| ---- | ----------- |
| [Vsxmd.Program](#vsxmd-program) | Just for test. |

<a name='vsxmd-program-test-testbacktickinsummary'></a>
### TestBacktickInSummary() `method`

##### Summary

Test backtick characters in summary comment.

See \`should not inside code block\`.

See `` `backtick inside code block` ``.

See \``code block inside backtick`\`.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='vsxmd-program-test-testgenericexception'></a>
### TestGenericException() `method`

##### Summary

Test generic exception type.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Vsxmd.Program.Test.TestGenericParameter\`\`2](#vsxmd-program-test-testgenericparameter``2-system-linq-expressions-expression{system-func{``0,``1,system-string}}-) | Just for test. |

<a name='vsxmd-program-test-testgenericparameter``2-system-linq-expressions-expression{system-func{``0,``1,system-string}}-'></a>
### TestGenericParameter\`\`2(expression) `method`

##### Summary

Test generic parameter type.

See `T1` and `T2`.

##### Returns

Nothing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1,System.String}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,``1,System.String}}') | The linq expression. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T1 | Generic type 1. |
| T2 | Generic type 2. |

<a name='vsxmd-program-test-testgenericpermission'></a>
### TestGenericPermission() `method`

##### Summary

Test generic exception type.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Permissions

| Name | Description |
| ---- | ----------- |
| [Vsxmd.Program.Test.TestGenericParameter\`\`2](#vsxmd-program-test-testgenericparameter``2-system-linq-expressions-expression{system-func{``0,``1,system-string}}-) | Just for test. |

<a name='vsxmd-program-test-testgenericreference'></a>
### TestGenericReference() `method`

##### Summary

Test generic reference type.

See [TestGenericParameter\`\`2](#vsxmd-program-test-testgenericparameter``2-system-linq-expressions-expression{system-func{``0,``1,system-string}}-).

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='vsxmd-program-test-testparamwithoutdescription-system-string-'></a>
### TestParamWithoutDescription(p) `method`

##### Summary

Test a param tag without description.

##### Returns

Nothing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| p | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='vsxmd-program-test-testseelangword'></a>
### TestSeeLangword() `method`

##### Summary

Test see tag with langword attribute. See `true`.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='vsxmd-program-test-testspaceafterinlineelements``1-system-boolean-'></a>
### TestSpaceAfterInlineElements\`\`1() `method`

##### Summary

Test space after inline elements.

See `code block` should follow a space.

See a value at the end of a `sentence`.

See [TestSpaceAfterInlineElements\`\`1](#vsxmd-program-test-testspaceafterinlineelements``1-system-boolean-) as a link.

See `space` after a param ref.

See `T` after a type param ref.

##### Returns

Nothing.

##### Parameters

This method has no parameters.

<a name='vsxmd-program-testgenerictype`2'></a>
## TestGenericType\`2 `type`

##### Namespace

Vsxmd.Program

##### Summary

Test generic type.

See [TestGenericType\`2](#vsxmd-program-testgenerictype`2).

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T1 | Generic type 1. |
| T2 | Generic type 2. |

<a name='vsxmd-program-testgenerictype`2-testgenericmethod``2'></a>
### TestGenericMethod\`\`2() `method`

##### Summary

Test generic method.

See [TestGenericMethod\`\`2](#vsxmd-program-testgenerictype`2-testgenericmethod``2).

##### Returns

Nothing.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T3 | Generic type 3. |
| T4 | Generic type 4. |

<a name='vsxmd-units-typeparamunit'></a>
## TypeparamUnit `type`

##### Namespace

Vsxmd.Units

##### Summary

Typeparam unit.

<a name='vsxmd-units-typeparamunit-#ctor-system-xml-linq-xelement-'></a>
### #ctor(element) `constructor`

##### Summary

Initializes a new instance of the [TypeparamUnit](#vsxmd-units-typeparamunit) class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Xml.Linq.XElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XElement 'System.Xml.Linq.XElement') | The typeparam XML element. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Throw if XML element name is not `typeparam`. |

<a name='vsxmd-units-typeparamunit-tomarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='vsxmd-units-typeparamunit-tomarkdown-system-collections-generic-ienumerable{system-xml-linq-xelement}-'></a>
### ToMarkdown(elements) `method`

##### Summary

Convert the param XML element to Markdown safely.
If element is `null`, return empty string.

##### Returns

The generated Markdown.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| elements | [System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Xml.Linq.XElement}') | The param XML element list. |
